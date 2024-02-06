using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
     opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
 
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder=>builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
