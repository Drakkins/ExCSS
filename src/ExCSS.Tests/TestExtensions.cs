﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExCSS.Tests
{
    static class TestExtensions
    {
        public static Stylesheet ToCssStylesheet(this string sourceCode)
        {
            var parser = new StylesheetParser();
            return parser.Parse(sourceCode);
        }

        public static IEnumerable<T> GetAll<T>(this IStylesheetNode node)
            where T : IStyleFormattable
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (node is T)
            {
                yield return (T)node;
            }

            foreach (var entity in node.Children.SelectMany(m => m.GetAll<T>()))
            {
                yield return entity;
            }
        }

        public static Stylesheet ToCssStylesheet(this Stream content)
        {
            var parser = new StylesheetParser();
            return parser.Parse(content);
        }
    }
}