using System;
using System.Windows.Forms;
using Scrabble_Board;
using Scrabble_Player;
using Scrabble_Graphics;

class ScrabbleMain 
{
    static void Main(string[] args) 
    {
        Board game = new Board();
        DrawBoard.Draw( game);
        // Board GameBoard = new Board();
        // Player Thinker = new Player(true);

        // Thinker.PlayMove(GameBoard);
    }   
}