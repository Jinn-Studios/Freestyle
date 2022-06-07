namespace JinnDev.Freestyle.TicTacToe
{
    public class Program
    {
        static void Main()
        {
            var board = new TicTacToeBoard();
            var ticTacToeService = new TicTacToeService(board);
            var result = ticTacToeService.RunGame();
            TicTacToeService.WriteGrid(board);
            if (result)
                Console.WriteLine("YOU WON!!");
            else
                Console.WriteLine("YOU SUCK!!");

        }
    }
}