namespace TicTacToe.Enums {
    public enum Player {
        X,
        O
    }

    public enum Mode {
        SinglePlayer,
        MultiPlayer
    }

    public enum Tile {
        Empty,
        X,
        O
    }

    struct Move {
        public int X;
        public int Y;
    }
};