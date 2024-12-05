using Project.Model;

namespace ChessApp.Tests
{
    public class QueenTests
    {
        [Fact]
        public void RookCannotMoveToSameSpace()
        {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(0, 0, board.Board);
        
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
        public void QueenCanMoveHorizontally(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
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
        public void QueenCanMoveHorizontally_Inverse(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [7, 0]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(0, 5)]
        [InlineData(0, 6)]
        [InlineData(0, 7)]
        public void QueenCanMoveVertically(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(0, 5)]
        [InlineData(0, 6)]
        public void QueenCanMoveVertically_Inverse(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 7]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
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
        public void WhiteQueenMovesHorizontallyWithWhitePieceInTheWaySometimes(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [0, 5]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
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
        public void WhiteQueenMovesHorizontallyWithBlackPieceInTheWaySometimes(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [0, 5]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            if (targetY <= 5) {
                Assert.True(validMove);
            } else {
                Assert.False(validMove);
            }
        }
        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(2, 4)]
        [InlineData(4, 2)]
        [InlineData(7, 7)]
        public void QueenCanMoveDiagnoally(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [3, 3]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void QueenCannotMoveDiagonallyWithPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [1, 1]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(2, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void QueenCannotMoveHorizontallyWithPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(0, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void QueenCannotMoveVerticallyWithPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [1, 0]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(2, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Theory]
        [InlineData(2, 5)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(5, 2)]
        [InlineData(4, 1)]
        [InlineData(2, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 4)]
        public void QueenCannotMoveInLShape(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [3, 3]);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(2, 2)]
        [InlineData(4, 2)]
        [InlineData(2, 4)]
        [InlineData(2, 3)]
        [InlineData(3, 2)]
        [InlineData(3, 4)]
        public void WhiteQueebCanCaptureBlackPiece(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece queen = new ChessPieceQueen(true, [3, 3]);
            ChessPiece pawn = new ChessPiecePawn(false, [targetX, targetY]);
            board.AddPieceToBoard(queen);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = queen.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }
    }
}