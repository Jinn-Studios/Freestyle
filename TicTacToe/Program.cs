namespace JinnDev.Freestyle.TicTacToe
{
    public class Program
    {
        static void Main()
        {
            var repo = new TicTacToeRepo();
            var ticTacToeService = new TicTacToeService(repo);
            var boardUI = new TicTacToeUI(repo, ticTacToeService);

            boardUI.RunUserInterface();
        }
    }
}