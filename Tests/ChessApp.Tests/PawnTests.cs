using ChessApp.Model;

namespace ChessApp.Tests
{
    public class PawnTests
    {
        [Fact]
        public void WhitePawnCanMoveOneForward()
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
        public void BlackPawnCanMoveOneForward()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(false, [0, 6]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 5, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCanMoveTwoForwardOnFirstTurn()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 3, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void BlackPawnCanMoveTwoForwardOnFirstTurn()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(false, [0, 6]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 4, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveTwoForwardOnSecondTurn()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            pawn.Move([0, 2]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 4, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveTwoForwardOnSecondTurn()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(false, [0, 6]);
            pawn.Move([0, 5]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 3, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveTwoForwardWhenThereIsAPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(true, [0, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [0, 2]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(0, 3, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveTwoForwardWhenThereIsAPieceInTheWay()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(false, [0, 6]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [0, 5]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(0, 4, board.Board);
        
            // Then
            Assert.False(validMove);
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
            Boolean validMove = pawn1.IsValidMove(0, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveOneForwardWhenWhitePieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(false, [0, 6]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [0, 5]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(0, 5, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveOneDiagonalWhenWhitePieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(true, [0, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [1, 2]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveOneDiagonalWhenBlackPieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(false, [0, 6]);
            ChessPiece pawn2 = new ChessPiecePawn(false, [1, 5]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 5, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void WhitePawnCanMoveOneDiagonalWhenBlackPieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(true, [0, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(false, [1, 2]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 2, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCanMoveOneDiagonalWhenBlackPieceStandsOnTarget_Inverse()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(true, [3, 1]);
            ChessPiece pawn2 = new ChessPiecePawn(false, [2, 2]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(2, 2, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void BlackPawnCanMoveOneDiagonalWhenWhitePieceStandsOnTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn1 = new ChessPiecePawn(false, [0, 6]);
            ChessPiece pawn2 = new ChessPiecePawn(true, [1, 5]);
            board.AddPieceToBoard(pawn1);
            board.AddPieceToBoard(pawn2);
        
            // When
            Boolean validMove = pawn1.IsValidMove(1, 5, board.Board);
        
            // Then
            Assert.True(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveDiagonalWithoutTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(1, 2, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveDiagonalWithoutTarget()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(false, [0, 6]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(1, 5, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void BlackPawnCannotMoveDiagonalWithoutTarget_Inverse()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(false, [3, 6]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(2, 5, board.Board);
        
            // Then
            Assert.False(validMove);
        }

        [Fact]
        public void WhitePawnCannotMoveOneToTheSide()
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

        [Fact]
        public void WhitePawnCannotMoveThreeForward()
        {
            // Given
            ChessBoard board = new();
            ChessPiece pawn = new ChessPiecePawn(true, [0, 1]);
            board.AddPieceToBoard(pawn);
        
            // When
            Boolean validMove = pawn.IsValidMove(0, 4, board.Board);
        
            // Then
            Assert.False(validMove);
        }
    }
}