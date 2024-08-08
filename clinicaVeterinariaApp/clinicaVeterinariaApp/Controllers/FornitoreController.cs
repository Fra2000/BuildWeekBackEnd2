using System;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "FarmacistaPolicy")]
    public class FornitoreController : Controller
    {
        private readonly ILogger<FornitoreController> _logger;
        private readonly IFornitoreService _fornitoriService;

        public FornitoreController(ILogger<FornitoreController> logger, IFornitoreService fornitoreService)
        {
            _logger = logger;
            _fornitoriService = fornitoreService;
        }

        // Lista Fornitori
        public async Task<IActionResult> listaFornitori()
        {
            var fornitori = await _fornitoriService.elencoFornitoriAsync();
            return View(fornitori);
        }

        // Creazione Fornitore
        public IActionResult creazioneFornitore()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> creazioneFornitore(FornitoreModel model)
        {
            if (ModelState.IsValid)
            {
                await _fornitoriService.creazioneFornitoreAsync(model.Recapito, model.Nome, model.Indirizzo);
                return RedirectToAction("listaFornitori");
            }
            return View(model);
        }

        // Modifica Fornitore
        public async Task<IActionResult> modificaFornitore(int id)
        {
            var fornitore = await _fornitoriService.getFornitoreByIdAsync(id);
            if (fornitore == null)
            {
                return NotFound();
            }
            var model = new FornitoreModel
            {
                FornitoreId = fornitore.FornitoreId,
                Recapito = fornitore.Recapito,
                Nome = fornitore.Nome,
                Indirizzo = fornitore.Indirizzo
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> modificaFornitore(int id, FornitoreModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _fornitoriService.modificaFornitoreAsync(id, model.Recapito, model.Nome, model.Indirizzo);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction("listaFornitori");
            }
            return View(model);
        }

        // Eliminazione Fornitore
        public async Task<IActionResult> eliminaFornitore(int id)
        {
            var fornitore = await _fornitoriService.getFornitoreByIdAsync(id);
            if (fornitore == null)
            {
                return NotFound();
            }
            return View(fornitore);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminaFornitore(int id, string confirmation)
        {
            if (confirmation == "yes")
            {
                await _fornitoriService.eliminazioneFornitoreAsync(id);
                return RedirectToAction("listaFornitori");
            }
            return RedirectToAction("listaFornitori");
        }
    }
}
