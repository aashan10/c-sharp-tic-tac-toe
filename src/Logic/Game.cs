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
            logic.RestartGame(UserInput.GetMode());
            var isComputersTurn = false;
            while (!logic.IsGameOver())
            {
                logic.PrintBoard();

                var move = logic.MakeMove(isComputersTurn);
                if (move)
                {
                    logic.SwitchPlayer();
                    isComputersTurn = !isComputersTurn;
                }
                else
                {
                    Console.WriteLine("Invalid move! Try Again.");
                    continue;
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