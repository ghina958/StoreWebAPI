using Microsoft.EntityFrameworkCore;
using DataAccess;
using MediatR;
using StoreWebAPI.Application.Category;
using StoreWebAPI.Services;
using Application.Mapper;
using StoreWebAPI.Application.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreWebDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DataAccess"));
});

builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(typeof(NewProductRequest).Assembly);



var app = builder.Build();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });

app.MapGrpcService<CategoryService>();
app.MapGrpcService<ProductService>();
app.MapGrpcService<OrderService>();
app.MapGrpcService<StoreService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

