using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services;
using clinicaVeterinariaApp.Services.Interfaces;

namespace clinicaVeterinariaApp.Controllers
{
    public class RicoveriController : Controller
    {
        private readonly IRicoveriService _ricoveriService;

        public RicoveriController(IRicoveriService ricoveriService)
        {
            _ricoveriService = ricoveriService;
        }

        // Serve la view Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ricoveri = await _ricoveriService.GetAllRicoveriAsync();
            return View(ricoveri);  // Assicurati di avere una view "Index" sotto Views/Ricoveri
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var ricovero = await _ricoveriService.GetRicoveriByIdAsync(id);
            if (ricovero == null)
                return NotFound();

            return View(ricovero);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();  // Restituisce la view per creare un nuovo ricovero
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Ricoveri ricovero)
        {
            if (!ModelState.IsValid)
                return View(ricovero);

            await _ricoveriService.CreateRicoveriAsync(ricovero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ricovero = await _ricoveriService.GetRicoveriByIdAsync(id);
            if (ricovero == null)
                return NotFound();

            return View(ricovero);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Ricoveri ricovero)
        {
            if (id != ricovero.RicoveriID || !ModelState.IsValid)
                return View(ricovero);

            await _ricoveriService.UpdateRicoveriAsync(ricovero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var ricovero = await _ricoveriService.GetRicoveriByIdAsync(id);
            if (ricovero == null)
                return NotFound();

            return View(ricovero);
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ricoveriService.DeleteRicoveriAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
