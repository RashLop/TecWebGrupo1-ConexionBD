using Grupo1Tarea.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers(); 
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
    
builder.Services.AddScoped<Grupo1Tarea.Services.IEventService, Grupo1Tarea.Services.EventService>();
builder.Services.AddScoped<Grupo1Tarea.Repositories.IEventRepository, Grupo1Tarea.Repositories.EventRepository>();

builder.Services.AddScoped<Grupo1Tarea.Services.ITicketService, Grupo1Tarea.Services.TicketService>();
builder.Services.AddScoped<Grupo1Tarea.Repositories.ITicketRepository, Grupo1Tarea.Repositories.TicketRepository>();

builder.Services.AddScoped<Grupo1Tarea.Services.IGuestService, Grupo1Tarea.Services.GuestService>();
builder.Services.AddScoped<Grupo1Tarea.Repositories.IGuestRepository, Grupo1Tarea.Repositories.GuestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
