using System;

namespace Scrabble_Board
{
    class Board
    {
        private const int rowLen = 15;
        private Tile[,] tiles;

        public Board() 
        {
            tiles = new Tile[rowLen, rowLen];
            //TODO: implement modifiers
            for (int i = 0; i < rowLen; i++) {
                for (int j = 0; j < rowLen; j++) {
                    tiles[i, j] = new Tile();
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            if (x > rowLen || y > rowLen) return null;
            return tiles[x, y];
        }

        public void SetTile(int x, int y, Tile t) 
        {
            if (x > rowLen || y > rowLen) return;
            tiles[x, y] = t;
        }

    }
}