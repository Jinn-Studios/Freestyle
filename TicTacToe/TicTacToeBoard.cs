namespace JinnDev.Freestyle.TicTacToe
{
    public class TicTacToeBoard
    {
        public Dictionary<int, string?> Tiles { get; set; }

        public TicTacToeBoard()
        {
            Tiles = new Dictionary<int, string?>
            {
                { 1, null },
                { 2, null },
                { 3, null },
                { 4, null },
                { 5, null },
                { 6, null },
                { 7, null },
                { 8, null },
                { 9, null },
            };
        }
    }
}