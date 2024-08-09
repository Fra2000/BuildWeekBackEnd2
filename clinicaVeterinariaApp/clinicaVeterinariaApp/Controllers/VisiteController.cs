using System.Threading.Tasks;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(
            [Bind("AnimaleID,DataVisita,EsameObiettivo,DescrizioneCura")] Visite visita
        )
        {
            try
            {
                await _visiteService.AddAsync(visita);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(
                    "",
                    "Si è verificato un errore durante la creazione della visita. Riprova."
                );
            }
            ViewBag.tuttianimali = await _animaliService.GetAllAnimaliAsync();
            return View(visita);
        }

        // POST: Visite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            Console.WriteLine($"idddddddddddddddddddddddddddddd: {id}");
            ViewBag.tuttianimali = await _animaliService.GetAllAnimaliAsync();
            var visita = await _visiteService.GetByIdAsync(id);
            Console.WriteLine("visitaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + visita.VisitaID.ToString());
            Console.WriteLine("visitaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + visita.EsameObiettivo.ToString());
            return View(visita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSalva(
    [Bind("VisitaID,AnimaleID,DataVisita,EsameObiettivo,DescrizioneCura")] Visite visita
)
        {
                await _visiteService.ModificaVisite(visita);
                return RedirectToAction("Index");
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
