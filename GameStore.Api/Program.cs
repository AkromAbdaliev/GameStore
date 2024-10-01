using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDto> games = new()
{
    new GameDto(1, "The Last Adventure", "Action", 49.99m, new DateOnly(2021, 5, 17)),
    new GameDto(2, "Mystery Quest", "Puzzle", 29.99m, new DateOnly(2022, 3, 9)),
    new GameDto(3, "Space Battle", "Sci-Fi", 59.99m, new DateOnly(2020, 11, 25))
};

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
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

    return Results.CreatedAtRoute(GetGameEndPointName, new {id = game.Id}, game);
});

app.Run();