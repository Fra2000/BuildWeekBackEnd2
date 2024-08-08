using System;
using clinicaVeterinariaApp.Models.Farmacia;

namespace clinicaVeterinariaApp.Services.Interfaces
{
	public interface IFornitoreService
	{

        Task<IEnumerable<Fornitore>> elencoFornitoriAsync();

        Task creazioneFornitoreAsync(string Recapito, string Nome, string Indirizzo);

        Task<bool> modificaFornitoreAsync(int FornitoreId, string Recapito, string Nome, string Indirizzo);

        Task<Fornitore> getFornitoreByIdAsync(int FornitoreId);

        Task eliminazioneFornitoreAsync(int FornitoreId);

       

       


    }
}

