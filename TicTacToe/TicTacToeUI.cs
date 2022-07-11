namespace JinnDev.Freestyle.TicTacToe
{
    public class TicTacToeUI
    {
        private readonly TicTacToeRepo _repo;
        private readonly TicTacToeService _ticTacToeService;

        public TicTacToeUI(TicTacToeRepo repo, TicTacToeService ticTacToeService)
        {
            _repo = repo;
            _ticTacToeService = ticTacToeService;
        }

        public void RunUserInterface()
        {
            var state = BoardState.Playing;
            while (state == BoardState.Playing)
            {
                WriteGrid(_repo.GetTiles());

                Console.WriteLine("Where do you want to go?");
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out int proposedMove))
                    continue;

                state = _ticTacToeService.MakeAMove(proposedMove);
            }

            WriteGrid(_repo.GetTiles());

            switch (state)
            {
                case BoardState.PlayerWins:
                    Console.WriteLine("YOU WON!!");
                    break;
                case BoardState.ComputerWins:
                    Console.WriteLine("YOU SUCK!!");
                    break;
                case BoardState.Stalemate:
                    Console.WriteLine("Stalemate once again");
                    break;
            }
        }

        private static void WriteGrid(List<char?> board)
        {
            Console.Clear();
            Console.WriteLine($@"
 {board[0] ?? '1'} | {board[1] ?? '2'} | {board[2] ?? '3'} 
-----------
 {board[3] ?? '4'} | {board[4] ?? '5'} | {board[5] ?? '6'} 
-----------
 {board[6] ?? '7'} | {board[7] ?? '8'} | {board[8] ?? '9'} ");
        }
    }
}