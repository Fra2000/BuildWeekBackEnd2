using System;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaVeterinariaApp.Controllers
{
	public class ClienteController : Controller
	{
		private readonly IClienteService _clienteService;
        
		private readonly ILogger<ClienteController> _logger;

		public ClienteController(ILogger<ClienteController> logger , IClienteService clienteService)
        {
			_logger = logger;

			_clienteService = clienteService;
		}


		//LISTA CLIENTI 

        public async Task<IActionResult> listaClienti()
        {
            return View(await _clienteService.elencoClientiAsync());
        }


        //CREAZIONE CLIENTE 
        public IActionResult creazioneCliente()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> creazioneCliente(ClienteModel model)
		{
			if(ModelState.IsValid)
			{
				await _clienteService.creazioneClienteAsync(model.CodiceFiscale, model.Nome, model.Indirizzo);
				return RedirectToAction("listaClienti", "Cliente");
			}
			return View(model);
		}



        //MODIFICA CLIENTE

        public async Task<IActionResult> modificaCliente(int id)
        {
            var cliente = await _clienteService.getClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var model = new ClienteModel
            {
                ClienteID = cliente.ClienteID,
                CodiceFiscale = cliente.CodiceFiscale,
                Nome = cliente.Nome,
                Indirizzo = cliente.Indirizzo
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> modificaCliente(int id, ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _clienteService.modificaClienteAsync(id, model.CodiceFiscale, model.Nome, model.Indirizzo);
                if (!success)
                {
                    return NotFound();
                }
                return RedirectToAction("listaClienti");
            }
            return View(model);
        }

        //ELIMINAZIONE

        public async Task<IActionResult> eliminaCliente(int id)
        {
            var cliente = await _clienteService.getClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminaCliente(int id, string confirmation)
        {
            if (confirmation == "yes")
            {
                await _clienteService.eliminazioneClienteAsync(id);
                return RedirectToAction("listaClienti");
            }
            return RedirectToAction("listaClienti");
        }
    }
}