using TicTacToe.Enums;
using TicTacToe.Input;

namespace TicTacToe.Logic
{

    class Game
    {
        protected GameLogic logic;

        public Game()
        {
            logic = new GameLogic();
        }



        public void Start()
        {
            logic.StartGame(UserInput.GetMode());
            var isComputersTurn = false;
            while (!logic.IsGameOver())
            {
                logic.PrintBoard();

                var move = logic.MakeMove(isComputersTurn);
                if (move)
                {
                    var currentTile = logic.State.CurrentPlayer == Player.X ? Tile.X : Tile.O;
                    if (ResultCalculator.IsGameOver(logic.State.Board, currentTile))
                    {
                        Console.WriteLine("Player " + currentTile + " wins!");
                        break;
                    }
                    
                    logic.SwitchPlayer();
                    isComputersTurn = !isComputersTurn;
                }
                else
                {
                    Console.WriteLine("Invalid move! Try Again.");
                }
            }

            logic.PrintBoard();

            Console.WriteLine("Game Over!");
            var response = UserInput.GetBoolean("Do you want to play again?");
            if (response)
            {
                Start();
            }
            System.Environment.Exit(0);
        }
    }
}