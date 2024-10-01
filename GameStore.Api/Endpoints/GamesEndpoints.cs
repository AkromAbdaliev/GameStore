using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameDto> games = new()
    {
        new GameDto(1, "The Last Adventure", "Action", 49.99m, new DateOnly(2021, 5, 17)),
        new GameDto(2, "Mystery Quest", "Puzzle", 29.99m, new DateOnly(2022, 3, 9)),
        new GameDto(3, "Space Battle", "Sci-Fi", 59.99m, new DateOnly(2020, 11, 25))
    };

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {

        // GET /games
        app.MapGet("games", () => games);

        // GET /games/1
        app.MapGet("games/{id}", (int id) =>
        {   // response check 
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndPointName);

        //POST
        app.MapPost("games", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleasedDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        //PUT /games
        app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleasedDate
            );

            return Results.NoContent();
        });

        //DELETE /games/1
        app.MapDelete("games/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return app;
    }
}
