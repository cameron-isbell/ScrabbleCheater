using System;
using System.Collections.Generic;

namespace Scrabble
{
    class ScrabbleMain 
    {
        static Dictionary<char,int> LetterValLUT;

        static void Main(string[] args) 
        {
            LetterValLUT = new Dictionary<char,int>()
            {
                {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4},
                {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1},
                {'M', 3}, {'N', 1}, {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1},
                {'S', 1}, {'T', 1}, {'U', 1}, {'V', 4}, {'W', 4}, {'X', 8},
                {'Y', 4}, {'Z', 10}
            };
            while (true) {
                string letters = Console.ReadLine();
                string word = GetHighestValue(letters);
            }
        }
        
        static string GetHighestValue(string letters) 
        {
            //TODO: use thread for this
            System.IO.StreamReader dict = new System.IO.StreamReader("Scrabble/dictionary.txt");
            
            //max value, string corresponding to it
            Tuple<string, int> max = new Tuple<string, int>("", 0);
 
            if (letters.Length > 8 || letters.Length < 1) {
                Console.WriteLine("INVALID CHARACTER AMOUNT");
                return null;
            }

            List<string> perms = Permutations.Start(letters);
            List<string> match = new List<string>();
            
            //Reading from dictionary
            string word; 
            while ((word = dict.ReadLine()) != null) {
                foreach (string s in perms) {
                    int len = (word.Length > s.Length) ? s.Length : word.Length;
                    string comp = s.Substring(0, len);
                    if (String.Equals(comp, word)) {
                        match.Add(word);
                    }
                }
            }

            foreach(string s in match) {
                int sum = 0; 
                foreach(char c in s) sum += LetterValLUT[c];
                if (sum > max.Item2) max = new Tuple<string, int>(s, sum);

                Console.WriteLine("possible {0}", s);
            }
            Console.WriteLine("str {0} val {1}", max.Item1, max.Item2);

            return max.Item1;
        }
    }
}

