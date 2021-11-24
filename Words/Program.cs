using System;
using System.Linq;

namespace Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = WordParser("Creativity is thinking-up new things. Innovation is doing new things!");
            Console.WriteLine(output);
        }


        public static string WordParser(string input) {
            string[] words = input.Split(' ', '-', '.', '!');
            var separators = input.Where(x => x == ' ' || x == '-' || x == '.' || x == '!').ToList();
            string result = string.Empty;
            string restructuredWord = string.Empty;

            for (int i = 0; i < words.Length; i++) {
                string newWord = ValidateSmallWords(words[i]);

                if (newWord.Length <= 2 || words[i].Length == 3)
                    restructuredWord = newWord;                
                else {
                    var arrayLetters = newWord.Distinct().ToArray();
                    restructuredWord = $"{ words[i].Substring(0, 1) }{ arrayLetters.Length }{ words[i].Substring(words[i].Length - 1, 1) }";
                }

                result = result + restructuredWord + (separators.Count != i ? separators[i] : "");
            }
            
            return result;
        }

        private static string ValidateSmallWords(string word) {
            if (word.Length <= 2) 
                return word;
            else if (word.Length == 3)
                return $"{ word.Substring(0, 1) }1{ word.Substring(word.Length - 1, 1) }";
            else           
                return word.Substring(1, word.Length - 2);
        }

    }
}
