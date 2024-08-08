using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "VeterinarioPolicy")]
    public class VisiteController : Controller
    {
        private readonly IVisiteService _visiteService;

        public VisiteController(IVisiteService visiteService)
        {
            _visiteService = visiteService;
        }

        // GET: Visite
        public async Task<IActionResult> Index()
        {
            var visite = await _visiteService.GetAllAsync();
            return View(visite);
        }

        // GET: Visite/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var visita = await _visiteService.GetByIdAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            return View(visita);
        }

        // GET: Visite/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimaleID,DataVisita,EsameObiettivo,DescrizioneCura")] Visite visita)
        {
            if (ModelState.IsValid)
            {
                await _visiteService.AddAsync(visita);
                return RedirectToAction(nameof(Index));
            }
            return View(visita);
        }

        // GET: Visite/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var visita = await _visiteService.GetByIdAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            return View(visita);
        }

        // POST: Visite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitaID,AnimaleID,DataVisita,EsameObiettivo,DescrizioneCura")] Visite visita)
        {
            if (id != visita.VisitaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _visiteService.UpdateAsync(visita);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Log the error
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(visita);
        }

        // GET: Visite/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var visita = await _visiteService.GetByIdAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            return View(visita);
        }

        // POST: Visite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _visiteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
