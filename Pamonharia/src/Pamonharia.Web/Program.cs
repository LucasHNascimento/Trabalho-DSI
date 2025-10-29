using Microsoft.EntityFrameworkCore;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.Services;
using Pamonharia.Infrastructure.Data;
using Pamonharia.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. ADICIONAR SERVIÇOS AO CONTAINER (INJEÇÃO DE DEPENDÊNCIA)

// 1a. Configurar o DbContext (Camada de Infraestrutura)
// Pega a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString,
        // Habilita o Assembly de Migrations para o projeto de Infra
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
);

// 1b. Registrar nossos Serviços e Repositórios (Inversão de Controle)
// Quando um construtor pedir 'IPamonhaService', o DI entregará uma 'PamonhaService'.
builder.Services.AddScoped<IPamonhaService, PamonhaService>();

// Quando um construtor pedir 'IPamonhaRepository', o DI entregará um 'PamonhaRepository'.
builder.Services.AddScoped<IPamonhaRepository, PamonhaRepository>();

// 1c. Adicionar serviços do MVC (Camada de Apresentação)
builder.Services.AddControllersWithViews();

// 2. CONSTRUIR A APLICAÇÃO
var app = builder.Build();

// 3. CONFIGURAR O PIPELINE DE REQUISIÇÕES HTTP

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O HSTS força o navegador a usar HTTPS
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir arquivos CSS, JS e imagens da pasta wwwroot

app.UseRouting(); // Habilita o roteamento

app.UseAuthorization(); // Habilita autorização (não estamos usando, mas é boa prática)

// Define a rota padrão do MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 4. EXECUTAR A APLICAÇÃO
app.Run();