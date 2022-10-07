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

app.MapPost("/super", (HttpRequest anything) =>
{
    var text = anything.Form["text"];
    return $"you said {text} was cool";
});

app.UseHttpLogging();

app.Run();
