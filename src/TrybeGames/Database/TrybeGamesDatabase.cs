namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // Busca os jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {

        var games = Games.Where(game => game.DeveloperStudio == gameStudio.Id);
        return games.ToList();
    }

    // Busca os jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        var playedGames = Games.Where(game => game.Players.Contains(player.Id));
        return playedGames.ToList();
    }

    // Busca os jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        var ownedGames = Games.Where(game => playerEntry.GamesOwned.Contains(game.Id));
        return ownedGames.ToList();
    }


    // Busca todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        var gamesWithStudio = from game in Games
                              from studio in GameStudios
                              where game.DeveloperStudio == studio.Id
                              select new GameWithStudio
                              {
                                  GameName = game.Name,
                                  StudioName = studio.Name,
                                  NumberOfPlayers = game.Players.Count
                              };

        return gamesWithStudio.ToList();
    }

    // Busca todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        var gameTypes = from game in Games
                        select game.GameType;
        
        return gameTypes.Distinct().ToList();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        throw new NotImplementedException();
    }

}
