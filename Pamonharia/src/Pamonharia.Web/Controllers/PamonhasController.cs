using Microsoft.AspNetCore.Mvc;
using Pamonharia.Application.Interfaces;
using Pamonharia.Application.ViewModels;

namespace Pamonharia.Web.Controllers
{
    public class PamonhasController : Controller
    {
        private readonly IPamonhaService _pamonhaService;

        // Injeção de Dependência via construtor
        public PamonhasController(IPamonhaService pamonhaService)
        {
            _pamonhaService = pamonhaService;
        }

        // GET: /Pamonhas
        public async Task<IActionResult> Index()
        {
            var pamonhas = await _pamonhaService.GetAllAsync();
            return View(pamonhas);
        }

        // GET: /Pamonhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Pamonhas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PamonhaViewModel viewModel)
        {
            if (ModelState.IsValid) // Verifica as DataAnnotations
            {
                await _pamonhaService.CreateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel); // Retorna com erros de validação
        }

        // GET: /Pamonhas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _pamonhaService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: /Pamonhas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PamonhaViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _pamonhaService.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Pamonhas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _pamonhaService.GetByIdAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: /Pamonhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pamonhaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}