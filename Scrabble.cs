using System;
using System.Collections;

namespace Scrabble
{
    class ScrabbleMain { 
        static void Main (string[] args) {
            System.IO.StreamReader dict = new System.IO.StreamReader("dictionary.txt");
            while (true) {
                string letters = Console.ReadLine();  
                if (letters.Length > 8 || letters.Length < 1) {
                    Console.WriteLine("INVALID CHARACTER AMOUNT");
                    continue;
                }

                ArrayList perms = Permutations.Start(letters);
                ArrayList match = new ArrayList();

                //Reading from dictionary
                string word; 
                while ((word = dict.ReadLine()) != null) {
                    foreach (string s in perms) {
                        int len = (word.Length > s.Length) ? s.Length : word.Length;
                        string comp = s.Substring(0, len);
                        if (String.Equals(comp, word)) {
                            Console.WriteLine(word);
                            match.Add(word);
                            Console.WriteLine(match.Count);
                        }                 
                    }
                }    
                break;     
            }
            
        }
    }
}

