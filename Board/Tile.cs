using System;

namespace Board 
{
    class Tile
    {
        public int Val { get; set; }
        public int Modifier { get; set; }
        public char Letter { get; set; }
        public bool Empty { get; set; }

        public Tile() 
        {
            Val = 0;
            Letter = ' ';
            Modifier = 1;
            Empty = true;
        }

        public Tile(char Letter, int Val, int Modifier) {
            this.Letter = Letter;
            this.Val = Val;
            this.Modifier = Modifier;
            this.Empty = false;
        }
    }
}