using Microsoft.AspNetCore.Mvc;
using Slack.App;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(
    logging =>
    {
        logging.LoggingFields =
            Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    });
var app = builder.Build();
app.UseHttpLogging();

app.MapGet("/", () => "You are running!");

app.MapPost("/super", (HttpRequest request) =>
{
    var text = request.Form["text"];
    return $"you said {text} was cool";
});

app.MapPost("/event", ([FromBody] ChallengeRequest request) =>
{
    return request.Challenge;
    // same route hit for both challenges and ALL reactions!
});

app.UseHttpLogging();

app.Run();
