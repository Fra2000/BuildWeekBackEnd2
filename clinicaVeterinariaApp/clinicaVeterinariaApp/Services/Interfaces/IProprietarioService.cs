using System;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Services.Interfaces
{
	public interface IProprietarioService
	{
        Task<IEnumerable<Proprietario>> elencoProprietariAsync();

        Task creazioneProprietarioAsync(Proprietario p);

        Task<bool> modificaProprietarioAsync(int ProprietarioID, string CodiceFiscale, string Nome, string Cognome, DateTime DataNascita);

        Task<Proprietario> getProprietarioByIdAsync(int ProprietarioID);

        Task eliminazioneProprietarioAsync(int ProprietarioID);

        Task<string> GenerateUniqueTokenAsync();

        Task<IEnumerable<Proprietario>> GetAllProprietariAsync();

    }
}

