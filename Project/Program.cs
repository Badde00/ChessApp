using System;
using ChessApp.Model;

namespace ChessApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ChessApp!");

      ChessBoard board = new();
      ChessPiece pawn = new ChessPiecePawn(false, [0, 6]);
      board.AddPieceToBoard(pawn);
      
      Boolean validMove = pawn.IsValidMove(1, 5, board.Board);
      System.Console.WriteLine(validMove);
    }
  }
}
