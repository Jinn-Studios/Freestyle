using System.Collections.Generic;
using Xunit;

namespace JinnDev.Freestyle.TicTacToe.UnitTests
{
    public class WinConditionMetTests
    {
        public static IEnumerable<object[]> Winners =>
            new List<object[]>
            {
                new object[] { new List<char?> {
                    'X', 'O', 'O',
                    'X', 'O', 'X',
                    'X', null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'O',
                    'O', 'X', 'X',
                    'X', 'X', null } },
                new object[] { new List<char?> {
                    'O', 'X', 'X',
                    'O', 'O', 'X',
                    'X', 'O', 'X' } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'O', 'O', 'X',
                    'X', 'O', 'O' } },
                new object[] { new List<char?> {
                    'O', 'O', 'X',
                    'X', 'X', 'X',
                    'O', 'X', 'O' } },
                new object[] { new List<char?> {
                    'O', 'O', 'X',
                    'X', 'O', 'O',
                    'X', 'X', 'X' } },
            };

        public static IEnumerable<object[]> NotWinners =>
            new List<object[]>
            {
                new object[] { new List<char?> {
                    null, null, null,
                    null, null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'O', 'O', 'X',
                    'X', 'O', 'O',
                    'O', 'X', 'X' } },
            };

        [Theory]
        [MemberData(nameof(Winners))]
        public void WinConditionMet_Winners(List<char?> tiles)
            => Assert.True(TicTacToeService.WinConditionMet(tiles));

        [Theory]
        [MemberData(nameof(NotWinners))]
        public void WinConditionMet_NotWinners(List<char?> tiles)
            => Assert.False(TicTacToeService.WinConditionMet(tiles));
    }
}