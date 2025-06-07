using BearsMutabilitySimulatorAPI.Models;
using BearsMutabilitySimulatorLib;
using OpenCvSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var bearsAmount = 50;
var habitatLenght = 400;
var coordinateSpace = new CoordinateSpace(new Point(0,0), habitatLenght * 2, habitatLenght * 2);

var bears = new List<Bear>(bearsAmount);
bears.AddRange(Enumerable.Range(0, bearsAmount).Select(_ => new Bear(coordinateSpace.BottomRight)));

app.MapGet("/bears", () =>
{
    var bearsData = bears.Select(b => new BearData()
    {
        Color = [b.Color.Val0, b.Color.Val1, b.Color.Val2],
        MaximumAllowablePosition = [b.MaximumAllowablePosition.X, b.MaximumAllowablePosition.Y],
        Lifetime = b.Lifetime,
        Position = [b.Position.X, b.Position.Y],
        TimeToNextChildLeft = b.TimeToNextChildLeft
    }).ToArray();
    return bearsData;
});
    

app.Run();
