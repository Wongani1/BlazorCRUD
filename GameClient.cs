using System.Net.NetworkInformation;
using GameStore.Client.Models;

namespace GameStore.Client;

public class GameClient
{
        private static readonly List<Game> games = new()
    {
         new Game() {
            Id=1,
            Name="Street Fighter II",
            Genre="Fighting",
            Price=19.99M,
            ReleaseDate= new DateTime(1991,2,1)
         },
        new Game() {
            Id=2,
            Name="Mortal Kombat 4",
            Genre="Fighting",
            Price=40.99M,
            ReleaseDate= new DateTime(1998,11,1)
         }
    };
    public static Game [] GetGames()
    {
        return games.ToArray();
    }

    public static void AddGame(Game game) {
        game.Id=games.Max(game=> game.Id)+1;
        games.Add(game);
    }
    public static Game GetGame(int id) {
        return games.Find(game=> game.Id ==id) ?? throw new Exception("Could not find game");
    }

    public static void UpdateGame(Game updatedGame) {
        Game existingGame = GetGame(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;

    }

    public static void DeleteGame(int id) {
        Game game = GetGame(id);
        games.Remove(game);
    }
}