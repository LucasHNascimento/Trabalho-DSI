using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pamonharia.Application.Services.Interfaces;
using Pamonharia.Application.ViewModels;

namespace Pamonharia.Web.Controllers
{
    public class PamonhasController : Controller
    {
        private readonly IPamonhaAppService _pamonhaAppService;

        // DI injeta o serviço de aplicação
        public PamonhasController(IPamonhaAppService pamonhaAppService)
        {
            _pamonhaAppService = pamonhaAppService;
        }

        // GET: Pamonhas
        public async Task<IActionResult> Index()
        {
            var model = await _pamonhaAppService.GetAllAsync();
            return View(model);
        }

        // GET: Pamonhas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var pamonhaViewModel = await _pamonhaAppService.GetByIdAsync(id.Value);
            if (pamonhaViewModel == null) return NotFound();
            return View(pamonhaViewModel);
        }

        // GET: Pamonhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pamonhas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PamonhaViewModel pamonhaViewModel)
        {
            if (ModelState.IsValid) // Validação (Data Annotations)
            {
                await _pamonhaAppService.AddAsync(pamonhaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(pamonhaViewModel);
        }

        // GET: Pamonhas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var pamonhaViewModel = await _pamonhaAppService.GetByIdAsync(id.Value);
            if (pamonhaViewModel == null) return NotFound();
            return View(pamonhaViewModel);
        }

        // POST: Pamonhas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PamonhaViewModel pamonhaViewModel)
        {
            if (id != pamonhaViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _pamonhaAppService.UpdateAsync(pamonhaViewModel);
                }
                catch (ApplicationException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pamonhaViewModel);
        }

        // GET: Pamonhas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var pamonhaViewModel = await _pamonhaAppService.GetByIdAsync(id.Value);
            if (pamonhaViewModel == null) return NotFound();
            return View(pamonhaViewModel);
        }

        // POST: Pamonhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _pamonhaAppService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}