using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter16
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBinaryTree();
        }

        static void PrintDictionary()
        {
            Dictionary<string, ConsoleColor> colorMap =
                new Dictionary<string, ConsoleColor>
                {
                    ["Error"] = ConsoleColor.Red,
                    ["Warning"] = ConsoleColor.Yellow,
                    ["Information"] = ConsoleColor.Green,
                    ["Verbose"] = ConsoleColor.White
                };

            Print(colorMap);
        }

        static void Print(IEnumerable<KeyValuePair<string, ConsoleColor>> items)
        {
            foreach(KeyValuePair<string, ConsoleColor> item in items)
            {
                Console.ForegroundColor = item.Value;
                Console.WriteLine(item.Key);
            }
        }

        static void PrintPair()
        {
            Pair<string> stringPair = new Pair<string>("1st", "2nd");
            Console.WriteLine($"String Pair - First Item: {stringPair[PairItem.First]}");
            Console.WriteLine($"String Pair - Second Item: {stringPair[PairItem.Second]}");

            foreach (string item in stringPair)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintBinaryTree()
        {
            // JFK
            var jfkFamilyTree = new BinaryTree<string>("John Fitzgerald Kennedy");

            jfkFamilyTree.SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("Joseph Patrick Kennedy"), 
                new BinaryTree<string>("Rose Elizabeth Fitzgerald"));

            jfkFamilyTree.SubItems.First.SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("Patrick Joseph Kennedy"),
                new BinaryTree<string>("Mary Augusta Hickey"));

            // Grandparents (Mother's side)
            jfkFamilyTree.SubItems.Second.SubItems = new Pair<BinaryTree<string>>(
            new BinaryTree<string>("John Francis Fitzgerald"),
            new BinaryTree<string>("Mary Josephine Hannon"));

            foreach (string name in jfkFamilyTree)
            {
                Console.WriteLine(name);
            }
        }
    }
}
