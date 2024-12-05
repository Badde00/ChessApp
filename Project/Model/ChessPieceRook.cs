
namespace Project.Model
{
    public class ChessPieceRook(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {

        public override bool IsValidMove(int x, int y, ChessPiece[,] board) {
            // Checks if rook is moving in only one direction (using XOR)
            if (Math.Abs(this.Pos[0] - x) != 0 ^ Math.Abs(this.Pos[1] - y) != 0) {
                bool movingX = this.Pos[1] == y; // True if moving along X-axis, false if along Y-axis.
                int start = movingX ? this.Pos[0] : this.Pos[1];
                int end = movingX ? x : y;
                int step = start < end ? 1 : -1;

                // Iterate over the squares between the start and end positions (exclusive)
                for (int i = start + step; i != end; i += step) {
                    int checkX = movingX ? i : this.Pos[0];
                    int checkY = movingX ? this.Pos[1] : i;

                    // If there's a piece on a square between the start square and target squre, return false
                    if (board[checkX, checkY] != null) {
                        return false;
                    }
                }

                // Can't capture piece of matching color
                ChessPiece targetPiece = board[x, y];
                if (targetPiece != null) {
                    if (targetPiece.IsWhite == this.IsWhite) {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}