
using Project.Model;

namespace ChessApp.Tests
{
    public class BishopTests
    {
        [Fact]
        public void BishopCannotMoveToSameSpace()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [0, 0]);
            board.AddPieceToBoard(bishop);
        
            // When
            bool validMove = bishop.IsValidMove(0, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}