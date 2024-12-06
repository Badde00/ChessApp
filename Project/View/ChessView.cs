using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Model;

namespace Project.View
{
    public class ChessView
    {
        public void PrintBoard(ChessPiece?[,] board) {
            Console.WriteLine("  a b c d e f g h"); // Column labels
            for (int y = 7; y >= 0; y--) {
                Console.Write($"{y + 1} ");
                for (int x = 0; x < 8; x++) {
                    ChessPiece? piece = board[x, y];
                    if (piece != null) {
                        Console.Write(piece.ToStringChar() ?? ".");
                    } else {
                        Console.Write(".");
                    }
                    Console.Write(" ");
                }
                Console.Write($" {y + 1}");
                System.Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            System.Console.WriteLine();
        }

        public (int x1, int y1, int x2, int y2, string? specialMove) TranslateNotation(string notation) {
            //TODO: Verify input format via regex
            string[] splitNumAndNotation = notation.Split(".");
            if (notation.Contains("0-0") || notation.Contains("O-O")) {
                if (int.Parse(splitNumAndNotation[0]) % 2 == 1) {// White moves
                    return (0, 4, 0, 2, "Kingside Castle");
                } else { // Black moves
                    return (7, 4, 7, 2, "Kingside Castle");
                }
            }
            if (notation.Contains("0-0-0") || notation.Contains("O-O-O")) {
                if (int.Parse(splitNumAndNotation[0]) % 2 == 1) {// White moves
                    return (0, 4, 0, 6, "Queenside Castle");
                } else { // Black moves
                    return (7, 4, 7, 6, "Queenside Castle");
                }
            }


            throw new NotImplementedException();
        }
    }
}