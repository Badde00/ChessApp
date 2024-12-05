using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public class ChessPieceKing(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {
        public override bool IsValidMove(int x, int y, ChessPiece?[,] board)
        {
            ChessPiece? targetPiece = board[x, y];
            if (targetPiece != null) { // Check if square landed on is empty
                // If it isn't, check if it's a piece you can capture
                if (targetPiece.IsWhite == this.IsWhite) {
                    return false; // If you can't, you can't move there
                }
            }

            // Check if it moves only one squre
            if (Math.Abs(this.Pos[0] - x) <= 1 && Math.Abs(this.Pos[1] - y) <= 1 && Math.Abs(this.Pos[0] - x) + Math.Abs(this.Pos[1] - y) > 0) {
                if (IsTargetSquareThreatened(x, y, board)) {
                    return false;
                } else {
                    return true;
                }
            } else if (this.Pos.Equals(this.PrevPos) && (x == 6 || x == 2) && this.Pos[1] == y) { // Trying to castle
                ChessPiece? possibleRook = board[x == 6 ? 7 : 0, this.IsWhite ? 0 : 7];
                if (possibleRook != null) {
                    if (possibleRook is ChessPieceRook && possibleRook.Pos.Equals(possibleRook.PrevPos)) {
                        // TODO: Check if pieces that king moves through are empty and not threatened
                        ChessPiece? middlePiece = board[x == 6 ? 5 : 3, this.IsWhite ? 0 : 7];
                        if (middlePiece != null) { // Can't castle with pieces in between
                            return false;
                        } else { // If no piece in middle, check if that square is threatened
                            bool middleIsThreatened = IsTargetSquareThreatened(x == 6 ? 5 : 3, this.IsWhite ? 0 : 7, board);
                            if (!middleIsThreatened) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private List<ChessPiece> RetrieveAllPiecesOfOppositeColor(ChessPiece?[,] board) {
            List<ChessPiece> pieces = [];
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 8; y++) {
                    if (board[x, y] != null) {
                        if (board[x, y]!.IsWhite != this.IsWhite) {
                            pieces.Add(board[x, y]!);
                        }
                    }
                }
            }
            return pieces;
        }

        private bool IsTargetSquareThreatened(int x, int y, ChessPiece?[,] board) {
            ChessPiece?[,] boardCopy = (ChessPiece?[,])board.Clone();
            boardCopy[this.Pos[0], this.Pos[1]] = null;
            boardCopy[x, y] = this;
            List<ChessPiece> pieces = RetrieveAllPiecesOfOppositeColor(boardCopy);

            foreach(ChessPiece? piece in pieces) {
                if (piece != null) {
                    if (piece.IsValidMove(x, y, boardCopy)) {
                        if(piece is not ChessPiecePawn) { // Pawns can move where they cannot capture, so need to take that into consideration
                            return true;
                        } else {
                            if (piece.Pos[0] != x) { // If the pawn currently has a different x value than the square the king moves to, then that means the pawn can capture.
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}