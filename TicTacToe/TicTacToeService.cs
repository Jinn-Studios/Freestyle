#pragma warning disable IDE1006 // CONSTANTS style -- Need to fix VS
namespace JinnDev.Freestyle.TicTacToe
{
    public class TicTacToeService
    {
        private readonly TicTacToeRepo _boardRepo;
        private const char PLAYER = 'X';
        private const char COMPUTER = 'O';

        public TicTacToeService(TicTacToeRepo boardRepo)
        {
            _boardRepo = boardRepo;
        }

        public BoardState MakeAMove(int proposedLocation)
        {
            List<char?> tiles = _boardRepo.GetTiles();

            if (IsLocationAcceptable(proposedLocation, tiles))
            {
                _boardRepo.SetTile(proposedLocation - 1, PLAYER);
                tiles[proposedLocation - 1] = PLAYER;
                if (WinConditionMet(tiles)) return BoardState.PlayerWins;

                if (tiles.Any(x => x == null) == false)
                    return BoardState.Stalemate;

                var computerPos = ComputerGo(tiles);
                _boardRepo.SetTile(computerPos, COMPUTER);
                tiles[computerPos] = COMPUTER;
                if (WinConditionMet(tiles)) return BoardState.ComputerWins;
            }

            return BoardState.Playing;
        }

        private static bool IsLocationAcceptable(int location, List<char?> tiles)
            => location > 0 && location <= 9 && tiles[location - 1] == null;

        public static bool WinConditionMet(List<char?> tiles)
        {
            if (CheckRow(1, tiles) || CheckRow(2, tiles) || CheckRow(3, tiles))
                return true;

            if (CheckCol(1, tiles) || CheckCol(2, tiles) || CheckCol(3, tiles))
                return true;

            return CheckDiagonals(tiles);
        }

        private static bool CheckDiagonals(List<char?> tiles)
        {
            return (tiles[0] == tiles[4] && tiles[0] == tiles[8] && tiles[0] != null)
            || (tiles[2] == tiles[4] && tiles[2] == tiles[6] && tiles[2] != null);
        }

        private static bool CheckCol(int colIndex, List<char?> tiles)
        {
            var col = colIndex - 1;
            return tiles[col] == tiles[col + 3] && tiles[col] == tiles[col + 6] && tiles[col] != null;
        }

        private static bool CheckRow(int rowIndex, List<char?> tiles)
        {
            var row = ((rowIndex - 1) * 3);
            return tiles[row] == tiles[row + 1] && tiles[row] == tiles[row + 2] && tiles[row] != null;
        }

        public static int ComputerGo(List<char?> tiles)
        {
            var copy = tiles.Select(x => x).ToList();
            var nullTiles = copy.Select((x, y) => new { Index = y, Value = x }).Where(x => x.Value == null).Select(x => x.Index).ToList();

            foreach (var tile in nullTiles)
            {
                copy[tile] = COMPUTER;
                if (WinConditionMet(copy))
                    return tile;

                copy[tile] = null;
            }

            foreach (var tile in nullTiles)
            {
                copy[tile] = PLAYER;
                if (WinConditionMet(copy))
                    return tile;

                copy[tile] = null;
            }

            return ComputerOffensivePlay(copy);
        }

        public static int ComputerOffensivePlay(List<char?> tiles)
        {
            var nullIndexes = tiles.Select((x, y) => new { Index = y, Value = x }).Where(x => x.Value == null).Select(x => x.Index).ToList();

            if (nullIndexes.Count == 0)
                throw new BoardException("Why did the Computer Go if there was nowhere to go?");

            if (nullIndexes.Count == 8)
            {
                var corners = new List<int> { 0, 2, 6, 8 };
                if (corners.Any(x => tiles[x] == PLAYER))
                    return 4;

                if (tiles[4] == PLAYER)
                    return 0;

                if (tiles[1] == PLAYER || tiles[5] == PLAYER)
                    return 6;

                return 2;
            }

            return nullIndexes.First();
        }
    }
}