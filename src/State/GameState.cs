
using TicTacToe.Enums;

namespace TicTacToe.State {
    class GameState {
        protected Player _CurrentPlayer;
        protected Mode _Mode;

        protected Tile[,] _Board;

        public GameState() {
            _Mode = Mode.SinglePlayer;
            _CurrentPlayer = Player.X;
            _Board = new Tile[3, 3];

            for (int i = 0; i < _Board.GetLength(0); i++) {
                for (int j = 0; j < _Board.GetLength(1); j++) {
                    _Board[i, j] = Tile.Empty;
                }
            }
        }

        public Player CurrentPlayer {
            get { return _CurrentPlayer; }
        }

        public Mode Mode {
            get { return _Mode; }
            set { _Mode = value; }
        }

        public void SwitchPlayer() {
            _CurrentPlayer = _CurrentPlayer == Player.X ? Player.O : Player.X;
        }
    
        public Tile[,] Board {
            get { return _Board; }
        }

        public void SetTile(int x, int y, Tile tile) {
            _Board[x, y] = tile;
        }

        public void PrintBoard() {
            var grid = this._Board;
            var player = this.CurrentPlayer;
            var mode = this._Mode;
            
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("       Tic Tac Toe");
            Console.WriteLine("===========================");
            Console.WriteLine("Mode: {0}", mode == Mode.SinglePlayer ? "Single Player" : "Multi Player");
            Console.WriteLine("Current Player: {0}", player == Player.X ? "X" : "O");
            Console.WriteLine("===========================");

            Console.WriteLine("       0     1     2  ");
            Console.WriteLine("");
            Console.WriteLine("0      {0}  |  {1}  |  {2}  ",
                GetPositionStringFor(0, 0, grid),
                GetPositionStringFor(0, 1, grid),
                GetPositionStringFor(0, 2, grid)
            );
            Console.WriteLine("     -----+-----+-----");
            Console.WriteLine("1      {0}  |  {1}  |  {2}  ",
                GetPositionStringFor(1, 0, grid),
                GetPositionStringFor(1, 1, grid),
                GetPositionStringFor(1, 2, grid)
            );
            Console.WriteLine("     -----+-----+-----");
            Console.WriteLine("2      {0}  |  {1}  |  {2}  ",
                GetPositionStringFor(2, 0, grid),
                GetPositionStringFor(2, 1, grid),
                GetPositionStringFor(2, 2, grid)
            );
        }

        protected String GetPositionString(Tile type)
        {
            switch (type)
            {
                case Tile.Empty:
                    return " ";
                case Tile.X:
                    return "X";
                case Tile.O:
                    return "O";
            }

            return " ";
        }

        protected String GetPositionStringFor(int row, int column, Tile[,] grid)
        {
            return this.GetPositionString(grid[row, column]);
        }
    
        public void SetMode(Mode mode) {
            _Mode = mode;
        }
    }
}