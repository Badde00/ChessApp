using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessApp.Model
{
    public class ChessBoard
    {
        private ChessPiece[,] board;

        public ChessBoard()
        {
            board = new ChessPiece[8, 8];
        }
    }
}