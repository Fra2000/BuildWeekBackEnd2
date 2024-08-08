using Microsoft.AspNetCore.Mvc;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using clinicaVeterinariaApp.Services.Interfaces;
using clinicaVeterinariaApp.Services;


namespace clinicaVeterinariaApp.Controllers
{
    public class AnimaliController : Controller
    {
        private readonly IAnimaliService _animaliService;
        private readonly AppDbContext _context; // Aggiungi il contesto per accedere direttamente al database
        private readonly IProprietarioService _proprietarioService;

        public AnimaliController(IAnimaliService animaliService, AppDbContext context, IProprietarioService proprietarioService)
        {
            _animaliService = animaliService;
            _context = context;
            _proprietarioService = proprietarioService;
        }

        private async Task<string> ConvertImageToBase64(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }

        public async Task<IActionResult> ElencoAnimali()
        {
            var animali = await _animaliService.GetAllAnimaliAsync();
            return View(animali);
        }

        public async Task<IActionResult> DettagliAnimale(int id)
        {
            var animale = await _animaliService.GetAnimaleByIdAsync(id);
            if (animale == null)
            {
                return NotFound();
            }
            return View(animale);
        }

        public async Task<IActionResult> CreazioneAnimale()
        {
            var proprietari = await _proprietarioService.GetAllProprietariAsync();

            // Converti la lista di Proprietario in SelectListItem
            ViewBag.Proprietari = proprietari.Select(p => new SelectListItem
            {
                Value = p.ProprietarioID.ToString(),
                Text = $"{p.Codicefiscale} " // Supponendo che tu voglia visualizzare Nome e Cognome
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreazioneAnimale(Animali animale, IFormFile FotoAnimale)
        {
            if (FotoAnimale != null && FotoAnimale.Length > 0)
            {
                animale.FotoAnimale = await ConvertImageToBase64(FotoAnimale);
                await _animaliService.CreateAnimaleAsync(animale);
                return RedirectToAction(nameof(ElencoAnimali));

            }

            // Ricarica la lista dei proprietari in caso di errore
            var proprietari = await _proprietarioService.GetAllProprietariAsync();
            ViewBag.Proprietari = proprietari.Select(p => new SelectListItem
            {
                Value = p.ProprietarioID.ToString(),
                Text = $"{p.Codicefiscale} "
            }).ToList();

            return View(animale);
        }

        public async Task<IActionResult> ModificaAnimale(int id)
        {
            var animale = await _animaliService.GetAnimaleByIdAsync(id);
            if (animale == null)
            {
                return NotFound();
            }

            // Ricarica la lista dei proprietari
            var proprietari = await _proprietarioService.GetAllProprietariAsync();
            ViewBag.Proprietari = proprietari.Select(p => new SelectListItem
            {
                Value = p.ProprietarioID.ToString(),
                Text = $"{p.Codicefiscale}"
            }).ToList();

            return View(animale);
        }

        [HttpPost]
        public async Task<IActionResult> ModificaAnimale(Animali animale, IFormFile fotoAnimale)
        {

            if (fotoAnimale != null && fotoAnimale.Length > 0)
            {
                animale.FotoAnimale = await ConvertImageToBase64(fotoAnimale);
                await _animaliService.UpdateAnimaleAsync(animale);
                return RedirectToAction(nameof(ElencoAnimali));
            }


            // Ricarica la lista dei proprietari in caso di errore
            var proprietari = await _proprietarioService.GetAllProprietariAsync();
            ViewBag.Proprietari = proprietari.Select(p => new SelectListItem
            {
                Value = p.ProprietarioID.ToString(),
                Text = $"{p.Codicefiscale}"
            }).ToList();

            return View(animale);
        }

        public async Task<IActionResult> EliminaAnimale(int id)
        {
            var animale = await _animaliService.GetAnimaleByIdAsync(id);
            if (animale == null)
            {
                return NotFound();
            }
            return View(animale);
        }

        [HttpPost, ActionName("EliminaAnimale")]
        public async Task<IActionResult> EliminaAnimaleConfirmed(int id)
        {
            await _animaliService.DeleteAnimaleAsync(id);
            return RedirectToAction(nameof(ElencoAnimali));
        }


    }
}