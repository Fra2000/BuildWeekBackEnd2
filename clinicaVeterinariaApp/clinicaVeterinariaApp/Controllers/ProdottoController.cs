using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace clinicaVeterinariaApp.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly IProdottoService _prodottoService;

        public ProdottoController(IProdottoService prodottoService)
        {
            _prodottoService = prodottoService;
        }

        // GET: Prodotto
        public async Task<IActionResult> Index()
        {
            var prodotti = await _prodottoService.GetAllProdotti();
            return View(prodotti);
        }

        // GET: Prodotto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prodotto = await _prodottoService.GetProdottoById(id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Prodotto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodotto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                await _prodottoService.CreateProdotto(prodotto);
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodotto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var prodotto = await _prodottoService.GetProdottoById(id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodotto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prodotto prodotto)
        {
            if (id != prodotto.ProdottoID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedProdotto = await _prodottoService.UpdateProdotto(id, prodotto);

                if (updatedProdotto == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Prodotto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prodotto = await _prodottoService.GetProdottoById(id);

            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Prodotto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _prodottoService.DeleteProdotto(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
