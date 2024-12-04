using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessApp.Model
{
    public interface ChessPiece
    {
        Boolean IsWhite { get; }
        int[] Pos { get; set; }
        int[] PrevPos { get; set; }
        Boolean IsValidMove(int x, int y, ChessPiece[,] board);

        void Move(int[] location);
    }
}