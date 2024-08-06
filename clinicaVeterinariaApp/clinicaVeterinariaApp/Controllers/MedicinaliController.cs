using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaVeterinariaApp.Controllers
{
    public class MedicinaliController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMedicinaleService _MedicineServ;

        public MedicinaliController(AppDbContext context, IMedicinaleService ServiceMedinale)
        {
            _context = context;
            _MedicineServ = ServiceMedinale;
        }

        public IActionResult Index()
        {
            return View();
        }

        //*****************************************************
        //CREA FORM
        public async Task<IActionResult> CreateMedicinale()
        {
            ViewBag.cassetti = await _MedicineServ.GetAllCassetti();
            ViewBag.prodotti = await _MedicineServ.GetAllProdotti();
            return View();
        }

        //SALVA IL FORM
        public async Task<IActionResult> SalvaMedicinale(Medicinale medicinale)
        {
            Console.WriteLine($"queste sono le informazioni di medicinale su salva medicinale{medicinale.CassettoID}");
            Console.WriteLine($"queste sono le informazioni di medicinale su salva medicinale{medicinale.ProdottoID}");
            await _MedicineServ.CreateMedicinali(medicinale);
            return RedirectToAction("Index", "Home");
        }
        //*****************************************************
        //FUNZIONI CHE FA VEDERE TUTTI I MEDICINALI
        public async Task<IActionResult> AllMedicinali()
        {
            var All = await _MedicineServ.TuttiMedicinali();
            Console.WriteLine(All);
            return View(All);
        }

        //*****************************************************
        //FUNZIONE ELIMINA
        public async Task<IActionResult> DeleteMedicinali(int id)
        {
            await _MedicineServ.DeleteMedicinaleCall(id);

            return RedirectToAction("AllMedicinali");
        }
        //*****************************************************
        //FUNZIONE CHE FA UPDATE

        public async Task<IActionResult> EditMedicinale(int id)
        {
            // Recupera il medicinale da modificare
            var medicinale = await _context.Medicinali.FindAsync(id);

            if (medicinale == null)
            {
                return NotFound();
            }

            // Prepara i dati per la vista
            ViewBag.Cassetti = await _MedicineServ.GetAllCassetti();
            ViewBag.Prodotti = await _MedicineServ.GetAllProdotti();

            return View(medicinale);
        }

        // Salva le modifiche al medicinale esistente
        [HttpPost]
        public async Task<IActionResult> ModificaMedicinale(Medicinale medicinale)
        {
            if (ModelState.IsValid)
            {
                await _MedicineServ.ModificaMed(medicinale);
                return RedirectToAction("AllMedicinali");
            }

            // In caso di errore, ripresenta il modulo di modifica
            ViewBag.Cassetti = await _MedicineServ.GetAllCassetti();
            ViewBag.Prodotti = await _MedicineServ.GetAllProdotti();

            return RedirectToAction("AllMedicinali");
        }

    }
}
