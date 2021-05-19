using System;
using System.Collections.Generic;
using Scrabble_Board;

namespace Scrabble_Player 
{
    class Player
    {
        private const int MAX_LETTERS = 8;
        private string[] AllDictWords;

        public bool IsAI { get; }
        public List<Tile> Inventory { get; }

        public Player(bool IsAI) 
        {
            Inventory = new List<Tile>();
            this.IsAI = IsAI;
            AllDictWords = System.IO.File.ReadAllLines("Scrabble/Scrabble_Player/dictionary.txt");
        }

        public void PlayMove(Board gameBoard)
        {
            PullTiles(gameBoard);
            if (!IsAI) {
                
            }
            else {
                Tile[] word = GetHighestValue();
            }
        }

        private void PullTiles(Board gameBoard) 
        {
            while (Inventory.Count < MAX_LETTERS) {
                Tile NewTile = gameBoard.PopPile();
                if (NewTile == null) break;
                Inventory.Add(NewTile);
            }        
        }

        private Tile[] GetHighestValue()
        {
            string letters = "";
            foreach (Tile t in Inventory) {
                letters += t.Letter;
            }

            //find all permutations of the letters pulled
            List<string> perms = Permutations.Start(letters);

            List<string> fullPerms = new List<string>();

            //Create substrings from each permutation
            foreach(string s in perms) {
                //Check each substring
                string check = "";
                foreach (char c in s) {
                    check += c;
                    fullPerms.Add(check);
                }
            }

            //all words sorted. used later to remove duplicate items
            string[] sorted = HeapSort.Sort(fullPerms);

            //holds all words we find in the dictionary with our set of letters
            List<string> match = new List<string>();

            //duplicate items will be next to each other when sorted. skip duplicates
            for (int i = 0; i < sorted.Length; i++) {
                if (BinSearchDict(sorted[i], 0, AllDictWords.Length)) match.Add(sorted[i]);
                while (!(i+1 > sorted.Length-1) && sorted[i] == sorted[i+1]) i++;
            }

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