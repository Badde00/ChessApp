
namespace Project.Model
{ // TODO: Finish Chessboard, write tests for king, make controller and view
    public class ChessBoard
    {
        public ChessPiece?[,] Board { get; }
        public List<ChessPiece> capturedPieces = [];

        public ChessBoard()
        {
            Board = new ChessPiece?[8, 8];
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

        public bool MovePiece(int x1, int y1, int x2, int y2) { //TODO: Deal with En Passant, Castling and transforming a pawn at end row
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
    }
}