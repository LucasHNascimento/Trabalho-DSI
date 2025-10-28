using Microsoft.EntityFrameworkCore;
using Pamonharia.Infrastructure.Data.Context;
using Pamonharia.Infrastructure.IoC; // Importa nosso DI

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews();

// *** NOSSO REGISTRO DE DI ***
// Chama o método de extensão da camada de Infraestrutura
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pamonhas}/{action=Index}/{id?}");

// Executa as Migrations automaticamente ao iniciar (opcional, bom para dev)
// Nota: Em produção, é melhor usar um script de deploy.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    D    {
        var context = services.GetRequiredService<PamonhariaContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations.");
    }
}

app.Run();