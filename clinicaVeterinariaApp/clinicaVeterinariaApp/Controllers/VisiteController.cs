using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services;
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
        private readonly IAnimaliService _animaliService;
        public VisiteController(IVisiteService visiteService, IAnimaliService animaliService)
        {
            _visiteService = visiteService;
            _animaliService = animaliService;
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
        public async Task<IActionResult> Create()
        {
            ViewBag.tuttianimali = await _animaliService.GetAllAnimaliAsync();
            return View();
        }

        // POST: Visite/Create
        // Metodo POST: Gestisce l'invio del form per creare una nuova visita
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("AnimaleID,DataVisita,EsameObiettivo,DescrizioneCura")] Visite visita)
{
    // Verifica che il modello sia valido
    Console.WriteLine($"questa e la funzione pe rvisite: {visita.AnimaleID}");
    Console.WriteLine($"questa e la funzione pe rvisite: {visita.VisitaID}");
    Console.WriteLine($"questa e la funzione pe rvisite: {visita.DescrizioneCura}");
    Console.WriteLine($"questa e la funzione pe rvisite: {visita.EsameObiettivo}");
    Console.WriteLine($"questa e la funzione pe rvisite: {visita.DataVisita}");
        try
        {
            // Aggiungi la nuova visita tramite il servizio
            await _visiteService.AddAsync(visita);

            // Reindirizza all'azione Index per visualizzare l'elenco delle visite
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            // Gestione dell'eccezione e log degli errori
            ModelState.AddModelError("", "Si è verificato un errore durante la creazione della visita. Riprova.");
            // Log dell'errore (ad esempio, utilizzando un logger)
        }

    // Se il modello non è valido o si è verificato un errore, ricarica la lista degli animali
    ViewBag.tuttianimali = await _animaliService.GetAllAnimaliAsync();

    // Ritorna la vista con i dati del form per correggere eventuali errori
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
