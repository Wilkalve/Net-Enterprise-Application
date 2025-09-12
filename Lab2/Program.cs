using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

// Lab2: Implementing Sorting Algorithms and LINQ in C#
namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsolePrint(); // Show the menu each time
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        string filePath = "Words.txt";
                        IList<string> words = ReadWordsFromFile(filePath);
                        Console.WriteLine($"Total words read: {words.Count}");
                        break;

                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        Console.WriteLine($"Option {input} selected.");
                        break;

                    case "q":
                    case "Q":
                        Console.Write("Are you sure you want to quit? (y/n): ");
                        string confirm = Console.ReadLine();
                        if (confirm.ToLower() == "y")
                        {
                            Console.WriteLine("Exiting the program.");
                            return;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }



        public static void ConsolePrint()
        {
            // Options choose for the user
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1 - Import words from file:");
            Console.WriteLine("2 - Bubble Sort words");
            Console.WriteLine("3 - LINQ/Lambda sort words");
            Console.WriteLine("4 - Count the Distinct words");
            Console.WriteLine("5 - Take the first 10 words");
            Console.WriteLine("6 - Reverse each word and print the list");
            Console.WriteLine("7 - Get and display words that end with 'a' and display the count");
            Console.WriteLine("8 - Get and display words that start with 'm' and display the count");
            Console.WriteLine("9 - Get and display words that are more than 5 characters long and contain the letter 'f', and display the count");
            Console.WriteLine("q - Exit\n");
            Console.Write("Enter your choice: ");

        }

        // Method to read words from a file and return them as a list
        private static IList<string> ReadWordsFromFile(string filePath)
        {
            IList<string> words = new List<string>();

            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return words;
            }

            foreach (var line in System.IO.File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var lineWords = line
                        .Split(new[] { ' ', '\t', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in lineWords)
                    {
                        words.Add(word);
                    }
                }
            }

            return words;
        }

    }
}
