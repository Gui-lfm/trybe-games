using Xunit;
using System;
using FluentAssertions;
using TrybeGames;
using Moq;

namespace TrybeGames.Test;

[Collection("Sequential")]
public class TestTrybeGamesDatabase
{
    [Theory(DisplayName = "Deve testar se GetGamesPlayedBy retorna jogos jogados pela pessoa jogadora corretamente.")]
    [MemberData(nameof(DataTestGetGamesPlayedBy))]
    public void TestGetGamesPlayedBy(TrybeGamesDatabase databaseEntry, int playerIdEntry, List<Game> expected)
    {

        // Arrange
        TrybeGamesDatabase database = new()
        {
            Games = databaseEntry.Games,
            GameStudios = databaseEntry.GameStudios,
            Players = databaseEntry.Players
        };
        Player player = database.Players.First(player => player.Id == playerIdEntry);
        // AcT
        List<Game> playedGames = database.GetGamesPlayedBy(player);
        // Assert
        playedGames.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<TrybeGamesDatabase, int, List<Game>> DataTestGetGamesPlayedBy => new TheoryData<TrybeGamesDatabase, int, List<Game>>
    {
        {
            new TrybeGamesDatabase
            {
                Games = new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Name = "Teste",
                        DeveloperStudio = 1,
                        Players = new List<int> { 1 }
                    }
                },
                GameStudios = new List<GameStudio>
                {
                    new GameStudio
                    {
                        Id = 1,
                        Name = "Teste"
                    }
                },
                Players = new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Name = "Teste",
                        GamesOwned = new List<int> { 1 }
                    }
                }
            },
            1,
            new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Teste",
                    DeveloperStudio = 1,
                    Players = new List<int> { 1 }
                }
            }
        }
    };

}
