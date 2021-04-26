using System;
using System.Collections;
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
            AllDictWords = System.IO.File.ReadAllLines("Scrabble/Scrabble_Player/dictionary.txt");
        }

        public void PlayMove(Board GameBoard)
        {
            if (!IsAI) {
                return;
            }
            else {
                Tile[] word = GetHighestValue();
            }
        }

        private Tile[] GetHighestValue()
        {
            //TODO: PULL TILES
            string letters = "azpclunk";
            if (letters.Length > MAX_LETTERS || letters.Length < 1) {
                Console.WriteLine("INVALID CHARACTER AMOUNT");
                return null;
            }

            List<string> perms = Permutations.Start(letters);
            List<string> match = new List<string>();

            // string[] DEBUG = {"aba", "ong", "ial", "xnz", "azb", "jal"};
            // List<string> DEBUG_LIST = new List<string>(DEBUG);

            //Check each permutation
            foreach(string s in perms) {
                //Check each substring
                string check = "";
                foreach (char c in s) {
                    check += c;
                    if (BinSearchDict(check, 0, AllDictWords.Length)) match.Add(check);
                }
            }

            //remove duplicates from match. don't waste time processing already checked strings
            List<string> noDupes = new List<string>();
            string[] sorted = HeapSort.Sort(match);
            for (int i = 0; i < sorted.Length; i++) {
                noDupes.Add(sorted[i]);
                while ( !(i+1 >= sorted.Length) && sorted[i] == sorted[i+1]) i++;
            }

            //highest value string, value
            Tuple<Tile[], int> Max = new Tuple<Tile[], int>(new Tile[MAX_LETTERS], 0);

            foreach(string s in noDupes) {
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
        private bool BinSearchDict(string find, int low, int high)
        {        
            int pivot = low + (high - low) / 2;
            string comp = AllDictWords[pivot];

            //check left/right depending on preceeding or seceding
            if (find == comp) {
                return true;
            }
            //not the same and no more indices to search, not found
            else if (high <= low) {
                return false;
            }
            else if (find.CompareTo(comp) < 0) {
                return BinSearchDict(find, low, pivot-1);
            }
            else if (find.CompareTo(comp) > 0) {
                return BinSearchDict(find, pivot+1, high);
            }

            return false;
        }
    }
}