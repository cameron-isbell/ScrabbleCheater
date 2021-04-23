using System;
using System.Collections.Generic;
using Scrabble_Board;

namespace Scrabble_Player 
{
    class Player
    {
        private const int MAX_LETTERS = 8;
        public bool IsAI { get; }
        //private string[] dict;

        public Player(bool IsAI) 
        {
            this.IsAI = IsAI;
            //dict = System.IO.File.ReadAllLines("Player/dictionary.txt");
        }

        public void PlayMove(Board GameBoard)
        {
            if (!IsAI) {
                return;
            }
            else {
                Tile[] word = GetHighestValue();
                foreach(Tile t in word) {
                    Console.Write(t.Letter);
                }
                //GameBoard.Place();
            }
        }

        private Tile[] GetHighestValue()
        {
            System.IO.StreamReader dict = new System.IO.StreamReader("Player/dictionary.txt");
 
            //TODO: PULL TILES
            string letters = "abcdefgh";
            if (letters.Length > MAX_LETTERS || letters.Length < 1) {
                Console.WriteLine("INVALID CHARACTER AMOUNT");
                return null;
            }

            List<string> perms = Permutations.Start(letters);
            List<string> match = new List<string>();

            //TODO: removing duplicates
            // foreach (string s in perms) {
            //     //delete all occurrences, then add one back in
            //     string temp = s;
            //     perms.RemoveAll(s);
            //     perms.Add(temp);
            // }

            //Reading from dictionary
            //TODO: BINARY SEARCH 
            string line; 
            foreach (string s in perms) {
                while ((line = dict.ReadLine()) != null) {
                    //not yet at correct first letter, continue
                    if (line[0] < s[0]) continue;

                    //we've passed the range of characters, stop searching
                    if (line[0] > s[0]) break;
                    
                    int len = (line.Length < s.Length) ? line.Length : s.Length;
                    string comp = s.Substring(0, len);
                    if (String.Equals(comp, line)) match.Add(line);
                }
            }
            dict.Close();
            
            //highest value string, value
            Tuple<Tile[], int> Max = new Tuple<Tile[], int>(new Tile[MAX_LETTERS], 0);

            foreach(string s in match) {
                int sum = 0; 
                Tile[] curWord = new Tile[MAX_LETTERS];
                for(int i = 0; i < s.Length; i++) {
                    curWord[i] = new Tile(s[i]); 
                    sum += curWord[i].Val;
                }
                if (sum > Max.Item2) Max = new Tuple<Tile[], int>(curWord, sum);
            }

            return Max.Item1;
        }
    }
}