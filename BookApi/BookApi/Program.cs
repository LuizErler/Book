using BookApp.Services;
using BookDomain.Repositories;
using BookDomain.Services;
using BookInfra.Repositories;
using DesafioBackEndInfra;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BaseDb>();

// Adicionar reposit�rios e servi�os
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IAssuntoService, AssuntoService>();
builder.Services.AddScoped<ILivroAppService, LivroAppService>();
builder.Services.AddScoped<IAutorAppService, AutorAppService>();
builder.Services.AddScoped<IAssuntoAppService, AssuntoAppService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.AllowAnyOrigin()  // Permite todas as origens (se necess�rio para testar)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Configurar pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS antes de outros middlewares
app.UseCors("AllowLocalhost");

// Se necess�rio, descomente a linha abaixo durante o desenvolvimento
// app.UseHttpsRedirection();  // Pode ser comentado durante o desenvolvimento, se n�o for usar SSL

app.UseAuthorization();

app.MapControllers();

app.Run();
