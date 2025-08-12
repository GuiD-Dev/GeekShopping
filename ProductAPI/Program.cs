using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductAPI.Config;
using ProductAPI.DBContext;
using ProductAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["MySQlConnection:MySQlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 6)))
);

IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(config => AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductAPI V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();