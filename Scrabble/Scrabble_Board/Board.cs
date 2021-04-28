using System;
using System.Collections.Generic;

namespace Scrabble_Board
{
    class Board
    {
        private Stack<Tile> TilePile;

        private const int ROW_SIZE = 15;
        private const int COL_SIZE = 15;
        
        private Tile[,] tiles;

        public Board() 
        {
            MakePile();
            tiles = new Tile[ROW_SIZE, ROW_SIZE];
            //TODO: implement modifiers
            for (int i = 0; i < ROW_SIZE; i++) {
                for (int j = 0; j < ROW_SIZE; j++) {
                    tiles[i, j] = new Tile();
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            if (x > ROW_SIZE || y > ROW_SIZE) return null;
            return tiles[x, y];
        }

        public void SetTile(int x, int y, Tile t) 
        {
            if (x > ROW_SIZE || y > ROW_SIZE) return;
            tiles[x, y] = t;
        }

        public Tile PopPile() {
            return TilePile.Pop();
        }
        
        //https://en.wikipedia.org/wiki/Scrabble_letter_distributions
        private void MakePile() 
        {
            List<Tile> BasePile = new List<Tile>();

            for (int i = 0; i < 12; i++) BasePile.Add(new Tile('E'));
            for (int i = 0; i < 9; i++) {
                BasePile.Add(new Tile('A'));
                BasePile.Add(new Tile('I'));
            }
            for (int i = 0; i < 8; i++) BasePile.Add(new Tile('O'));
            for (int i = 0; i < 6; i++) {
                BasePile.Add(new Tile('N'));
                BasePile.Add(new Tile('R'));
                BasePile.Add(new Tile('T'));
            }
            for (int i = 0; i < 4; i++) {
                BasePile.Add(new Tile('L'));
                BasePile.Add(new Tile('S'));
                BasePile.Add(new Tile('U'));
                BasePile.Add(new Tile('D'));
            }
            for (int i = 0; i < 3; i++) BasePile.Add(new Tile('G'));
            for (int i = 0; i < 2; i++) {
                BasePile.Add(new Tile('B'));
                BasePile.Add(new Tile('C'));
                BasePile.Add(new Tile('M'));
                BasePile.Add(new Tile('P'));
                BasePile.Add(new Tile('F'));
                BasePile.Add(new Tile('H'));
                BasePile.Add(new Tile('V'));
                BasePile.Add(new Tile('W'));
                BasePile.Add(new Tile('Y'));
            }
            BasePile.Add(new Tile('K'));
            BasePile.Add(new Tile('J'));
            BasePile.Add(new Tile('X'));
            BasePile.Add(new Tile('Q'));
            BasePile.Add(new Tile('Z'));

            TilePile = ShuffleTiles(BasePile);
        }

        //Fisher-Yates https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        private Stack<Tile> ShuffleTiles(List<Tile> Shuffle) 
        {
            Random r = new Random();
            for (int i = Shuffle.Count-1; i > 0; i--) {
                int j = r.Next(0, i);
                Tile temp = Shuffle[i];
                Shuffle[i] = Shuffle[j];
                Shuffle[j] = temp;
            }
            return new Stack<Tile>(Shuffle);
        }
    }
}