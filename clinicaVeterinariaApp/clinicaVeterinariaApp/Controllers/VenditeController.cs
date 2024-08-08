using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaVeterinariaApp.Controllers
{
    public class VenditeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IVenditeService _VenditeServ;

        public VenditeController(AppDbContext context, IVenditeService VenditeServ)
        {
            _context = context;
            _VenditeServ = VenditeServ;
        }

        //*********************************************************
        //TUTTE LE VENDITE
        public async Task<IActionResult> AllVendite()
        {
            var vendite = await _VenditeServ.GetAllVendite();
            return View(vendite);
        }

        //*********************************************************
        //CREA LE VENDITE

        public async Task<IActionResult> FormVendite()
        {
            ViewBag.prodotti = await _VenditeServ.GetAllProdotti();
            ViewBag.clienti = await _VenditeServ.GetAllClienti();
            return View(); 
        }

        public async Task<IActionResult> SalvaVendite(Vendita vendita)
        {
            await _VenditeServ.CreateVendita(vendita);
            return RedirectToAction("Index", "Home");
        }

        //*********************************************************
        //ELIMINA LE VENDITE
        public async Task<IActionResult> EliminaVendite(int IdVendite)
        {
            await _VenditeServ.DeleteVenditeCall(IdVendite);
            return RedirectToAction("Index", "Home");
        }

        //*********************************************************
        //MODIFICA LE VENDITE
        public async Task<IActionResult> UpdateVendite(int venditaID)
        {
            var vendita = await _context.Vendite.FindAsync(venditaID);
            if (vendita == null)
            {
                return NotFound(); // Restituisci 404 se la vendita non è trovata
            }

            ViewBag.Prodotti = await _VenditeServ.GetAllProdotti();
            ViewBag.Clienti = await _VenditeServ.GetAllClienti();

            return View(vendita); // Passa la vendita al View
        }

        public async Task<IActionResult> EditVendite(Vendita vendita)
        {
            await _VenditeServ.ModificaVend(vendita);
            return RedirectToAction("Index", "Home");
        }

        //*********************************************************
        //SEARCBAR PER RICETTE
        public async Task<IActionResult> SearchBarVendite(string ricetta)
        {
            if (!string.IsNullOrWhiteSpace(ricetta))
            {
                var RisultatoSerchbar = await _VenditeServ.SearchBarVendite(ricetta);
                return View("AllVendite", RisultatoSerchbar);
            }
            else
            {
                var tuttiMedicinalis = await _VenditeServ.GetAllVendite();
                return View("AllVendite", tuttiMedicinalis);
            }
        }
    }
}
