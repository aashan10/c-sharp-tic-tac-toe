using TicTacToe.Enums;
using TicTacToe.Input;
using TicTacToe.State;

namespace TicTacToe.Logic
{
    class GameLogic
    {
        protected GameState _State;
        public GameState State
        {
            get { return _State; }
        }

        public void RestartGame(Nullable<Mode> mode)
        {
            _State = new GameState();
            if (mode.HasValue)
            {
                _State.Mode = mode.Value;
            }
        }

        public GameLogic()
        {
            _State = new GameState();
        }

        public Boolean IsGameOver()
        {
            var gameOver = AreTilesFull(); ;

            return gameOver;
        }


        protected Boolean AreTilesFull()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_State.Board[i, j] == Tile.Empty)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public void PrintBoard() {
            _State.PrintBoard();
        }

        public void SwitchPlayer() {
            _State.SwitchPlayer();
        }

        public Boolean MakeMove(Boolean isComputersTurn) 
        {
            var player = _State.CurrentPlayer;
            var mode = _State.Mode;
            var board = _State.Board;
            var currentTile = player == Player.X ? Tile.X : Tile.O;

            if (mode == Mode.SinglePlayer && isComputersTurn)
            {
                var move = Recommendation.GetMove(_State);
                if (!move.HasValue)
                {
                    return false;
                }
                _State.SetTile(move.Value.X, move.Value.Y, currentTile);
            }
            else
            {
                var move = GetMove();
                if (!move.HasValue)
                {
                    return false;
                }
                _State.SetTile(move.Value.X, move.Value.Y, currentTile);
            }

            return true;
        }

        protected Nullable<Move> GetMove() {
            var move = UserInput.GetMove();
            if (this._State.Board[move.X, move.Y] != Tile.Empty) {
                return null;
            }
            return move;
        }

         public Tile GetCurrentTile() {
            return _State.CurrentPlayer == Player.X ? Tile.X : Tile.O;
        }

    }

}