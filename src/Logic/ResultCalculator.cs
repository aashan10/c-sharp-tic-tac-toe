using TicTacToe.Enums;

namespace TicTacToe.Logic {
    class ResultCalculator {

        public static Boolean IsGameOver(Tile[,] board, Tile currentTile) {
            
            if (board[0, 0] == currentTile && board[1, 1] == currentTile && board[2, 2] == currentTile) {
                return true;
            }

            if (board[0, 2] == currentTile && board[1, 1] == currentTile && board[2, 0] == currentTile) {
                return true;
            }

            // Check in rows
            for (int i = 0; i < 3; i++) {
                if (board[i, 0] == currentTile && board[i, 1] == currentTile && board[i, 2] == currentTile) {
                    return true;
                }

                if (board[0, i] == currentTile && board[1, i] == currentTile && board[2, i] == currentTile) {
                    return true;
                }
            }

            return false;
        }

    }
}