using ChessApp.Model;

namespace ChessApp.Tests
{
    public class PawnTests
    {
        [Fact]
        public void PawnCanMoveOneForward()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 2, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveOneForwardWhenWhitePieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(true, [0, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [0, 2]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void PawnCannotMoveOneToTheSide()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}