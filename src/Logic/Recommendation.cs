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

            var winningMove = GetWinningMove(board, currentTile);
            if (winningMove.HasValue)
            {
                return winningMove;
            }

            var blockingMove = GetBlockingMove(board, currentTile);
            if (blockingMove.HasValue)
            {
                return blockingMove;
            }

            return GetFillerMove(board, currentTile);
        }

        protected static Nullable<Move> GetWinningMove(Tile[,] board, Tile currentTile)
        {
            var availableMoves = GetAvailableMoves(board, currentTile);
            foreach (var move in availableMoves)
            {
                if (IsWinningMove(board, move, currentTile))
                {
                    return move;
                }

            }
            return null;
        }

        protected static Nullable<Move> GetBlockingMove(Tile[,] board, Tile currentTile)
        {
            var availableMoves = GetAvailableMoves(board, currentTile);
            foreach (var move in availableMoves)
            {
                if (IsBlockingMove(board, move, currentTile))
                {
                    return move;
                }

            }
            return null;
        }

        protected static Nullable<Move> GetFillerMove(Tile[,] board, Tile currentTile)
        {
            var availableMoves = GetAvailableMoves(board, currentTile);
            return availableMoves.Count > 0 ? availableMoves[0] : (Nullable<Move>)null;
        }

        protected static List<Move> GetAvailableMoves(Tile[,] board, Tile currentTile)
        {
            var availableMoves = new List<Move>();
            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == Tile.Empty)
                    {
                        var move = new Move();
                        move.X = x;
                        move.Y = y;
                        availableMoves.Add(move);
                    }
                }
            }
            return availableMoves;
        }

        protected static Boolean IsBlockingMove(Tile[,] board, Move move, Tile currentTile)
        {
            var boardCopy = (Tile[,])board.Clone();
            boardCopy[move.X, move.Y] = currentTile == Tile.X ? Tile.O : Tile.X;

            return ResultCalculator.IsGameOver(boardCopy, currentTile);
        }
        protected static Boolean IsWinningMove(Tile[,] board, Move move, Tile currentTile)
        {
            var boardCopy = (Tile[,])board.Clone();
            boardCopy[move.X, move.Y] = currentTile;

            return ResultCalculator.IsGameOver(boardCopy, currentTile);
        }
    }
}