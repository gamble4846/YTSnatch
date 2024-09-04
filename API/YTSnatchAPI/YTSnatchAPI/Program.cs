var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "AnyAndAll", builder =>
    {
        _ = builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("AnyAndAll");
app.UseSwagger();
app.UseSwaggerUI();
app.UseWebSockets();
app.UseAuthorization();
app.MapControllers();
app.Run();