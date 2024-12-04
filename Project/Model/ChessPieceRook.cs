
namespace Project.Model
{
    public class ChessPieceRook(bool isWhite, int[] pos) : ChessPiece(isWhite, pos)
    {

        public override bool IsValidMove(int x, int y, ChessPiece[,] board) {
            // Checks if rook is moving in only one direction (using XOR)
            if (Math.Abs(this.Pos[0] - x) != 0 ^ Math.Abs(this.Pos[1] - y) != 0) {
                return true;
            }

            return false;
        }
    }
}