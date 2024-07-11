using DataAccess;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreWebDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DataAccess"));
});

builder.Services.AddGrpc();

var app = builder.Build();
app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });

// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

