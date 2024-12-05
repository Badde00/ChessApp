using Project.Model;

namespace Project
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ChessApp!");

      ChessBoard board = new();
      ChessPiece rook = new ChessPieceRook(true, [0, 0]);
      ChessPiece pawn = new ChessPiecePawn(true, [0, 5]);
      board.AddPieceToBoard(rook);
      board.AddPieceToBoard(pawn);
      
      Boolean validMove = rook.IsValidMove(0, 6, board.Board);
      Console.WriteLine(validMove);
    }
  }
}
