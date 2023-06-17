using TicTacToe.Enums;

namespace TicTacToe.Input
{
    class UserInput
    {

        public static Move GetMove()
        {
            var move = new Move();
            Console.WriteLine("Enter row: (0, 1, 2)");
            var row = Console.ReadLine();
            Console.WriteLine("Enter column: (0, 1, 2)");
            var column = Console.ReadLine();

            if (Int32.TryParse(row, out move.X) && Int32.TryParse(column, out move.Y))
            {
                if (move.X >= 0 && move.X <= 2 && move.Y >= 0 && move.Y <= 2)
                {
                    return move;
                }
            }

            Console.WriteLine("Invalid move");
            return GetMove();           
        }
    
        public static Boolean GetBoolean(String message) {
            Console.WriteLine(message + " (y/n)");
            var response = Console.ReadLine();
            if (response == "y") {
                return true;
            }
            return false;
        }

        public static Mode GetMode() {
            Console.WriteLine("Enter game mode: (default: Multiplayer)\n1. Single Player (Player vs Computer)\n2. Multiplayer (Plaver vs Player)");
            var response = Console.ReadLine();
            if (response == "1") {
                return Mode.SinglePlayer;
            }
            return Mode.MultiPlayer;
        }
    }
}