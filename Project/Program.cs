using Project.Model;

namespace Project
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ChessApp!");

      ChessBoard board = new();
      ChessPiece king = new ChessPieceKing(true, [4, 0]);
      ChessPiece rook = new ChessPieceRook(true, [0, 0]);
      board.AddPieceToBoard(king);
      board.AddPieceToBoard(rook);
      
      bool validMove = king.IsValidMove(2, 0, board.Board);
      Console.WriteLine(validMove);
    }
  }
}
