using TicTacToe.Enums;
using TicTacToe.State;

namespace TicTacToe.Logic
{
    class Recommendation
    {

        public static Nullable<Move> GetMove(GameState state)
        {
            var currentPlayer = state.CurrentPlayer;
            var board = state.Board;
            var currentTile = currentPlayer == Player.X ? Tile.X : Tile.O;
            

            // Todo: Implement this method
            var move = new Move();
            return move;
        }

        protected static Nullable<Move> GetWinningMove(Tile[,] board, Tile currentTile)
        {
            // Todo: Implement this method
            var move = new Move();
            return move;
        }

        protected static Nullable<Move> GetBlockingMove(Tile[,] board, Tile currentTile)
        {
            // Todo: Implement this method
            var move = new Move();
            return move;
        }

        protected static Nullable<Move> GetFillerMove(Tile[,] board, Tile currentTile)
        {
            // Todo: Implement this method
            var move = new Move();
            return move;
        }



    }
}