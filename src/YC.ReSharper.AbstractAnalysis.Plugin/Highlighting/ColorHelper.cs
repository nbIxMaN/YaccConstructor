﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using JetBrains.ReSharper.Daemon;
using MatcherHelper = YC.ReSharper.AbstractAnalysis.Plugin.Highlighting.Dynamic.MatcherHelper;

namespace YC.ReSharper.AbstractAnalysis.Plugin.Highlighting
{
    public class ColorHelper
    {
        public static string DefaultColor = HighlightingAttributeIds.UNRESOLVED_ERROR_ATTRIBUTE;

        private static Dictionary<string, Dictionary<string, string>> parsedFiles =
            new Dictionary<string, Dictionary<string, string>>();

        private static Dictionary<string, string> myTokenToColor = new Dictionary<string, string>();

        public static Dictionary<string, string> TokenToColor
        {
            get { return myTokenToColor; }
        }

        private static Dictionary<string, string> mapping = new Dictionary<string, string>()
        {
            {"ANALYSIS_ERROR_ERRORSTRIPE", HighlightingAttributeIds.ANALYSIS_ERROR_ERRORSTRIPE},
            {"ANALYSIS_SUGGESTION_ERRORSTRIPE", HighlightingAttributeIds.ANALYSIS_SUGGESTION_ERRORSTRIPE},
            {"ANALYSIS_WARNING_ERRORSTRIPE", HighlightingAttributeIds.ANALYSIS_WARNING_ERRORSTRIPE},
            {"CLASS_IS_INHERITED_ATTRIBUTE", HighlightingAttributeIds.CLASS_IS_INHERITED_ATTRIBUTE},
            {"CONSTANT_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.CONSTANT_IDENTIFIER_ATTRIBUTE},
            {"DEADCODE_ATTRIBUTE", HighlightingAttributeIds.DEADCODE_ATTRIBUTE},
            {"ERROR_ATTRIBUTE",HighlightingAttributeIds.ERROR_ATTRIBUTE},
            {"EVENT_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.EVENT_IDENTIFIER_ATTRIBUTE},
            {"EXTENSION_METHOD_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.EXTENSION_METHOD_IDENTIFIER_ATTRIBUTE},
            {"FIELD_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.FIELD_IDENTIFIER_ATTRIBUTE},
            {"FORMAT_STRING_ITEM", HighlightingAttributeIds.FORMAT_STRING_ITEM},
            {"HIDES_ATTRIBUTE", HighlightingAttributeIds.HIDES_ATTRIBUTE},
            {"HINT_ATTRIBUTE", HighlightingAttributeIds.HINT_ATTRIBUTE},
            {"IMPLEMENTS_AND_HIDES_ATTRIBUTE", HighlightingAttributeIds.IMPLEMENTS_AND_HIDES_ATTRIBUTE},
            {"IMPLEMENTS_AND_OVERRIDES_ATTRIBUTE", HighlightingAttributeIds.IMPLEMENTS_AND_OVERRIDES_ATTRIBUTE},
            {"IMPLEMENTS_ATTRIBUTE", HighlightingAttributeIds.IMPLEMENTS_ATTRIBUTE},
            {"INTERFACE_IS_IMPLEMENTED_ATTRIBUTE", HighlightingAttributeIds.INTERFACE_IS_IMPLEMENTED_ATTRIBUTE},
            {"JAVA_SCRIPT_XML_DOC_TAG", HighlightingAttributeIds.JAVA_SCRIPT_XML_DOC_TAG},
            {"JS_FUNCTION_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.JS_FUNCTION_IDENTIFIER_ATTRIBUTE},
            {"JS_LATEBOUND_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.JS_LATEBOUND_IDENTIFIER_ATTRIBUTE},
            {"JS_LOCAL_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.JS_LOCAL_IDENTIFIER_ATTRIBUTE},
            {"JS_PARAMETER_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.JS_PARAMETER_IDENTIFIER_ATTRIBUTE},
            {"JS_PROPERTY_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.JS_PROPERTY_IDENTIFIER_ATTRIBUTE},
            {"LATE_BOUND_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.LATE_BOUND_IDENTIFIER_ATTRIBUTE},
            {"LOCAL_VARIABLE_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.LOCAL_VARIABLE_IDENTIFIER_ATTRIBUTE},
            {"MATCHED_BRACE", HighlightingAttributeIds.MATCHED_BRACE},
            {"MATCHED_FORMAT_STRING_ITEM", HighlightingAttributeIds.MATCHED_FORMAT_STRING_ITEM},
            {"METHOD_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.METHOD_IDENTIFIER_ATTRIBUTE},
            {"MUTABLE_LOCAL_VARIABLE_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.MUTABLE_LOCAL_VARIABLE_IDENTIFIER_ATTRIBUTE},
            {"NAMESPACE_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.NAMESPACE_IDENTIFIER_ATTRIBUTE},
            {"OPERATOR_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.OPERATOR_IDENTIFIER_ATTRIBUTE},
            {"OUTLINE_BRACE", HighlightingAttributeIds.OUTLINE_BRACE},
            {"OVERRIDES_ATTRIBUTE", HighlightingAttributeIds.OVERRIDES_ATTRIBUTE},
            {"PARAMETER_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.PARAMETER_IDENTIFIER_ATTRIBUTE},
            {"PATH_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.PATH_IDENTIFIER_ATTRIBUTE},
            {"PUBLIC_DEADCODE_ATTRIBUTE", HighlightingAttributeIds.PUBLIC_DEADCODE_ATTRIBUTE},
            {"RECURSION_ATTRIBUTE", HighlightingAttributeIds.RECURSION_ATTRIBUTE},
            {"TODOITEM_ATTRIBUTE", HighlightingAttributeIds.TODOITEM_ATTRIBUTE},
            {"TODOITEM_ERRORSTRIPE_ATTRIBUTE", HighlightingAttributeIds.TODOITEM_ERRORSTRIPE_ATTRIBUTE},
            {"SUGGESTION_ATTRIBUTE", HighlightingAttributeIds.SUGGESTION_ATTRIBUTE},
            {"TS_CLASS_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.TS_CLASS_IDENTIFIER_ATTRIBUTE},
            {"TS_ENUM_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.TS_ENUM_IDENTIFIER_ATTRIBUTE},
            {"TS_INTERFACE_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.TS_INTERFACE_IDENTIFIER_ATTRIBUTE},
            {"TS_MODULE_IDENTIFIER_ATTRIBUTE", HighlightingAttributeIds.TS_MODULE_IDENTIFIER_ATTRIBUTE},
            {"TS_TYPE_PARAMETER_IDENTIFIER_ATTRIBUTE",HighlightingAttributeIds.TS_TYPE_PARAMETER_IDENTIFIER_ATTRIBUTE},
            {"TYPE_CLASS_ATTRIBUTE", HighlightingAttributeIds.TYPE_CLASS_ATTRIBUTE},
            {"TYPE_STATIC_CLASS_ATTRIBUTE", HighlightingAttributeIds.TYPE_STATIC_CLASS_ATTRIBUTE},
            {"TYPE_DELEGATE_ATTRIBUTE", HighlightingAttributeIds.TYPE_DELEGATE_ATTRIBUTE},
            {"TYPE_ENUM_ATTRIBUTE", HighlightingAttributeIds.TYPE_ENUM_ATTRIBUTE},
            {"TYPE_INTERFACE_ATTRIBUTE", HighlightingAttributeIds.TYPE_INTERFACE_ATTRIBUTE},
            {"TYPE_PARAMETER_ATTRIBUTE", HighlightingAttributeIds.TYPE_ENUM_ATTRIBUTE},
            {"TYPE_STRUCT_ATTRIBUTE", HighlightingAttributeIds.TYPE_STRUCT_ATTRIBUTE},
            {"UNMATCHED_BRACE", HighlightingAttributeIds.UNMATCHED_BRACE},
            {"UNRESOLVED_ERROR_ATTRIBUTE", HighlightingAttributeIds.UNRESOLVED_ERROR_ATTRIBUTE},
            {"WARNING_ATTRIBUTE", HighlightingAttributeIds.WARNING_ATTRIBUTE},
        };

        public static void ParseFile(string fileName, string lang)
        {
            if (parsedFiles.ContainsKey(fileName))
            {
                myTokenToColor = parsedFiles[fileName];
                return;
            }

            MatcherHelper.ChangeLanguageTo(lang);

            var path = GetFullPath(fileName);

            using (XmlReader reader = new XmlTextReader
                (new StreamReader(path)))
            {
                reader.MoveToContent();
                var xmlReader = GetValidatingReader(reader, new XmlSchemaSet());
                xmlReader.Read();
                Dictionary<string, string> res = ParseDefinition(xmlReader, lang);
                myTokenToColor = res;

                parsedFiles.Add(fileName, res);
                MatcherHelper.UpdateMatchingValues(lang);

            }
        }

        private static string GetFullPath(string fileName)
        {
            var res = Directory.GetFiles(@"..\..\..", fileName, SearchOption.AllDirectories);
            if (res.Length > 0)
                return res[0];

            return string.Empty;
        }

        private static Dictionary<string, string> ParseDefinition(XmlReader xmlReader, string lang)
        {
            var dict = new Dictionary<string, string>();
            while (xmlReader.Read() && xmlReader.NodeType != XmlNodeType.EndElement)
            {
                if (xmlReader.Name == "Tokens")
                {
                    ParseTokensGroup(xmlReader, xmlReader.GetAttribute("color"), dict);
                }
                else if (xmlReader.Name == "Token")
                {
                    ParseToken(xmlReader, xmlReader.GetAttribute("color"), dict);
                }
                else if (xmlReader.Name == "Matched")
                {
                    ParseMatching(xmlReader, lang);
                }
                else
                {
                    throw new Exception(string.Format("Unexpected element"));
                }
            }
            return dict;
        }

        private static void ParseToken(XmlReader xmlReader, string color, Dictionary<string, string> dict)
        {
            xmlReader.Read();
            var content = xmlReader.ReadContentAsString().Trim();

            if (dict.ContainsKey(content))
                return;

            if (!string.IsNullOrEmpty(color) && mapping.ContainsKey(color))
                dict.Add(content.ToLower(), mapping[color]);
            else
                dict.Add(content.ToLower(), DefaultColor);
        }

        private static void ParseTokensGroup(XmlReader xmlReader, string color, Dictionary<string, string> dict)
        {
            while (xmlReader.Read() && xmlReader.NodeType != XmlNodeType.EndElement)
            {
                ParseToken(xmlReader, color, dict);
            }
        }

        private static void ParseMatching(XmlReader xmlReader, string lang)
        {
            while (xmlReader.Read() && xmlReader.NodeType != XmlNodeType.EndElement)
            {
                xmlReader.Read();

                var left = ParseLeftMatcher(xmlReader);
                var right = ParseRightMatcher(xmlReader);

                MatcherHelper.AddMatch(left, right, lang);
            }
        }

        private static string ParseLeftMatcher(XmlReader xmlReader)
        {
            if (xmlReader.Name == "Left")
            {
                xmlReader.Read();
                string res = xmlReader.ReadContentAsString().Trim();
                xmlReader.Read();
                return res;
            }
            throw new Exception("Unexpected left element in matching");
        }

        private static string ParseRightMatcher(XmlReader xmlReader)
        {
            if (xmlReader.Name == "Right")
            {
                xmlReader.Read();
                string res = xmlReader.ReadContentAsString().Trim();
                xmlReader.Read();
                return res;
            }
            throw new Exception("Unexpected right element in matching");
        }

        private static XmlReader GetValidatingReader(XmlReader input, XmlSchemaSet schemaSet)
        {
            var settings = new XmlReaderSettings
            {
                CloseInput = true,
                IgnoreComments = true,
                IgnoreWhitespace = true
            };

            if (schemaSet != null)
            {
                settings.Schemas = schemaSet;
                settings.ValidationType = ValidationType.Schema;
            }
            return XmlReader.Create(input, settings);
        }
    }
}