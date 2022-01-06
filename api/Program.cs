using api.Services;
using System.Data.SqlClient;
using Dapper;


var builder = WebApplication.CreateBuilder(args);
//var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSingleton<IDapper, Dapperr>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();