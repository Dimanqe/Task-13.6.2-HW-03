using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("C:\\Users\\dsank\\Desktop\\Text2.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string cleanedWord = word.ToLower();

                if (wordCounts.ContainsKey(cleanedWord))
                {
                    wordCounts[cleanedWord]++;
                }
                else
                {
                    wordCounts[cleanedWord] = 1;
                }
            }

            var sortedWords = wordCounts.OrderByDescending(pair => pair.Value);
            int count = 0;
            Console.WriteLine("Топ 10 самых повторяющихся слов в тексте:\n ");
            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"{count+1}-\"{pair.Key}\": {pair.Value} раз");
                count++;
                if (count >= 10)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
