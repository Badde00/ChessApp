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
            Boolean validMove = pawn.IsValidMove(1, 1, board);
        
            // Then
            Assert.True(validMove);
        }
    }
}