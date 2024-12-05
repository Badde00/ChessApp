using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ChessPieceBishop(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {
        public override bool IsValidMove(int x, int y, ChessPiece[,] board) {
            // Checks that movement is diagonal and non-zero
            if (Math.Abs(this.Pos[0] - x) == Math.Abs(this.Pos[1] - y) && this.Pos[0] != x) {
                int movementX = x > this.Pos[0] ? 1 : -1;
                int movementY = y > this.Pos[1] ? 1 : -1;

                // Checks the squares between the current square and the target square if there's a piece in the way.
                for (int ix = this.Pos[0] + movementX; ix != x; ix += movementX) {
                    for (int iy = this.Pos[1] + movementY; iy != y; iy += movementY) {
                        // If there's a piece in the way, return false
                        if (board[ix, iy] != null) {
                            return false;
                        }
                    }
                }

                // Check that if there's a piece on the target square, it has to be a different color.
                ChessPiece targetPiece = board[x, y];
                if (targetPiece != null) {
                    if (targetPiece.IsWhite != this.IsWhite) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return true;
                }
            }


            return false;
        }
    }
}