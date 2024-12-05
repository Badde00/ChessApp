
using Project.Model;

namespace ChessApp.Tests
{
    public class KnightTests
    {
        [Fact]
        public void KnightCannotMoveToSameSpace()
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [0, 0]);
            board.AddPieceToBoard(knight);
        
            // When
            bool validMove = knight.IsValidMove(0, 0, board.Board);
        
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
        public void KnightCanMoveInLShape(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            board.AddPieceToBoard(knight);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        
        [Theory]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(2, 3)]
        [InlineData(1, 3)]
        [InlineData(5, 3)]
        public void KnightCannotMoveInALine(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            board.AddPieceToBoard(knight);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(2, 4)]
        [InlineData(4, 2)]
        [InlineData(7, 7)]
        [InlineData(0, 0)]
        public void KnightCannotMoveDiagonally(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            board.AddPieceToBoard(knight);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
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
        public void WhiteKnightCanCaptureBlackPiece(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            ChessPiece pawn = new ChessPiecePawn(false, [targetX, targetY]);
            board.AddPieceToBoard(knight);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
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
        public void BlackKnightCanCaptureWhitePiece(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            ChessPiece pawn = new ChessPiecePawn(false, [targetX, targetY]);
            board.AddPieceToBoard(knight);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
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
        public void WhiteKnightCannotCaptureWhitePiece(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(true, [3, 3]);
            ChessPiece pawn = new ChessPiecePawn(true, [targetX, targetY]);
            board.AddPieceToBoard(knight);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
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
        public void BlackKnightCannotCaptureBlackPiece(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece knight = new ChessPieceKnight(false, [3, 3]);
            ChessPiece pawn = new ChessPiecePawn(false, [targetX, targetY]);
            board.AddPieceToBoard(knight);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = knight.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}