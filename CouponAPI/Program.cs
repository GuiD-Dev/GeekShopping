using AutoMapper;
using CouponAPI.DBContext;
using CouponAPI.DTO;
using CouponAPI.Models;
using CouponAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["MySQlConnection:MySQlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(
    options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 6)))
);

IMapper mapper = new MapperConfiguration(config =>
{
    config.CreateMap<CouponDTO, Coupon>().ReverseMap();
}).CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(config => AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICouponRepository, CouponRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CouponAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CouponAPI V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    Task.Delay(10000).Wait();
    var db = scope.ServiceProvider.GetRequiredService<MySQLContext>();
    db.Database.Migrate();
}

app.Run();
