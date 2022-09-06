using Context;
using EntityFrameworkCore.Triggered.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Triggers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTriggeredPooledDbContextFactory<ApplicationDbContext>(options => {
    options
       .UseInMemoryDatabase("PrimarySchool")
       .UseTriggers(triggerOptions => {
           triggerOptions.AddTrigger<AuthorTrigger>();
           triggerOptions.AddTrigger<BookTrigger>();
           triggerOptions.CascadeBehavior(CascadeBehavior.EntityAndType);
           triggerOptions.MaxCascadeCycles(20);
       });
});

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

