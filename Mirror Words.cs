
namespace Mirror_words
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(@|#)(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            MatchCollection wordPairs = regex.Matches(text);
            List<string> mirrorWords = new List<string>();

            foreach (Match pair in wordPairs)
            {
                string wordOne = pair.Groups["wordOne"].Value;
                string wordTwo = pair.Groups["wordTwo"].Value;

                if (wordOne == string.Join("", wordTwo.Reverse()))
                {
                    mirrorWords.Add(wordOne);
                    mirrorWords.Add(wordTwo);
                }

            }

            if (wordPairs.Count > 0)
            {
                Console.WriteLine($"{wordPairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine($"No word pairs found!");
            }

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine($"The mirror words are:");

                for (int i = 0; i < mirrorWords.Count - 1; i += 2)
                {
                    if (i == mirrorWords.Count - 2)
                    {
                        Console.Write($"{mirrorWords[i]} <=> {mirrorWords[i + 1]}");
                    }
                    else
                    {
                        Console.Write($"{mirrorWords[i]} <=> {mirrorWords[i + 1]}, ");
                    }
                    
                }

            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }

        }
    }
}
