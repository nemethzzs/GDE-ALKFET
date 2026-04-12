using backend.Services;
using System.Threading.Tasks;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoService>();
builder.Services.AddSingleton<HotelService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll",
        p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var mongo = scope.ServiceProvider.GetRequiredService<MongoService>();
    await mongo.SeedSzobak();
}
app.UseCors("allowAll");
// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
