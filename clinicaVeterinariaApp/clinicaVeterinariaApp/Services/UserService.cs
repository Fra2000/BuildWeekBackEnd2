using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.UserViewModel;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinicaVeterinariaApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        //Recupero dei proprietari tramite l'Id 
        public ProprietarioViewModel GetProprietarioById(int userId)
        {
            var proprietario = _context.Proprietari
                .Where(p => p.UserID == userId)
                .Select(p => new ProprietarioViewModel
                {
                    ProprietarioId = p.ProprietarioID,
                    Nome = p.Nome,
                    Cognome = p.Cognome,
                    DataNascita = p.DataNascita,
                    CodiceFiscale = p.Codicefiscale,
                    PrenotazioneToken = p.PrenotazioneToken
                })
                .FirstOrDefault();

            if (proprietario == null)
            {
                
                Console.WriteLine($"Proprietario with UserID {userId} not found.");
                throw new KeyNotFoundException("Proprietario not found");
            }

            return proprietario;
        }

        //Recupero dei proprietari tramite userId
        public async Task<Proprietario> GetProprietarioByUserIdAsync(int userId)
        {
            var proprietario = await _context.Proprietari
                                             .Include(p => p.Animali) // Inclusione degli animali
                                             .SingleOrDefaultAsync(p => p.UserID == userId);

            if (proprietario == null)
            {
                throw new KeyNotFoundException("Proprietario not found.");
            }

            return proprietario;
        }

        //Recupero Gli animali associati ai proprietari tramite proprietarioId 
        public IEnumerable<AnimalViewModel> GetAnimalsByProprietarioId(int proprietarioId)
        {
            var animals = _context.Animali
                .Where(a => a.ProprietarioID == proprietarioId)
                .Select(a => new AnimalViewModel
                {
                    AnimalId = a.AnimaleID,
                    NomeAnimale = a.NomeAnimale,
                    Tipologia = a.Tipologia,
                    ColoreMantello = a.ColoreMantello,
                    FotoAnimale = a.FotoAnimale,
                    DataNascita = a.DataNascita,
                    MicrochipBit = a.MicrochipBit,
                    MicrochipNumber = a.MicrochipNumber,
                    DataRegistrazione = a.Dataregistrazione,
                    //recupero delle visite associate all'animale 
                    Visite = a.Visite.Select(v => new VisitViewModel
                    {
                        VisitId = v.VisitaID,
                        DataVisita = v.DataVisita,
                        EsameObiettivo = v.EsameObiettivo,
                        DescrizioneCura = v.DescrizioneCura
                    }).ToList(),
                    //recupero dei ricoveri associati agli animali 
                    Ricoveri = a.Ricoveri.Select(r => new HospitalizationViewModel
                    {
                        HospitalizationId = r.RicoveriID,
                        Tipologia = r.Tipologia,
                        DataInizioRicovero = r.Datainizioricovero,
                        DataFineRicovero = r.DataFineRicovero,
                        Costo = r.Costo,
                        Attivo = r.Attivo
                    }).ToList() 
                })
                .ToList();

            return animals;
        }


        //Recupero Animali dall'Id
        public AnimalViewModel GetAnimalById(int animalId)
        {
            var animal = _context.Animali
                .Where(a => a.AnimaleID == animalId)
                .Select(a => new AnimalViewModel
                {
                    AnimalId = a.AnimaleID,
                    NomeAnimale = a.NomeAnimale,
                    Tipologia = a.Tipologia,
                    ColoreMantello = a.ColoreMantello,
                    FotoAnimale = a.FotoAnimale,
                    DataNascita = a.DataNascita,
                    MicrochipBit = a.MicrochipBit,
                    MicrochipNumber = a.MicrochipNumber,
                    DataRegistrazione = a.Dataregistrazione,
                    Visite = a.Visite.Select(v => new VisitViewModel
                    {
                        VisitId = v.VisitaID,
                        DataVisita = v.DataVisita,
                        EsameObiettivo = v.EsameObiettivo,
                        DescrizioneCura = v.DescrizioneCura
                    }).ToList(),
                    Ricoveri = a.Ricoveri.Select(r => new HospitalizationViewModel
                    {
                        HospitalizationId = r.RicoveriID,
                        Tipologia = r.Tipologia,
                        DataInizioRicovero = r.Datainizioricovero,
                        DataFineRicovero = r.DataFineRicovero,
                        Costo = r.Costo,
                        Attivo = r.Attivo
                    }).ToList()
                })
                .FirstOrDefault();

            if (animal == null)
            {
                throw new KeyNotFoundException("Animal not found");
            }

            return animal;
        }

    }

}
