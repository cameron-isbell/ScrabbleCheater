using System;
using System.Collections.Generic;
using Scrabble_Board;

namespace Scrabble_Player 
{
    class Player
    {
        private const int MAX_LETTERS = 8;
        public bool IsAI { get; }
        private string[] AllDictWords;

        public Player(bool IsAI) 
        {
            this.IsAI = IsAI;
            AllDictWords = System.IO.File.ReadAllLines("Scrabble_Player/dictionary.txt");
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
            }
        }

        private Tile[] GetHighestValue()
        {
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


            //Check each permutation
            foreach(string s in perms) {
                //Check each substring
                string check = "";
                foreach (char c in s) {
                    check += c;
                    if (BinSearchDict(check, AllDictWords.Length/2)) match.Add(check);
                }
            }
            
            BinSearchDict("pass", AllDictWords.Length/2);
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

        /*
            @param find: string representing the data the binary search is searching for
            @param pivot: the index to pivot left and right check around
        */
        private bool BinSearchDict(string find, int pivot)
        {          
            //check left/right depending on preceeding or suceeding
            if (find.CompareTo(AllDictWords[pivot]) < 0) {
                BinSearchDict(find, pivot/2);
            }
            else if (find.CompareTo(AllDictWords[pivot]) > 0) {
                BinSearchDict(find, pivot + (pivot/2));
            }
            else if (find == AllDictWords[pivot]) return true;
            
            return false;
        }
    }
}