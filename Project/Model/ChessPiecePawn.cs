using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessApp.Model
{
    public class ChessPiecePawn : ChessPiece
    {
        public Boolean IsWhite { get; }
        public int[] Pos { get; set; }
        public int[] PrevPos { get; set; }


        public ChessPiecePawn(Boolean isWhite, int[] pos)
        {
            this.IsWhite = isWhite;
            if (pos.Length != 2) {
                throw new ArgumentException("Invalid position");
            }
            this.Pos = pos;
            this.PrevPos = pos;
        }

        public Boolean IsValidMove(int x, int y, ChessPiece[,] board)
        {
            ChessPiece targetPiece = board[x, y];
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
                int targetY = this.Pos[1] > y ? this.Pos[1] - 1 : this.Pos[1] + 1;
                targetPiece = board[this.Pos[0], targetY];

                if (targetPiece != null
                    && targetPiece is ChessPiecePawn
                    && targetPiece.PrevPos[0] == (this.IsWhite ? 6 : 1) // Target pawn started at its original row
                    && targetPiece.IsWhite != this.IsWhite // Previous color check didn't check for pieces in places it doesn't land
                    ) {
                        return true;
                    }
            }

            return false;
        }

        public void Move(int[] position) {
            this.PrevPos = Pos;
            this.Pos = position;
        }


        private Boolean IsForward(int targetY) {
            return this.IsWhite ? targetY > this.Pos[1] : targetY < this.Pos[1];
        }

        private Boolean IsOneForward(int targetY) {
            return IsForward(targetY) && Math.Abs(targetY - this.Pos[1]) == 1;
        }
    }
}