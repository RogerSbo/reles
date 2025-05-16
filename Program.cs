var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddHttpClient<SonoffService>();

var app = builder.Build();
// Usa CORS
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
