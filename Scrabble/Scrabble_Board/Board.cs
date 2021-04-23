using System;
using System.Collections.Generic;

namespace Scrabble_Board
{
    class Board
    {
        public Stack<Tile> TilePile { get; set; }

        private const int ROW_SIZE = 15;
        private const int COL_SIZE = 15;
        
        private Tile[,] tiles;

        public Board() 
        {
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
        
        //https://en.wikipedia.org/wiki/Scrabble_letter_distributions
        private void MakePile() 
        {
            TilePile = new Stack<Tile>();
            for (int i = 0; i < 12; i++) TilePile.Push(new Tile('E'));
            for (int i = 0; i < 9; i++) {
                TilePile.Push(new Tile('A'));
                TilePile.Push(new Tile('I'));
            }
            for (int i = 0; i < 8; i++) TilePile.Push(new Tile('O'));
            for (int i = 0; i < 6; i++) {
                TilePile.Push(new Tile('N'));
                TilePile.Push(new Tile('R'));
                TilePile.Push(new Tile('T'));
            }
            for (int i = 0; i < 4; i++) {
                TilePile.Push(new Tile('L'));
                TilePile.Push(new Tile('S'));
                TilePile.Push(new Tile('U'));
                TilePile.Push(new Tile('D'));
            }
            for (int i = 0; i < 2; i++) {
                TilePile.Push(new Tile('B'));
                TilePile.Push(new Tile('C'));
                TilePile.Push(new Tile('M'));
                TilePile.Push(new Tile('P'));
                TilePile.Push(new Tile('F'));
                TilePile.Push(new Tile('H'));
                TilePile.Push(new Tile('V'));
                TilePile.Push(new Tile('W'));
                TilePile.Push(new Tile('Y'));
            }
            TilePile.Push(new Tile('K'));
            TilePile.Push(new Tile('J'));
            TilePile.Push(new Tile('X'));
            TilePile.Push(new Tile('Q'));
            TilePile.Push(new Tile('Z'));
        }
    }
}