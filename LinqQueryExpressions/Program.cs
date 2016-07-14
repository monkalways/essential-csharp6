using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryExpressions
{
    class Program
    {
        static string[] Keywords = {
            "abstract", "add*", "alias*", "as", "ascending*",
            "async*", "await*", "base","bool", "break",
            "by*", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default",
            "delegate", "descending*", "do", "double",
            "dynamic*", "else", "enum", "event", "equals*",
            "explicit", "extern", "false", "finally", "fixed",
            "from*", "float", "for", "foreach", "get*", "global*",
            "group*", "goto", "if", "implicit", "in", "int",
            "into*", "interface", "internal", "is", "lock", "long",
            "join*", "let*", "nameof*", "namespace", "new", "null",
            "object", "on*", "operator", "orderby*", "out",
            "override", "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte",
            "sealed", "select*", "set*", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong",
            "unsafe", "ushort", "using", "value*", "var*", "virtual",
            "unchecked", "void", "volatile", "where*", "while", "yield*"};

        static void Main(string[] args)
        {
            //ShowContextualKeywords1();
            //List2("G:\\temp\\Chapter2", "*.*");
            //GroupKeywords1();

            ListMemberNames();
        }

        private static void ShowContextualKeywords1()
        {
            IEnumerable<string> selection =
                from word in Keywords
                where !word.Contains('*')
                select word;

            foreach (string keyword in selection)
            {
                Console.Write(keyword + " ");
            }
        }

        private static void GroupKeywords1()
        {
            var selection =
                from word in Keywords
                group word by word.Contains('*')
                into groups
                    select new
                    {
                        IsContextualKeyword = groups.Key,
                        Items = groups
                    };

            foreach (var wordGroup in selection)
            {
                Console.WriteLine(Environment.NewLine + "{0}:",
                    wordGroup.IsContextualKeyword ? "Contextual Keywords" : "Keywords");

                foreach (string keyword in wordGroup.Items)
                {
                    Console.Write(" " + keyword.Replace("*", null));
                }
            }
        }

        public static void ListMemberNames()
        {
            IEnumerable<string> enumerableMethodNames = (
                from method in typeof (Enumerable).GetMembers(BindingFlags.Static | BindingFlags.Public)
                orderby method.Name
                select method.Name).Distinct();

            foreach (string method in enumerableMethodNames)
            {
                Console.Write($"{method}, ");
            }
        }

        private static void List2(string rootDirectory, string searchPattern)
        {
            var fileNames = Directory.EnumerateFiles(rootDirectory, searchPattern);
            var fileResults =
                from fileName in fileNames
                let file = new FileInfo(fileName)
                where File.GetLastWriteTime(fileName) < DateTime.Now.AddMonths(-1) 
                orderby file.Length descending, fileName
                select new
                {
                    Name = fileName,
                    LastWriteTime = File.GetLastWriteTime(fileName)
                };

            foreach (var fileResult in fileResults)
            {
                Console.WriteLine(
                    $"{fileResult.Name} ({fileResult.LastWriteTime})");
            }
        }
    }
}
