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

        public async Task<IActionResult> AllMedicinali()
        {
            var All = await _MedicineServ.TuttiMedicinali();
            Console.WriteLine(All);
            return View(All);
        }




        //*****************************************************
    }
}
