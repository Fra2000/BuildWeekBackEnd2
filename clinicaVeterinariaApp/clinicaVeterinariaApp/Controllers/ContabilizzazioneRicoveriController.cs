using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinicaVeterinariaApp.Services.Interfaces;
using clinicaVeterinariaApp.Models.Veterinario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Data;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "VeterinarioPolicy")]
    public class ContabilizzazioneRicoveriController : Controller
    {
        private readonly IContabilizzazioneRicoveriService _contabilizzazioneService;
        private readonly AppDbContext _appDbContext;

        public ContabilizzazioneRicoveriController(IContabilizzazioneRicoveriService contabilizzazioneService, AppDbContext appDbContext)
        {
            _contabilizzazioneService = contabilizzazioneService;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var contabilizzazioni = await _contabilizzazioneService.GetAllContabilizzazioniAsync();
            return View(contabilizzazioni);
        }

        public async Task<IActionResult> Details(int id)
        {
            var contabilizzazione = await _contabilizzazioneService.GetContabilizzazioneByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }
            return View(contabilizzazione);
        }

        public IActionResult Create()
        {
            ViewBag.Ricoveri = _appDbContext.Ricoveri.Where(r => r.Attivo).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContabilizzazioneRicoveri contabilizzazione)
        {
            if (ModelState.IsValid)
            {
                await _contabilizzazioneService.CreateContabilizzazioneAsync(contabilizzazione);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Ricoveri = _appDbContext.Ricoveri.Where(r => r.Attivo).ToList();
            return View(contabilizzazione);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var contabilizzazione = await _contabilizzazioneService.GetContabilizzazioneByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }
            return View(contabilizzazione);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContabilizzazioneRicoveri contabilizzazione)
        {
            if (id != contabilizzazione.ContabilizzazioneID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _contabilizzazioneService.UpdateContabilizzazioneAsync(contabilizzazione);
                return RedirectToAction(nameof(Index));
            }
            return View(contabilizzazione);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contabilizzazione = await _contabilizzazioneService.GetContabilizzazioneByIdAsync(id);
            if (contabilizzazione == null)
            {
                return NotFound();
            }

            return View(contabilizzazione);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contabilizzazioneService.DeleteContabilizzazioneAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
