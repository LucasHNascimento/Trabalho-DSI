using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.Services;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;
using Pamonharia.Infrastructure.Data;
using Pamonharia.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar Banco de Dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

// 2. Configurar Mapster
var config = TypeAdapterConfig.GlobalSettings;
// Mapeamento: Pamonha -> PamonhaViewModel (Flattening: Categoria.Nome -> CategoriaNome)
config.NewConfig<Pamonha, PamonhaViewModel>()
      .Map(dest => dest.CategoriaNome, src => src.Categoria.Nome);

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// 3. Injeção de Dependência
builder.Services.AddScoped<IPamonhaService, PamonhaService>();
builder.Services.AddScoped<IPamonhaRepository, PamonhaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>(); // Novo
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Se não houver categorias, criar uma padrão para testes
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Categorias.Any())
    {
        context.Categorias.Add(new Categoria("Tradicional", "Pamonhas clássicas"));
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();