using System.Security.Claims;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinicaVeterinariaApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Restituisce la vista con i dettagli del proprietario 
        public async Task<IActionResult> Details()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Recupera l'ID utente dal contesto dell'utente

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); // Restituisce errore 401 se l'ID utente non è disponibile
            }

            Console.WriteLine($"Received userId in Details: {userId}");

            try
            {
                var proprietarioViewModel = _userService.GetProprietarioById(int.Parse(userId));
                return View(proprietarioViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        //Gestisce la visualizzazione degli animali legati al proprietarioId
        [HttpGet]
        public async Task<IActionResult> Animals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Recupera l'ID utente dal contesto dell'utente

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); // Restituisce errore 401 se l'ID utente non è disponibile
            }

            try
            {
                var proprietario = await _userService.GetProprietarioByUserIdAsync(int.Parse(userId));
                var animals = _userService.GetAnimalsByProprietarioId(proprietario.ProprietarioID);
                return View(animals);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        //Gestisce la visualizzazione dei dettali animali compresi ricoveri,e visite 
        [HttpGet]
        public IActionResult AnimalDetails(int animalId)
        {
            try
            {
                var animal = _userService.GetAnimalById(animalId);
                return View(animal);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
