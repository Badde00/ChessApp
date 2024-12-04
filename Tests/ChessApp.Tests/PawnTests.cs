using ChessApp.Model;

namespace ChessApp.Tests
{
    public class PawnTests
    {
        [Fact]
        public void PawnCanMoveOneForward()
        {
            // Given
            ChessPiece[,] board = new ChessPiece[8,8];
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board[0,1] = pawn;
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 2, board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveOneForwardWhenWhitePieceStandsOnTarget()
        {
            // Given
            ChessPiece[,] board = new ChessPiece[8,8];
            ChessPiece pawn1 = new ChessPiecePawn(true, [0, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [0, 2]);
            board[0, 1] = pawn1;
            board[0, 2] = pawn2;
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 1, board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void PawnCannotMoveOneToTheSide()
        {
            // Given
            ChessPiece[,] board = new ChessPiece[8,8];
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board[0,1] = pawn;
        
            // When
            Boolean validMove = pawn.IsValidMove(1, 1, board);
        
            // Then
            Assert.False(validMove);
        }
    }
}