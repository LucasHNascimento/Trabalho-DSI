using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;

namespace Pamonharia.Web.Controllers
{
    public class PamonhasController : Controller
    {
        private readonly IPamonhaService _pamonhaService;
        private readonly ICategoriaRepository _categoriaRepository;

        public PamonhasController(IPamonhaService pamonhaService, ICategoriaRepository categoriaRepository)
        {
            _pamonhaService = pamonhaService;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pamonhas = await _pamonhaService.GetAllAsync();
            return View(pamonhas);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string term)
        {
            var pamonhas = await _pamonhaService.GetAllAsync();
            if (!string.IsNullOrEmpty(term))
            {
                pamonhas = pamonhas.Where(p => 
                    p.Sabor.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    (p.CategoriaNome != null && p.CategoriaNome.Contains(term, StringComparison.OrdinalIgnoreCase))
                );
            }
            return PartialView("_TabelaPamonhas", pamonhas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(await _categoriaRepository.GetAllAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PamonhaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _pamonhaService.CreateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(await _categoriaRepository.GetAllAsync(), "Id", "Nome", viewModel.CategoriaId);
            return View(viewModel);
        }

        // --- EDITAR ---
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _pamonhaService.GetByIdAsync(id);
            if (viewModel == null) return NotFound();

            ViewBag.Categorias = new SelectList(await _categoriaRepository.GetAllAsync(), "Id", "Nome", viewModel.CategoriaId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PamonhaViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _pamonhaService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(await _categoriaRepository.GetAllAsync(), "Id", "Nome", viewModel.CategoriaId);
            return View(viewModel);
        }

        // --- EXCLUIR ---
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _pamonhaService.GetByIdAsync(id);
            if (viewModel == null) return NotFound();
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pamonhaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}