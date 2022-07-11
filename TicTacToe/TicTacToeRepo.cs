namespace JinnDev.Freestyle.TicTacToe
{
    public class TicTacToeRepo
    {
        private readonly List<char?> _tiles = new();

        public TicTacToeRepo()
        {
            for (var i = 0; i < 9; i++) _tiles.Add(null);
        }

        public List<char?> GetTiles() => _tiles;

        public void SetTile(int position, char player) => _tiles[position] = player;
    }
}