﻿//MIT License

//Copyright (c) 2020-2021 Jordi Corbilla

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using System.Collections.Generic;
using table.lib;

namespace table.runner
{
    public static class Samples
    {
        public static List<TestClass> GetSampleOutput()
        {
            var list = new List<TestClass>
            {
                new TestClass
                {
                    Field1 = 321121, Field2 = "Hi 312321", Field3 = 2121.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                },
                new TestClass
                {
                    Field1 = 32321, Field2 = "Hi long text", Field3 = 21111111.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                },
                new TestClass
                {
                    Field1 = 321, Field2 = "Hi longer text", Field3 = 2121.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                },
                new TestClass
                {
                    Field1 = 13, Field2 = "Hi very long text", Field3 = 21111121.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                },
                new TestClass
                {
                    Field1 = 13, Field2 = "Hi very, long text", Field3 = 21111121.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                },
                new TestClass
                {
                    Field1 = 13, Field2 = "Hi \"very\" long\n text", Field3 = 21111121.32m, Field4 = true,
                    Field5 = new DateTime(1970, 1, 1), Field6 = 34.43
                }
            };
            return list;
        }

        public static List<IEnumerable<string>> GetStringMatrix()
        {
            var test = new List<IEnumerable<string>>
            {
                new List<string> {"AAA", "BBB", "CCC"},
                new List<string> {"AAA", "BBB", "CCC"},
                new List<string> {"AAA", "BBB", "CCC"},
                new List<string> {"AAA", "BBB", "CCC"}
            };
            return test;
        }

        public static List<IEnumerable<int>> GetIntMatrix()
        {
            var matrix = new List<IEnumerable<int>>
            {
                new List<int> {1, 2, 3},
                new List<int> {1, 2, 3},
                new List<int> {1, 2, 3},
                new List<int> {1, 2, 3}
            };
            return matrix;
        }

        public static Dictionary<string, TestClass> GetSimpleDictionary()
        {
            var dic = new Dictionary<string, TestClass>
            {
                {
                    "1", new TestClass
                    {
                        Field1 = 321121,
                        Field2 = "Hi 312321",
                        Field3 = 2121.32m,
                        Field4 = true,
                        Field5 = new DateTime(1970, 1, 1),
                        Field6 = 34.43
                    }
                },
                {
                    "2", new TestClass
                    {
                        Field1 = 321121,
                        Field2 = "Hi 312321",
                        Field3 = 2121.32m,
                        Field4 = true,
                        Field5 = new DateTime(1970, 1, 1),
                        Field6 = 34.43
                    }
                },
                {
                    "3", new TestClass
                    {
                        Field1 = 321121,
                        Field2 = "Hi 312321",
                        Field3 = 2121.32m,
                        Field4 = true,
                        Field5 = new DateTime(1970, 1, 1),
                        Field6 = 34.43
                    }
                }
            };
            return dic;
        }

        public static void SimpleConsoleOutputForList()
        {
            Table<TestClass>.Add(GetSampleOutput()).ToConsole();
        }

        public static void SimpleConsoleOutputWithHighlighterForList()
        {
            Table<TestClass>.Add(GetSampleOutput())
                .HighlightValue(new HighlightOperator
                    {Field = "Field3", Type = HighlightType.Decimal, DecimalValue = 2121.32m})
                .ToConsole();
        }

        public static void SimpleCsvOutputForList()
        {
            Table<TestClass>.Add(GetSampleOutput()).ToCsv(@"C:\temp\test-list.csv");
        }

        public static void SimpleHtmlOutputForList()
        {
            Table<TestClass>.Add(GetSampleOutput()).ToHtml(@"C:\temp\test-list.html");
        }

        public static void ComplexConsoleOutputForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix()).ToConsole();
        }

        public static void ComplexConsoleOutputFilteringForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .FilterColumns(new[] {"Dynamic0"}, FilterAction.Include)
                .ToConsole();

            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .FilterColumns(new[] {"Dynamic0"}, FilterAction.Include)
                .ToConsole();

            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .FilterColumns(new[] {"Dynamic0", "Dynamic1"}, FilterAction.Include)
                .HighlightRows(ConsoleColor.Red, ConsoleColor.White)
                .ToConsole();
        }

        public static void ComplexConsoleOutputOverrideFilteringForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}})
                .FilterColumns(new[] {"Dynamic0"}, FilterAction.Include)
                .ToConsole();

            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}}).ToConsole();

            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}})
                .FilterColumns(new[] {"Capacity", "Count"}).ToConsole();

            Table<IEnumerable<string>>.Add(GetStringMatrix()).OverrideColumnsNames(new Dictionary<string, string>
            {
                {"Dynamic0", "A"},
                {"Dynamic1", "B"},
                {"Dynamic2", "C"}
            }).FilterColumns(new[] {"Capacity", "Count"}).ColumnContentTextJustification(
                new Dictionary<string, TextJustification>
                {
                    {"Dynamic0", TextJustification.Right},
                    {"Dynamic1", TextJustification.Centered}
                }).ToConsole();
        }

        public static void ComplexCsvOutputFilteringForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}})
                .FilterColumns(new[] {"Capacity", "Count"}).ToCsv(@"C:\temp\test.csv");
        }

        public static void ComplexHtmlOutputFilteringForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}})
                .FilterColumns(new[] {"Capacity", "Count"}).ToHtml(@"C:\temp\test.html");
        }

        public static void ComplexMarkDownOutputFilteringForList()
        {
            Table<IEnumerable<string>>.Add(GetStringMatrix())
                .OverrideColumnsNames(new Dictionary<string, string> {{"Dynamic0", "ColumnA"}})
                .FilterColumns(new[] {"Capacity", "Count"})
                .ColumnContentTextJustification(new Dictionary<string, TextJustification>
                    {{"Dynamic0", TextJustification.Right}}).ToMarkDown(@"C:\temp\test.md", true);
        }

        public static void ComplexConsoleMatrix()
        {
            Table<IEnumerable<int>>.Add(GetIntMatrix(), "T")
                .ToConsole();
        }

        public static void SimpleConsoleForDictionary()
        {
            TableDic<string, TestClass>.Add(GetSimpleDictionary())
                .ToConsole();

            TableDic<string, TestClass>.Add(GetSimpleDictionary())
                .FilterColumns(new[] { "Key_Id" })
                .ToConsole();
        }
    }
}