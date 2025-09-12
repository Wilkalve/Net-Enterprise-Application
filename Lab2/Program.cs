using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

// Lab2: Implementing Sorting Algorithms and LINQ in C#
namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool fileLoaded = false;
            string filePath = "Words.txt"; // Path to the text file
            List<string> words = new List<string>();

            bool running = true;

            while (running)
            {
                ConsolePrint(); // Show the menu each time
                string input = Console.ReadLine();
                Console.WriteLine();


                switch (input)
                {
                    case "1":
                        // Import words from file
                        try
                        {
                            words = ReadWordsFromFile(filePath);
                            fileLoaded = true;
                            Console.WriteLine("Words imported successfully.");
                            Console.WriteLine($"Total words read: {words.Count}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error reading file: {ex.Message}");
                        }

                        break;

                    case "2":
                        // Bubble Sort and time taken
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "2")
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            BubbleSort(words);

                            stopwatch.Stop();
                            Console.WriteLine($"Time taken to sort: {stopwatch.ElapsedMilliseconds} ms");
                        }
                        break;

                    case "3":
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "3")
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            var sortedWords = sortWord(words);
                            stopwatch.Stop();
                            Console.WriteLine($"Time taken to sort using LINQ/Lambda: {stopwatch.ElapsedMilliseconds} ms");
                        }
                        break;

                    case "4":
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "4")
                        {
                            int count = CountDistinctWords(words);
                            Console.WriteLine("Total Distinct words: " + count);
                        }
                        break;

                    case "5":
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "5")
                        {
                            string first10Words = string.Join(", ", TakeFirstWords(words));
                            Console.WriteLine("First 10 words: " + first10Words);
                        }

                        break;

                    case "6":

                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "6")
                        {
                            Console.WriteLine("Reversed words:");
                            ReverseWords(words);
                        }
                        break;

                    case "7":
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }
                        if (input == "7")
                        {
                            wordEndingWithA(words);
                        }

                        break;

                    case "8":
                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }

                        if (input == "8")
                        {
                            wordStartingWithM(words);
                        }
                        break;

                    case "9":

                        if (!fileLoaded)
                        {
                            Console.WriteLine("Please load the file first (Option 1).");
                            break;
                        }
                        if(input == "9")
                        {
                            DisplayWordWithF(words);
                        }

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


        // Method to print the console menu
        public static void ConsolePrint()
        {
            // Options for the user
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
        private static List<string> ReadWordsFromFile(string filePath)
        {
            List<string> words = new List<string>();

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


        // Bubble Sort implementation
        public static IList<string> BubbleSort(IList<string> words)
        {
            int n = words.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {

                    if (String.Compare(words[j], words[j + 1], StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        // Swap words[j] and words[j+1]
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }

            return words;
        }

        // LINQ/Lambda sort words
        public static IList<string> sortWord(IList<string> words)
        {

            return words.Where(w => !string.IsNullOrWhiteSpace(w))
                        .OrderBy(w => w, StringComparer.OrdinalIgnoreCase)
                        .ToList();

        }


        // count distinct words
        public static int CountDistinctWords(IEnumerable<string> words)
        {
            return words.Where(w => !string.IsNullOrWhiteSpace(w))
                        .Select(w => w.ToLower()).Distinct().Count();
        }

        // Take the first 10 words
        public static List<string> TakeFirstWords(IEnumerable<string> words)
        {
            return words.Where(w => !string.IsNullOrWhiteSpace(w))
                        .Take(10)
                        .ToList();
        }

        // Reverse each word and print the list

        public static void ReverseWords(List<string> words)
        {
            words
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => new string(w.Trim().Reverse().ToArray()))
                .ToList()
                .ForEach(Console.WriteLine);
        }

        // Words that end with 'a' and display the count
        public static void wordEndingWithA(IEnumerable<string> words)
        {
            var result = words.Where(w => w.EndsWith("a", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("Words ending with 'a':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine($"Total count: {result.Count}");
        }

        // Words that start with 'm' and display the count
        public static void wordStartingWithM(IEnumerable<string> words)
        {
            var result = words.Where(w => w.StartsWith("m", StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("Words starting with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine($"Total count: {result.Count}");
        }

        // Words that are more than 5 characters long and contain the letter 'f', and display the count
        public static void DisplayWordWithF(List<string> words)
        {
            var matchWord = new List<string>();

            foreach(var word in words)
            {
                if(!string.IsNullOrWhiteSpace(word))
                {
                    string trimmedword = word.Trim();
                    if(trimmedword.Length > 5 && trimmedword.IndexOf('f', StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        matchWord.Add(trimmedword);
                    }
                }
            }

            Console.WriteLine("Words more than 5 characters long and contain the letter 'f':");
            foreach (var word in matchWord)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine($"Total count: {matchWord.Count}");

        }

    }
}

