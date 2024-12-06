using Project.Model;
using Project.View;

namespace Project
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to ChessApp!");

      ChessBoard board = new();
      ChessView view = new();

      view.PrintBoard(board.Board);
    }
  }
}
