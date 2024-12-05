using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ChessPieceKnight(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {
        public override bool IsValidMove(int x, int y, ChessPiece[,] board)
        {
            int deltaX = Math.Abs(this.Pos[0] - x);
            int deltaY = Math.Abs(this.Pos[1] - y);
            if ((deltaX == 2 && deltaY == 1) || (deltaX == 1 && deltaY == 2)) {
                ChessPiece targetPiece = board[x, y];
                if (targetPiece == null) {
                    return true;
                } else {
                    if (targetPiece.IsWhite != this.IsWhite) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}