using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game(){
        Name = game.Name,
        GenreId = game.GenreId,
        Price = game.Price,
        ReleasedDate = game.ReleasedDate};
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(
        game.Id,
        game.Name,
        game.Genre!.Name,
        game.Price,
        game.ReleasedDate);
    }

    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
        game.Id,
        game.Name,
        game.GenreId,
        game.Price,
        game.ReleasedDate);
    }

}   
