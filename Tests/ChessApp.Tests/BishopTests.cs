
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
        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(2, 4)]
        [InlineData(4, 2)]
        [InlineData(7, 7)]
        public void BishopCanCanMoveDiagonally(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [3, 3]);
            board.AddPieceToBoard(bishop);
        
            // When
            bool validMove = bishop.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void WhiteBishopCanCaptureBlackPiece()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [1, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void WhiteBishopCannotCaptureWhitePiece()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [1, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void BlackBishopCanCaptureWhitePiece()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(false, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [1, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void BlackBishopCannotCaptureBlackPiece()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(false, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [1, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(1, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void BishopCannotMoveWithPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [0, 0]);
            ChessPiece pawn = new ChessPiecePawn(true, [1, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(2, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void BishopCannotMoveWithPieceInTheWay_2()
        {
            // Given
            ChessBoard board = new();
            ChessPiece bishop = new ChessPieceBishop(true, [0, 7]);
            ChessPiece pawn = new ChessPiecePawn(true, [6, 1]);
            board.AddPieceToBoard(bishop);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = bishop.IsValidMove(7, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}