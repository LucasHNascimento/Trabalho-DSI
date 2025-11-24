using Microsoft.AspNetCore.Mvc;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;

namespace Pamonharia.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _service.GetAllAsync();
            return View(categorias);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Tratamento de erro simples caso existam pamonhas vinculadas (Foreign Key constraint)
            try 
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // Em um cenário real, verifique a exceção específica do SQL Server ou EF Core
                ModelState.AddModelError("", "Não é possível excluir esta categoria pois existem pamonhas vinculadas a ela.");
                var categoria = await _service.GetByIdAsync(id);
                return View(categoria);
            }
        }
    }
}