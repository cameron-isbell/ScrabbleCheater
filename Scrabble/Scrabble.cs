using System;
using System.Collections.Generic;
using Board;

namespace Scrabble
{
    class ScrabbleMain 
    {
        static Dictionary<char,int> LetterValLUT;

        static void Main(string[] args) 
        {
            Board GameBoard = new Board();

            string letters = Console.ReadLine();
            Tile[] Word = GetHighestValue(letters);   
        }
        
        static Tile[] GetHighestValue(string letters) 
        {
            System.IO.StreamReader Dict = new System.IO.StreamReader("Scrabble/dictionary.txt");
 
            if (letters.Length > 8 || letters.Length < 1) {
                Console.WriteLine("INVALID CHARACTER AMOUNT");
                return null;
            }

            List<string> perms = Permutations.Start(letters);
            List<string> match = new List<string>();
            
            //removing duplicates
            foreach (string s in perms) {
                //delete all occurrences, then add one back in
                string temp = s;
                perms.RemoveAll(s);
                perms.Add(temp);
            }
            
            //Reading from dictionary
            string line; 
            foreach (string s in perms) {
                while ((line = Dict.ReadLine()) != null) {
                    //not yet at correct first letter, continue
                    if (line[0] < s[0]) continue;

                    //we've passed the range of characters, stop searching
                    if (line[0] > s[0]) break;
                    
                    int len = (line.Length < s.Length) ? line.Length : s.Length;
                    string comp = s.Substring(0, len);
                    if (String.Equals(comp, line)) match.Add(line);
                }
            }
            Dict.Close();
            
            //highest value string, value
            Tuple<string, int> Max = new Tuple<string, int>("", 0);

            foreach(string s in match) {
                int sum = 0; 
                foreach(char c in s) {
                    Tile CurTile = new Tile(c); 
                    sum += CurTile.Val;
                }
                if (sum > Max.Item2) Max = new Tuple<string, int>(s, sum);
            }

            Tile[] Word = new Tile[];
            for (int i = 0; i < Max.Item1.Length; i++) {
                Tile[i] = new Tile(Max.Item1[i]);
            }

            return Word;
        }
    }
}

