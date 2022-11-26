using Povio.FlowerSpot.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.Run();

public partial class Program { }