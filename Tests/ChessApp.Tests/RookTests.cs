using Project.Model;

namespace ChessApp.Tests
{
    public class RookTests
    {
        [Fact]
        public void RookCannotMoveToSameSpace()
        {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = rook.IsValidMove(0, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void RookCannotMoveDiagnoally()
        {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = rook.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        [InlineData(7, 0)]
        public void RookCanMoveHorizontally(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = rook.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        public void RookCanMoveHorizontally_inverse(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [7, 0]);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = rook.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        [InlineData(7, 0)]
        public void WhiteRookMovesHorizontallyWithWhitePieceInTheWaySometimes(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [0, 5]);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = rook.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            if (targetY < 5) {
                Assert.True(validMove);
            } else {
                Assert.False(validMove);
            }
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(5, 0)]
        [InlineData(6, 0)]
        [InlineData(7, 0)]
        public void WhiteRookMovesHorizontallyWithBlackPieceInTheWaySometimes(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [0, 5]);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = rook.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            if (targetY <= 5) {
                Assert.True(validMove);
            } else {
                Assert.False(validMove);
            }
        }
    }
}