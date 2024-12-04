using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; }

        public ChessBoard()
        {
            Board = new ChessPiece[8, 8];
        }

        public Boolean AddPieceToBoard(ChessPiece p) {
            if (p == null) {
                throw new Exception(); // TODO: specify exception
            }
            if (Board[p.Pos[0], p.Pos[1]] != null) {
                return false;
            } else {
                Board[p.Pos[0], p.Pos[1]] = p;
                return true;
            }
        }
    }
}