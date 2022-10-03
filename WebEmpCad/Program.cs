using WebEmpCad;
using WebEmpCad.Entities.Services;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

var test = new CnpjServices();
await test.Integracao("32870761000190");

app.Run();
