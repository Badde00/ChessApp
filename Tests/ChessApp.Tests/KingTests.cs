

using Project.Model;

namespace ChessApp.Tests
{
    public class KingTests
    {
        [Fact]
        public void KingCannotMoveToSameSpace()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [0, 0]);
            board.AddPieceToBoard(king);
        
            // When
            bool validMove = king.IsValidMove(0, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(2, 1)]
        [InlineData(2, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        public void KingCanMoveOneSpace(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [1, 1]);
            board.AddPieceToBoard(king);
        
            // When
            bool validMove = king.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(4, 4)]
        [InlineData(3, 1)]
        [InlineData(7, 7)]
        [InlineData(3, 2)]
        public void KingCannotMoveMoreThanOneSpace(int targetX, int targetY) {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [1, 1]);
            board.AddPieceToBoard(king);
        
            // When
            bool validMove = king.IsValidMove(targetX, targetY, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void KingCannotMoveToSpaceThreatenedByQueen()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece queen = new ChessPieceQueen(false, [5, 7]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(queen);
        
            // When
            bool validMove = king.IsValidMove(5, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void KingCannotMoveToSpaceThreatenedByPawn()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [5, 2]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = king.IsValidMove(4, 1, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Fact]
        public void KingCanMoveToSpacePawnCanWalkTo()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [4, 2]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = king.IsValidMove(4, 1, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void KingCanCapturePawnThreateningIt()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece pawn = new ChessPiecePawn(false, [5, 1]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(pawn);
        
            // When
            bool validMove = king.IsValidMove(5, 1, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void WhiteKingCanCastle()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = king.IsValidMove(2, 0, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void WhiteKingCanCastle_Inverse()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece rook = new ChessPieceRook(true, [7, 0]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = king.IsValidMove(6, 0, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void BlackKingCanCastle()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(false, [4, 7]);
            ChessPiece rook = new ChessPieceRook(false, [0, 7]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = king.IsValidMove(2, 7, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Fact]
        public void BlackKingCanCastle_Inverse()
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(false, [4, 7]);
            ChessPiece rook = new ChessPieceRook(false, [7, 7]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
        
            // When
            bool validMove = king.IsValidMove(6, 7, board.Board);
        
            // Then
            Assert.True(validMove);
        }
        
        [Theory]
        [InlineData(4, 3)]
        [InlineData(3, 3)]
        [InlineData(2, 3)]
        public void WhiteKingCannotCastleWhenThreatened(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece rook = new ChessPieceRook(true, [0, 0]);
            ChessPiece rook2 = new ChessPieceRook(false, [targetX, targetY]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(rook2);
        
            // When
            bool validMove = king.IsValidMove(2, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Theory]
        [InlineData(4, 3)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        public void WhiteKingCannotCastleWhenThreatened_Inverse(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 0]);
            ChessPiece rook = new ChessPieceRook(true, [7, 0]);
            ChessPiece rook2 = new ChessPieceRook(false, [targetX, targetY]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(rook2);
        
            // When
            bool validMove = king.IsValidMove(6, 0, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Theory]
        [InlineData(4, 3)]
        [InlineData(3, 3)]
        [InlineData(2, 3)]
        public void BlackKingCannotCastleWhenThreatened(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 7]);
            ChessPiece rook = new ChessPieceRook(true, [0, 7]);
            ChessPiece rook2 = new ChessPieceRook(false, [targetX, targetY]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(rook2);
        
            // When
            bool validMove = king.IsValidMove(2, 7, board.Board);
        
            // Then
            Assert.False(validMove);
        }
        
        [Theory]
        [InlineData(4, 3)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        public void BlackKingCannotCastleWhenThreatened_Inverse(int targetX, int targetY)
        {
            // Given
            ChessBoard board = new();
            ChessPiece king = new ChessPieceKing(true, [4, 7]);
            ChessPiece rook = new ChessPieceRook(true, [7, 7]);
            ChessPiece rook2 = new ChessPieceRook(false, [targetX, targetY]);
            board.AddPieceToBoard(king);
            board.AddPieceToBoard(rook);
            board.AddPieceToBoard(rook2);
        
            // When
            bool validMove = king.IsValidMove(6, 7, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}