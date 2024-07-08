using CommandsService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICommandRepo,CommandRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


// app.UseHttpsRedirection();
app.MapControllers();
app.Run();

