
namespace Project.Model
{
    public class ChessPieceQueen(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {
        public override bool IsValidMove(int x, int y, ChessPiece?[,] board)
        {
            ChessPiece? targetPiece = board[x, y];
            // Can't capture piece of matching color
            if (targetPiece != null && targetPiece.IsWhite == this.IsWhite) {
                return false;
            }

            // Check if it moves like a rook
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

                return true;
            } else if (Math.Abs(this.Pos[0] - x) == Math.Abs(this.Pos[1] - y) && this.Pos[0] != x) { // Or moves like a bishop
                int movementX = x > this.Pos[0] ? 1 : -1;
                int movementY = y > this.Pos[1] ? 1 : -1;

                // Checks the squares between the current square and the target square if there's a piece in the way.
                for (int ix = this.Pos[0] + movementX; ix != x; ix += movementX) {
                    for (int iy = this.Pos[1] + movementY; iy != y; iy += movementY) {
                        // If there's a piece in the way, return false
                        if (board[ix, iy] != null) {
                            return false;
                        }
                    }
                }

                return true;
            }
            return false;
        }
    }
}