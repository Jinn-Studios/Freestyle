namespace JinnDev.Freestyle.TicTacToe
{
    public class TicTacToeService
    {
        private readonly TicTacToeBoard _board;

        public TicTacToeService(TicTacToeBoard board)
        {
            _board = board;
        }

        public bool RunGame()
        {
            while (true)
            {
                WriteGrid(_board);
                Console.WriteLine("Where do you want to go?");
                if (WinConditionMet(_board.Tiles)) return false;
                var answer = Console.ReadLine();
                if (TryParseLocation(answer, out int location))
                {
                    _board.Tiles[location] = "X";
                    if (WinConditionMet(_board.Tiles)) return true;
                    _board.Tiles = ComputerGo(_board.Tiles);
                }
            }
        }

        private static bool WinConditionMet(Dictionary<int, string?> tiles)
        {
            if (CheckRow(1, tiles) || CheckRow(2, tiles) || CheckRow(3, tiles))
                return true;

            if (CheckCol(1, tiles) || CheckCol(2, tiles) || CheckCol(3, tiles))
                return true;

            return CheckDiagonals(tiles);
        }

        private static bool CheckDiagonals(Dictionary<int, string> tiles)
        {
            return (tiles[1] == tiles[5] && tiles[1] == tiles[9] && tiles[1] != null)
            || (tiles[3] == tiles[5] && tiles[3] == tiles[7] && tiles[3] != null);
        }

        private static bool CheckCol(int col, Dictionary<int, string> tiles)
        {
            return tiles[col] == tiles[col + 3] && tiles[col] == tiles[col + 6] && tiles[col] != null;
        }

        private static bool CheckRow(int rowIndex, Dictionary<int, string> tiles)
        {
            var row = ((rowIndex - 1) * 3) + 1;
            return tiles[row] == tiles[row + 1] && tiles[row] == tiles[row + 2] && tiles[row] != null;
        }

        private bool TryParseLocation(string answer, out int location)
        {
            return int.TryParse(answer, out location) && location > 0 && location <= 9 && _board.Tiles[location] == null;
        }

        private static Dictionary<int, string?> ComputerGo(Dictionary<int, string?> tiles)
        {
            var copy = tiles.ToDictionary(x => x.Key, y => y.Value);
            foreach(var tile in tiles.Where(x => x.Value == null))
            {
                copy[tile.Key] = "X";
                if (WinConditionMet(copy))
                {
                    tiles[tile.Key] = "O";
                    return tiles;
                }
                copy[tile.Key] = null;
            }
            var changeKey = tiles.First(x => x.Value == null).Key;
            tiles[changeKey] = "O";
            return tiles;
        }

        public static void WriteGrid(TicTacToeBoard board)
        {
            Console.Clear();
            Console.WriteLine($@"
 {board.Tiles[1] ?? "1"} | {board.Tiles[2] ?? "2"} | {board.Tiles[3] ?? "3"} 
-----------
 {board.Tiles[4] ?? "4"} | {board.Tiles[5] ?? "5"} | {board.Tiles[6] ?? "6"} 
-----------
 {board.Tiles[7] ?? "7"} | {board.Tiles[8] ?? "8"} | {board.Tiles[9] ?? "9"} ");
        }
    }
}