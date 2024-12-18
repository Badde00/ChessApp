using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ChessPiecePawn(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {
        public override bool IsValidMove(int x, int y, ChessPiece?[,] board)
        {
            ChessPiece? targetPiece = board[x, y];
            // Cannot land on a square with a piece of your color
            if (targetPiece != null && targetPiece.IsWhite == this.IsWhite) {
                return false;
            }

            // Can capture a piece if it is one square diagonally forward
            if (targetPiece != null && this.IsOneForward(y) && Math.Abs(this.Pos[0] - x) == 1) {
                return true;
            }

            // Can move one square forward if it doesn't capture
            if (targetPiece == null && this.IsOneForward(y) && Math.Abs(this.Pos[0] - x) == 0) {
                return true;
            }

            // Can move two squares forward if it doesn't capture anything, is the first move and there is no piece in between the positions
            if (this.IsForward(y)
                && Math.Abs(this.Pos[1] - y) == 2
                && Math.Abs(this.Pos[0] - x) == 0
                && targetPiece == null
                && this.Pos.Equals(this.PrevPos)) {
                    // Calculate middle position
                    int midY = this.IsWhite ? this.Pos[1] + 1 : this.Pos[1] - 1;

                    // Check if there is a piece in the middle position
                    if (board[this.Pos[0], midY] == null) {
                        return true;
                    }
                    return false;
            }

            // En passant: Can capture a piece behind the landing spot if it is a pawn that just moved two squares forward and this pawn moved diagonally to get there
            if (targetPiece == null
                && this.IsOneForward(y)
                && Math.Abs(this.Pos[0] - x) == 1) {
                targetPiece = board[x, this.Pos[1]]; // If the target piece is to the pawns side, then the y value of the target is the same as this pawn, and the x value is the same as where you're trying to move

                if (targetPiece != null
                    && targetPiece is ChessPiecePawn
                    && targetPiece.PrevPos[1] == (this.IsWhite ? 6 : 1) // Target pawn started at its original row
                    && targetPiece.IsWhite != this.IsWhite // Previous color check didn't check for pieces in places it doesn't land
                    ) {
                        return true;
                    }
            }

            return false;
        }


        private Boolean IsForward(int targetY) {
            return this.IsWhite ? targetY > this.Pos[1] : targetY < this.Pos[1];
        }

        private Boolean IsOneForward(int targetY) {
            return IsForward(targetY) && Math.Abs(targetY - this.Pos[1]) == 1;
        }
    }
}