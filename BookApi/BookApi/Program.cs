using BookApp.Services;
using BookDomain.Repositories;
using BookDomain.Services;
using BookInfra.Repositories;
using DesafioBackEndInfra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BaseDb>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IAssuntoService, AssuntoService>();
builder.Services.AddScoped<ILivroAppService, LivroAppService>();
builder.Services.AddScoped<IAutorAppService, AutorAppService>();
builder.Services.AddScoped<IAssuntoAppService, AssuntoAppService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.AllowAnyOrigin()  
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");


app.UseAuthorization();

app.MapControllers();

app.Run();
