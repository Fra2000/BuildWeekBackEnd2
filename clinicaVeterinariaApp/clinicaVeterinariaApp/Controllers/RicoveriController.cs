using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using clinicaVeterinariaApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Data;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "VeterinarioPolicy")]
    public class RicoveriController : Controller
    {
        private readonly IRicoveriService _ricoveriService;
        private readonly IAnimaliService _animaliService;
        private readonly AppDbContext _context;

        public RicoveriController(IRicoveriService ricoveriService, IAnimaliService animaliService, AppDbContext appDbContext)
        {
            _ricoveriService = ricoveriService;
            _animaliService = animaliService;
            _context = appDbContext;
        }

        // Serve la view Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ricoveri = await _ricoveriService.GetAllRicoveriAsync();
            var animali = await _animaliService.GetAllAnimaliAsync();

            var viewModel = ricoveri.Select(r => new RicoveriViewModel
            {
                RicoveriID = r.RicoveriID,
                Tipologia = r.Tipologia,
                Datainizioricovero = r.Datainizioricovero,
                DataFineRicovero = r.DataFineRicovero,
                Costo = r.Costo,
                AnimaleID = r.AnimaleID,
                NomeAnimale = animali.FirstOrDefault(a => a.AnimaleID == r.AnimaleID)?.NomeAnimale,
                MicrochipBit = animali.FirstOrDefault(a => a.AnimaleID == r.AnimaleID)?.MicrochipBit ?? false,
                MicrochipNumber = animali.FirstOrDefault(a => a.AnimaleID == r.AnimaleID)?.MicrochipNumber
            }).ToList();

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var animali = await _animaliService.GetAllAnimaliAsync();
            ViewBag.Animali = animali.Select(a => new SelectListItem
            {
                Value = a.AnimaleID.ToString(),
                Text = a.NomeAnimale
            }).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ricoveri ricovero)
        {
            // Rimuovi gli errori di validazione per i campi opzionali
            ModelState.Remove("Animali");
            ModelState.Remove("ContabilizzazioneRicoveri");

            if (ModelState.IsValid)
            {
                try
                {
                    await _ricoveriService.CreateRicoveriAsync(ricovero);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception
                    // For example, using a logger (ILogger<RicoveriController> logger)
                    // logger.LogError(ex, "An error occurred while creating the Ricoveri.");
                    ModelState.AddModelError("", "An error occurred while creating the Ricoveri.");
                }
            }
            else
            {
                // Log the model validation errors
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    // logger.LogError(error); // Log each error
                    Console.WriteLine(error); // or write to console
                }
            }

            var animali = await _animaliService.GetAllAnimaliAsync();
            ViewBag.Animali = animali.Select(a => new SelectListItem
            {
                Value = a.AnimaleID.ToString(),
                Text = a.NomeAnimale
            }).ToList();

            return View(ricovero);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ricovero = await _ricoveriService.GetRicoveriByIdAsync(id);
            if (ricovero == null)
            {
                return NotFound();
            }

            var animale = await _animaliService.GetAnimaleByIdAsync(ricovero.AnimaleID);
            var viewModel = new RicoveriViewModel
            {
                RicoveriID = ricovero.RicoveriID,
                Tipologia = ricovero.Tipologia,
                Datainizioricovero = ricovero.Datainizioricovero,
                DataFineRicovero = ricovero.DataFineRicovero,
                Costo = ricovero.Costo,
                NomeAnimale = animale?.NomeAnimale,
                MicrochipBit = animale?.MicrochipBit ?? false,
                MicrochipNumber = animale?.MicrochipNumber
            };

            return View(viewModel); // Non specificare il percorso, solo il nome della vista
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ricoveriService.DeleteRicoveriAsync(id);
            return RedirectToAction(nameof(Index));
        }





    }
}
