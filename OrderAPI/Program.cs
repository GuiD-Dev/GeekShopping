using Microsoft.EntityFrameworkCore;
using OrderAPI.DBContext;
using OrderAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["MySQlConnection:MySQlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 6)))
);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderAPI v1"));
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
