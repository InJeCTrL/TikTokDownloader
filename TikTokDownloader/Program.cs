using TikTokDownloader;
using TikTokDownloader.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IMediaInfo, MediaInfo>();

var CorsTarget = Environment.GetEnvironmentVariable("corsTarget");
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", p =>
    {
        p.WithOrigins(CorsTarget)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.MapControllers();

app.Run();
