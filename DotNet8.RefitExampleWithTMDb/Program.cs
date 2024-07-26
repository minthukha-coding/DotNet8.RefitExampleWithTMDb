using DotNet8.RefitExampleWithTMDb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI0ZDE0NGYyNTg5Y2M2ODQxMzBhNzQyNjJiNmI2NjczYiIsIm5iZiI6MTcyMTk4ODkxMS4xNDIwNTIsInN1YiI6IjY1NmEyZTYyMDg1OWI0MDBmZjc0N2NjOSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.rV89UG5ozAK98KHZHjHh0XRDqlFhOEILcb4-IKlNUJA";

builder.Services
    .AddRefitClient<ITmdbApi>(new RefitSettings
    {
        AuthorizationHeaderValueGetter = (rq,ct) => Task.FromResult(authToken)
    })
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
