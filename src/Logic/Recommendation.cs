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
            var winningAxialMove = GetWinningAxialMove(board, currentTile);
            if (winningAxialMove.HasValue)
            {
                return winningAxialMove;
            }

            var winningDiagonalMove = GetWinningDiagonalMove(board, currentTile);
            if (winningDiagonalMove.HasValue)
            {
                return winningDiagonalMove;
            }

            return null;
        }

        protected static Nullable<Move> GetBlockingMove(Tile[,] board, Tile currentTile)
        {
            var blockingAxialMove = GetBlockingAxialMove(board, currentTile);
            if (blockingAxialMove.HasValue)
            {
                return blockingAxialMove;
            }

            var blockingDiagonalMove = GetBlockingDiagonalMove(board, currentTile);
            if (blockingDiagonalMove.HasValue)
            {
                return blockingDiagonalMove;
            }

            return null;
        }

        protected static Nullable<Move> GetFillerMove(Tile[,] board, Tile currentTile)
        {
            var availableMoves = GetAvailableMoves(board, currentTile);
            Random rnd = new Random();
            int index = rnd.Next(availableMoves.Count);
            return availableMoves.Count > 0 ? availableMoves[index] : (Nullable<Move>)null;
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
    
        protected static Nullable<Move> GetWinningAxialMove(Tile[,] board, Tile currentTile)
        {
            var moves = new List<Move>();

            for (var x = 0; x < board.GetLength(0); x++)
            {
                if (board[x, 0] == currentTile && board[x, 1] == currentTile && board[x, 2] == Tile.Empty)
                {
                    moves.Add(new Move(x, 2));
                }
                else if (board[x, 0] == currentTile && board[x, 1] == Tile.Empty && board[x, 2] == currentTile)
                {
                    moves.Add(new Move(x, 1));
                }
                else if (board[x, 0] == Tile.Empty && board[x, 1] == currentTile && board[x, 2] == currentTile)
                {
                    moves.Add(new Move(x, 0));
                } else if (board[0, x] == currentTile && board[1, x] == currentTile && board[2, x] == Tile.Empty)
                {
                    moves.Add(new Move(2, x));
                }
                else if (board[0, x] == currentTile && board[1, x] == Tile.Empty && board[2, x] == currentTile)
                {
                    moves.Add(new Move(1, x));
                }
                else if (board[0, x] == Tile.Empty && board[1, x] == currentTile && board[2, x] == currentTile)
                {
                    moves.Add(new Move(0, x));
                }

            }

            foreach (var move in moves)
            {
                var clonedBoard = (Tile[,])board.Clone();
                clonedBoard[move.X, move.Y] = currentTile;
                if (ResultCalculator.IsGameOver(clonedBoard, currentTile))
                {
                    return move;
                }
            }
            return null;
        }
    
        protected static Nullable<Move> GetWinningDiagonalMove(Tile[,] board, Tile currentTile) {
            var moves = new List<Move>();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, i] == Tile.Empty)
                {
                    moves.Add(new Move(i, i));
                } else if (board[i, 2 - i] == Tile.Empty)
                {
                    moves.Add(new Move(i, 2 - i));
                }
                
            }

            
            foreach (var move in moves)
            {
                var clonedBoard = (Tile[,])board.Clone();
                clonedBoard[move.X, move.Y] = currentTile;
                if (ResultCalculator.IsGameOver(clonedBoard, currentTile))
                {
                    return move;
                }
            }

            return null;
        }
    
        protected static Nullable<Move> GetBlockingAxialMove(Tile[,] board, Tile currentTile) {

            var boardClone = (Tile[,])board.Clone();
            var opponentTile = currentTile == Tile.X ? Tile.O : Tile.X;

            return GetWinningAxialMove(boardClone, opponentTile);
        }

        protected static Nullable<Move> GetBlockingDiagonalMove(Tile[,] board, Tile currentTile) {

            var boardClone = (Tile[,])board.Clone();
            var opponentTile = currentTile == Tile.X ? Tile.O : Tile.X;

            return GetWinningDiagonalMove(boardClone, opponentTile);
        }

        protected static Boolean IsWinningMove(Tile[,] board, Tile currentTile, Move move)
        {
            var boardClone = (Tile[,])board.Clone();
            boardClone[move.X, move.Y] = currentTile;
            return ResultCalculator.IsGameOver(boardClone, currentTile);
        }
    }
}