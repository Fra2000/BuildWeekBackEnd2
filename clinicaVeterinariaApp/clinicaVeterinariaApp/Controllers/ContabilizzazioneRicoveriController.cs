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

            var groupedContabilizzazioni = contabilizzazioni
                .Where(c => c.Ricoveri.Attivo)
                .GroupBy(c => new { c.DataContabilizzazione.Year, c.DataContabilizzazione.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalImporto = g.Sum(c => c.Ricoveri.Costo), 
                    Contabilizzazioni = g.Select(c => new ContabilizzazioneRicoveroViewModel
                    {
                        ContabilizzazioneID = c.ContabilizzazioneID,
                        RicoveroID = c.RicoveroID,
                        NomeAnimale = c.Ricoveri.Animali.NomeAnimale,
                        Datainizioricovero = c.Ricoveri.Datainizioricovero,
                        DataContabilizzazione = c.DataContabilizzazione,
                        Importo = c.Ricoveri.Costo
                    }).ToList()
                })
                .OrderByDescending(g => g.Year)
                .ThenByDescending(g => g.Month)
                .ToList();

            return View(groupedContabilizzazioni);
        }








        public IActionResult Create()
        {
            var ricoveri = _appDbContext.Ricoveri
                .Where(r => r.Attivo)
                .Select(r => new ContabilizzazioneRicoveroViewModel
                {
                    RicoveroID = r.RicoveriID,
                    NomeAnimale = r.Animali.NomeAnimale,
                    Datainizioricovero = r.Datainizioricovero
                })
                .ToList();

            var viewModel = new CreateContabilizzazioneRicoveroViewModel
            {
                RicoveriAttivi = ricoveri,
                ContabilizzazioneRicovero = new ContabilizzazioneRicoveroViewModel()
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateContabilizzazioneRicoveroViewModel viewModel)
        {
            ModelState.Remove("RicoveriAttivi");
            ModelState.Remove("ContabilizzazioneRicovero.NomeAnimale");
            // Log per vedere i dati passati dal form
            Console.WriteLine($"RicoveroID: {viewModel.ContabilizzazioneRicovero.RicoveroID}");
            Console.WriteLine($"DataContabilizzazione: {viewModel.ContabilizzazioneRicovero.DataContabilizzazione}");

            if (ModelState.IsValid)
            {
                // Recupera il ricovero selezionato
                var ricovero = await _appDbContext.Ricoveri
                    .FirstOrDefaultAsync(r => r.RicoveriID == viewModel.ContabilizzazioneRicovero.RicoveroID);

                if (ricovero == null)
                {
                    Console.WriteLine("Errore: Il ricovero selezionato non esiste.");
                    ModelState.AddModelError("", "Il ricovero selezionato non esiste.");
                    viewModel.RicoveriAttivi = _appDbContext.Ricoveri
                        .Where(r => r.Attivo)
                        .Select(r => new ContabilizzazioneRicoveroViewModel
                        {
                            RicoveroID = r.RicoveriID,
                            NomeAnimale = r.Animali.NomeAnimale,
                            Datainizioricovero = r.Datainizioricovero
                        })
                        .ToList();

                    return View(viewModel);
                }

                // Log dell'importo recuperato
                Console.WriteLine($"Importo: {ricovero.Costo}");

                var contabilizzazione = new ContabilizzazioneRicoveri
                {
                    RicoveroID = viewModel.ContabilizzazioneRicovero.RicoveroID,
                    DataContabilizzazione = viewModel.ContabilizzazioneRicovero.DataContabilizzazione,
                    Importo = ricovero.Costo  // Recupera l'importo dal modello Ricoveri
                };

                await _contabilizzazioneService.CreateContabilizzazioneAsync(contabilizzazione);
                Console.WriteLine("Contabilizzazione creata con successo.");
                return RedirectToAction(nameof(Index));
            }

            // Log degli errori del ModelState
            Console.WriteLine("Errore: ModelState non valido.");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
            }

            // Ripopola la lista dei ricoveri attivi in caso di errore
            viewModel.RicoveriAttivi = _appDbContext.Ricoveri
                .Where(r => r.Attivo)
                .Select(r => new ContabilizzazioneRicoveroViewModel
                {
                    RicoveroID = r.RicoveriID,
                    NomeAnimale = r.Animali.NomeAnimale,
                    Datainizioricovero = r.Datainizioricovero
                })
                .ToList();

            return View(viewModel);
        }








       

        


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _contabilizzazioneService.DeleteContabilizzazioneAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
