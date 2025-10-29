using Microsoft.AspNetCore.Mvc;
using Pamonharia.Application.Interfaces; // 1. Referência à camada de Aplicação
using Pamonharia.Web.Models;
using System.Diagnostics;

namespace Pamonharia.Web.Controllers
{
    public class HomeController : Controller
    {
        // 2. Campo para o serviço
        private readonly IPamonhaService _pamonhaService;

        // 3. Injeção de Dependência (DI) via construtor
        public HomeController(IPamonhaService pamonhaService)
        {
            _pamonhaService = pamonhaService;
        }

        // 4. Ação Index agora busca dados
        public async Task<IActionResult> Index()
        {
            // 5. Chama a camada de Aplicação, que chama a de Infra, que chama a de Domínio
            var cardapio = await _pamonhaService.GetAllAsync();
            return View(cardapio); // 6. Envia os ViewModels para a View
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}