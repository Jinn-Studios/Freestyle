using System;
using System.Collections.Generic;
using Xunit;

namespace JinnDev.Freestyle.TicTacToe.UnitTests
{
    public class ComputerGoTests
    {
        public static IEnumerable<object[]> BoardStarts =>
            new List<object[]>
            {
                new object[] { new List<char?> {
                    null, null, null,
                    null, null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', null, null,
                    null, null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', null,
                    null, null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    null, null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'X', null, null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'X', 'X', null,
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'X', 'X', 'X',
                    null, null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'X', 'X', 'X',
                    'X', null, null } },
                new object[] { new List<char?> {
                    'X', 'X', 'X',
                    'X', 'X', 'X',
                    'X', 'X', null } },
            };
        public static IEnumerable<object[]> ChallengeToGuardSpace =>
            new List<object[]>
            {
                new object[] { new List<char?> {
                    'X', null, null,
                    'X', null, null,
                    null, null, null }, 6 },
                new object[] { new List<char?> {
                    null, 'X', null,
                    null, 'X', null,
                    null, null, null }, 7 },
                new object[] { new List<char?> {
                    null, null, 'X',
                    null, null, 'X',
                    null, null, null }, 8 },
                new object[] { new List<char?> {
                    'X', 'X', null,
                    null, null, null,
                    null, null, null }, 2 },
                new object[] { new List<char?> {
                    null, null, null,
                    'X', 'X', null,
                    null, null, null }, 5 },
                new object[] { new List<char?> {
                    null, null, null,
                    null, null, null,
                    'X', 'X', null }, 8 },
                new object[] { new List<char?> {
                    null, null, 'X',
                    null, 'X', null,
                    null, null, null }, 6 },
                new object[] { new List<char?> {
                    'X', null, null,
                    null, 'X', null,
                    null, null, null }, 8 },
            };

        [Theory]
        [MemberData(nameof(BoardStarts))]
        public void ComputerGo_FindsASpace(List<char?> tiles)
        {
            var foundSpace = TicTacToeService.ComputerGo(tiles);
            Assert.True(foundSpace >= 0);
            Assert.Null(tiles[foundSpace]);
        }

        [Theory]
        [MemberData(nameof(ChallengeToGuardSpace))]
        public void ComputerGo_StopsAWin(List<char?> tiles, int guardSpace)
        {
            var foundSpace = TicTacToeService.ComputerGo(tiles);
            Assert.True(foundSpace == guardSpace);
        }

        [Fact]
        public void ComputerGo_NoNullTiles_ThrowsException()
        {
            Assert.Throws<BoardException>(() => TicTacToeService.ComputerGo(new List<char?> { 'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', 'X' }));
        }
    }
}