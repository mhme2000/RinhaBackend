using Microsoft.EntityFrameworkCore;
using RinhaBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddDbContext<PersonContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// using (var scope = app.Services.CreateScope())
// {
//     var dataContext = scope.ServiceProvider.GetRequiredService<PersonContext>();
//     dataContext.Database.Migrate();
// }
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();