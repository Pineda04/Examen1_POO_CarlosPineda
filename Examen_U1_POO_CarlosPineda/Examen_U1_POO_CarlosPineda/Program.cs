using Examen_U1_POO_CarlosPineda;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.configure(app, app.Environment);

app.Run();
