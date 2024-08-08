using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "VeterinarioPolicy")]
    public class ContabilizzazioneRicoveriController : Controller
    {
        private readonly IContabilizzazioneRicoveriService _contabilizzazioneRicoveriService;

        public ContabilizzazioneRicoveriController(IContabilizzazioneRicoveriService contabilizzazioneRicoveriService)
        {
            _contabilizzazioneRicoveriService = contabilizzazioneRicoveriService;
        }

        // GET: ContabilizzazioneRicoveri
        public async Task<IActionResult> Index()
        {
            var contabilizzazioni = await _contabilizzazioneRicoveriService.GetAllAsync();
            return View(contabilizzazioni);
        }

        // GET: ContabilizzazioneRicoveri/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contabilizzazione = await _contabilizzazioneRicoveriService.GetByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }
            return View(contabilizzazione);
        }

        // GET: ContabilizzazioneRicoveri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContabilizzazioneRicoveri/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RicoveroID,DataContabilizzazione,Importo")] ContabilizzazioneRicoveri contabilizzazione)
        {
            if (ModelState.IsValid)
            {
                await _contabilizzazioneRicoveriService.AddAsync(contabilizzazione);
                return RedirectToAction(nameof(Index));
            }
            return View(contabilizzazione);
        }

        // GET: ContabilizzazioneRicoveri/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var contabilizzazione = await _contabilizzazioneRicoveriService.GetByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }
            return View(contabilizzazione);
        }

        // POST: ContabilizzazioneRicoveri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContabilizzazioneID,RicoveroID,DataContabilizzazione,Importo")] ContabilizzazioneRicoveri contabilizzazione)
        {
            if (id != contabilizzazione.ContabilizzazioneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _contabilizzazioneRicoveriService.UpdateAsync(contabilizzazione);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Log the error
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(contabilizzazione);
        }

        // GET: ContabilizzazioneRicoveri/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var contabilizzazione = await _contabilizzazioneRicoveriService.GetByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }
            return View(contabilizzazione);
        }

        // POST: ContabilizzazioneRicoveri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contabilizzazioneRicoveriService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
