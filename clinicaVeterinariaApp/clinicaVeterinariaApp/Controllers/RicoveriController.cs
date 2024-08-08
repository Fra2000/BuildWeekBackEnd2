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
                MicrochipBit = animali.FirstOrDefault(a => a.AnimaleID == r.AnimaleID)?.MicrochipBit ?? false
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
            if (ModelState.IsValid)
            {
                await _ricoveriService.CreateRicoveriAsync(ricovero);
                return RedirectToAction(nameof(Index));
            }

            var animali = await _animaliService.GetAllAnimaliAsync();
            ViewBag.Animali = animali.Select(a => new SelectListItem
            {
                Value = a.AnimaleID.ToString(),
                Text = a.NomeAnimale
            }).ToList();

            return View(ricovero);
        }





    }
}
