using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

List<GameDto> games = new()
{
    new GameDto(1, "The Last Adventure", "Action", 49.99m, new DateOnly(2021, 5, 17)),
    new GameDto(2, "Mystery Quest", "Puzzle", 29.99m, new DateOnly(2022, 3, 9)),
    new GameDto(3, "Space Battle", "Sci-Fi", 59.99m, new DateOnly(2020, 11, 25))
};

app.MapGet("games", () => games);

app.MapGet("/", () => "Hello World!");

app.Run();