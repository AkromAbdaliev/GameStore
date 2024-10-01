using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


app.MapGamesEndpoints();

app.Run();