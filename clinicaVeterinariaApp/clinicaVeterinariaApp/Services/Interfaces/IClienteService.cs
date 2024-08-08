using System;
using clinicaVeterinariaApp.Models.Farmacia;

namespace clinicaVeterinariaApp.Services.Interfaces
{
	public interface IClienteService
	{
		Task<IEnumerable<Cliente>> elencoClientiAsync();

		Task creazioneClienteAsync(string CodiceFiscale, string Nome, string Indirizzo);

		Task<bool> modificaClienteAsync(int ClienteID, string CodiceFiscale, string Nome, string Indirizzo);

        Task<Cliente> getClienteByIdAsync(int ClienteID);

        Task eliminazioneClienteAsync(int ClienteID);



    }
}





