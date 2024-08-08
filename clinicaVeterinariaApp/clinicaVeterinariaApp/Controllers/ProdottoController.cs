using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using clinicaVeterinariaApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Models;


namespace clinicaVeterinariaApp.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly IProdottoService _prodottoService;
        private readonly AppDbContext _appDbContext;
        private readonly IFornitoreService _fornitoreService;
        

        public ProdottoController(IProdottoService prodottoService, AppDbContext appDbContext, IFornitoreService fornitoreService)
        {
            _prodottoService = prodottoService;
            _appDbContext = appDbContext;
            _fornitoreService = fornitoreService;
           
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
        public async Task<IActionResult> Create()
        {
            var fornitori = await _fornitoreService.elencoFornitoriAsync();

            // Converti la lista di Proprietario in SelectListItem
            ViewBag.Fornitori = fornitori.Select(f => new SelectListItem
            {
                Value = f.FornitoreId.ToString(),
                Text = $"{f.Nome} " // Supponendo che tu voglia visualizzare Nome e Cognome
            }).ToList();

            return View();
        }

        // POST: Prodotto/Create
        [HttpPost]
        
        public async Task<IActionResult> Create(CreateprodottoViewModel prodotto, IFormFile FotoProdotto)
        {
            if (FotoProdotto != null && FotoProdotto.Length > 0)
            {
                Console.WriteLine("nome prodotto da creare " + prodotto.FornitoreId); 
                prodotto.FotoProdotto = await ConvertImageToBase64(FotoProdotto);
                var fornitore = await _fornitoreService.getFornitoreByIdAsync(prodotto.FornitoreId);
                Prodotto nuovoprodotto = new Prodotto
                {
                    ProdottoID = prodotto.ProdottoID,
                    FotoProdotto = prodotto.FotoProdotto,
                    Nome = prodotto.Nome,
                    ElencoUsi = prodotto.ElencoUsi,
                    PrezzoUnitario = prodotto.PrezzoUnitario,
                    Fornitore = fornitore,
                };
                await _prodottoService.CreateProdotto(nuovoprodotto);
                return RedirectToAction("Index", "Prodotto");


            }
            // Ricarica la lista dei proprietari in caso di errore
            var fornitori = await _fornitoreService.elencoFornitoriAsync();
            ViewBag.Fornitori = fornitori.Select(f => new SelectListItem
            {
                Value = f.FornitoreId.ToString(),
                Text = $"{f.Nome} "
            }).ToList();
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

            var fornitori = await _fornitoreService.elencoFornitoriAsync();
            ViewBag.Fornitori = fornitori.Select(f => new SelectListItem
            {
                Value = f.FornitoreId.ToString(),
                Text = f.Nome
            }).ToList();

            return View(prodotto);
        }

        // POST: Prodotto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( CreateprodottoViewModel prodotto, IFormFile FotoProdotto)
        {


           
            if (FotoProdotto != null && FotoProdotto.Length > 0)
            {
                Console.WriteLine("errore nella foto");
                prodotto.FotoProdotto=await ConvertImageToBase64(FotoProdotto);
                var fornitore = await _fornitoreService.getFornitoreByIdAsync(prodotto.FornitoreId);
                Prodotto nuovoprodotto = new Prodotto
                {
                    ProdottoID = prodotto.ProdottoID,
                    FotoProdotto = prodotto.FotoProdotto,
                    Nome = prodotto.Nome,
                    ElencoUsi = prodotto.ElencoUsi,
                    PrezzoUnitario = prodotto.PrezzoUnitario,
                    Fornitore = fornitore,
                };

                await _prodottoService.UpdateProdotto(nuovoprodotto);
                return RedirectToAction("Index", "Prodotto");

            }
            // Ricarica la lista dei proprietari in caso di errore
            var product = await _prodottoService.GetAllProdotti();
            ViewBag.Proprietari = product.Select(p => new SelectListItem
            {
                Value = p.ProdottoID.ToString(),
                Text = $"{p.Nome}"
            }).ToList();

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
