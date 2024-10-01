using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(30)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleasedDate
    );

