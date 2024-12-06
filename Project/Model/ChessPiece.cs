using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Model
{
    public abstract class ChessPiece
    {
        public bool IsWhite { get; }
        public int[] Pos { get; set; }
        public int[] PrevPos { get; set; }

        protected ChessPiece(bool isWhite, int[] pos)
        {
            IsWhite = isWhite;
            if (pos.Length != 2) {
                throw new ArgumentException("Invalid position");
            }
            Pos = pos;
            PrevPos = pos;
        }

        public abstract bool IsValidMove(int x, int y, ChessPiece?[,] board);

        public void Move(int[] position) {
            this.PrevPos = Pos;
            this.Pos = position;
        }

        public string ToStringChar() {
            return this switch {
                ChessPiecePawn => IsWhite ? "♙" : "♟",
                ChessPieceRook => IsWhite ? "♖" : "♜",
                ChessPieceKnight => IsWhite ? "♘" : "♞",
                ChessPieceBishop => IsWhite ? "♗" : "♝",
                ChessPieceQueen => IsWhite ? "♕" : "♛",
                ChessPieceKing => IsWhite ? "♔" : "♚",
                _ => " " // Empty square
            };
        }
    }
}