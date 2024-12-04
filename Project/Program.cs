using System;
using Project.Model;

namespace Project
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ChessApp!");

      ChessBoard board = new();
      ChessPiece rook = new ChessPieceRook(true, [3, 3]);
      board.AddPieceToBoard(rook);
      
      Boolean validMove = rook.IsValidMove(3, 3, board.Board);
      System.Console.WriteLine(validMove);
    }
  }
}
