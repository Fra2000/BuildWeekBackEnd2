
using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Controllers
{
    [Authorize(Policy = "VeterinarioPolicy")]
    public class ProprietarioController : Controller
    {
        private readonly ILogger<ProprietarioController> _logger;

		private readonly IProprietarioService _proprietarioService;

        private readonly AppDbContext _context; 

        public ProprietarioController(ILogger<ProprietarioController> logger, AppDbContext context,  IProprietarioService proprietarioService)
		{
            _logger = logger;
            _context = context;


            _proprietarioService = proprietarioService;
        }


        //LISTA Proprietari 
        public async Task<IActionResult> listaProprietari()
        {
            return View(await _proprietarioService.elencoProprietariAsync());
        }


        //CREAZIONE proprietari 
        public IActionResult creazioneProprietario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> creazioneProprietario(ProprietarioModel model)
        {
            if (ModelState.IsValid)
            {
                var proprietario = new Proprietario
                {
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    Codicefiscale = model.Codicefiscale,
                    DataNascita = model.DataNascita
                };

                await _proprietarioService.creazioneProprietarioAsync(proprietario);
                return RedirectToAction("listaProprietari");
            }
            return View(model);
        }


        //MODIFICA 
        public async Task<IActionResult> modificaProprietario(int id)
        {
            var proprietario = await _proprietarioService.getProprietarioByIdAsync(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            var model = new ProprietarioModel
            {
                ProprietarioID = proprietario.ProprietarioID,
                Codicefiscale = proprietario.Codicefiscale,
                Nome = proprietario.Nome,
                Cognome = proprietario.Cognome,
                DataNascita = proprietario.DataNascita
            };
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> modificaProprietario(int id, ProprietarioModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _proprietarioService.modificaProprietarioAsync(id, model.Codicefiscale,model.Cognome, model.Nome, model.DataNascita);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction("listaProprietari");
            }
            return View(model);
        }



        //ELIMINAZIONE

        public async Task<IActionResult> eliminaProprietario(int id)
        {
            var proprietario = await _proprietarioService.getProprietarioByIdAsync(id);
            if (proprietario == null)
            {
                return NotFound();
            }
            return View(proprietario);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminaProprietario(int id, string confirmation)
        {
            if (confirmation == "yes")
            {
                await _proprietarioService.eliminazioneProprietarioAsync(id);
                return RedirectToAction("listaProprietari");
            }
            return RedirectToAction("listaProprietari");
        }



        // Metodo di ricerca
        public IActionResult CercaProprietari(string query)
        {
            var proprietari = _context.Proprietari
                .Where(p => p.Codicefiscale.Contains(query) || p.Nome.Contains(query) || p.Cognome.Contains(query))
                .ToList();

            return PartialView("_ProprietariPartial", proprietari);
        }


    }
}

