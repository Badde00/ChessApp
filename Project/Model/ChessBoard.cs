
namespace Project.Model
{ // TODO: Finish Chessboard, make controller and view
    public class ChessBoard
    {
        public ChessPiece?[,] Board { get; }
        public List<ChessPiece> capturedPieces = [];

        public ChessBoard()
        {
            Board = new ChessPiece?[8, 8];
            this.SetUpBoard();
        }

        public bool AddPieceToBoard(ChessPiece p) {
            if (p == null) {
                throw new Exception(); // TODO: specify exception
            }
            if (Board[p.Pos[0], p.Pos[1]] != null) {
                return false;
            } else {
                Board[p.Pos[0], p.Pos[1]] = p;
                return true;
            }
        }

        public bool MovePiece(int x1, int y1, int x2, int y2, string? specialMove) { //TODO: Deal with En Passant, Castling and transforming a pawn at end row
            ChessPiece? pieceToMove = Board[x1, y1];
            if (pieceToMove != null) {
                bool isValidMove = pieceToMove.IsValidMove(x2, y2, Board);
                if (isValidMove) {
                    if (Board[x2, y2] != null) {
                        capturedPieces.Add(Board[x2, y2]!);
                    }
                    pieceToMove.Move([x2, y2]);
                    Board[x1, y1] = null;
                }
            }
            return false;
        }

        private void SetUpBoard() {
            for (int i = 0; i < 8; i++) {
                this.AddPieceToBoard(new ChessPiecePawn(true, [i, 1]));
                this.AddPieceToBoard(new ChessPiecePawn(false, [i, 6]));
            }
            this.AddPieceToBoard(new ChessPieceRook(true, [0, 0]));
            this.AddPieceToBoard(new ChessPieceRook(true, [7, 0]));
            this.AddPieceToBoard(new ChessPieceRook(false, [0, 7]));
            this.AddPieceToBoard(new ChessPieceRook(false, [7, 7]));
            this.AddPieceToBoard(new ChessPieceRook(true, [1, 0]));
            this.AddPieceToBoard(new ChessPieceRook(true, [6, 0]));
            this.AddPieceToBoard(new ChessPieceRook(false, [1, 7]));
            this.AddPieceToBoard(new ChessPieceRook(false, [6, 7]));
            this.AddPieceToBoard(new ChessPieceBishop(true, [2, 0]));
            this.AddPieceToBoard(new ChessPieceBishop(true, [5, 0]));
            this.AddPieceToBoard(new ChessPieceBishop(false, [2, 7]));
            this.AddPieceToBoard(new ChessPieceBishop(false, [5, 7]));
            this.AddPieceToBoard(new ChessPieceQueen(true, [3, 0]));
            this.AddPieceToBoard(new ChessPieceQueen(false, [3, 7]));
            this.AddPieceToBoard(new ChessPieceKing(true, [4, 0]));
            this.AddPieceToBoard(new ChessPieceKing(true, [4, 7]));
        }
    }
}