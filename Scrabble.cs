using System;
using System.Collections.Generic;
using Scrabble_Board;
using Scrabble_Player;

class ScrabbleMain 
{
    static void Main(string[] args) 
    {
        Board GameBoard = new Board();
        Player Thinker = new Player(true);

        Thinker.PlayMove(GameBoard);   
    }   
}