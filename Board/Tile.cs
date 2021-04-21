using System;
using System.Collections.Generic;

namespace Board 
{
    /**
        A tile of the scrabble board
    */
    class Tile
    {
        private Dictionary<char, int> LetterVals;

        public int Val      { get; set; }
        public int Modifier { get; set; }
        public char Letter  { get; set; }
        public bool Empty   { get; set; }

        public Tile() 
        {
            Init();
            Val = 0;
            Letter = ' ';
            Modifier = 1;
            Empty = true;
        }

        public Tile(char Letter) 
        {
            Init();
            this.Letter = Letter;
            this.Empty = false;
            Val = LetterVals[Letter];
        }

        private void Init() {
            LetterVals = new Dictionary<char,int>()
            {
                {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4},
                {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1},
                {'M', 3}, {'N', 1}, {'O', 1}, {'P', 3}, {'Q', 10}, {'R', 1},
                {'S', 1}, {'T', 1}, {'U', 1}, {'V', 4}, {'W', 4}, {'X', 8},
                {'Y', 4}, {'Z', 10}
            };
        }
    }
}