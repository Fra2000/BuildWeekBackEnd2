using Microsoft.EntityFrameworkCore;
using clinicaVeterinariaApp.Models.Farmacia;
using clinicaVeterinariaApp.Models.Veterinario;

namespace clinicaVeterinariaApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets per i modelli di Farmacia
        public DbSet<Armadio> Armadi { get; set; }
        public DbSet<Cassetto> Cassetto { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Fornitore> Fornitori { get; set; }
        public DbSet<Medicinale> Medicinali { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }

        // DbSets per i modelli di Veterinario
        public DbSet<Animali> Animali { get; set; }
        public DbSet<ContabilizzazioneRicoveri> ContabilizzazioneRicoveri { get; set; }
        public DbSet<Proprietario> Proprietari { get; set; }
        public DbSet<Ricoveri> Ricoveri { get; set; }
        public DbSet<Ruoli> Ruoli { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Visite> Visite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurazioni per le relazioni tra le entità
            modelBuilder.Entity<Armadio>()
                .HasMany(a => a.Cassetto)
                .WithOne(c => c.Armadio)
                .HasForeignKey(c => c.ArmadioID);

            modelBuilder.Entity<Cassetto>()
                .HasMany(c => c.Medicinale)
                .WithOne(m => m.Cassetto)
                .HasForeignKey(m => m.CassettoID);

            modelBuilder.Entity<Medicinale>()
                .HasOne(m => m.Prodotto)
                .WithMany(p => p.Medicinale)
                .HasForeignKey(m => m.ProdottoID);

            modelBuilder.Entity<Vendita>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Vendita)
                .HasForeignKey(v => v.ClienteID);

            modelBuilder.Entity<Vendita>()
                .HasOne(v => v.Prodotto)
                .WithMany(p => p.Vendita)
                .HasForeignKey(v => v.ProdottoID);

            modelBuilder.Entity<Animali>()
                .HasOne(a => a.Proprietario)
                .WithMany(p => p.Animali)
                .HasForeignKey(a => a.ProprietarioID);

            modelBuilder.Entity<ContabilizzazioneRicoveri>()
                .HasOne(c => c.Ricoveri)
                .WithMany(r => r.ContabilizzazioneRicoveri)
                .HasForeignKey(c => c.RicoveroID);

            modelBuilder.Entity<Ricoveri>()
                .HasOne(r => r.Animali)
                .WithMany(a => a.Ricoveri)
                .HasForeignKey(r => r.AnimaleID);

            modelBuilder.Entity<Visite>()
                .HasOne(v => v.Animale)
                .WithMany(a => a.Visite)
                .HasForeignKey(v => v.AnimaleID);

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Ruoli)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RuoloID);

            // Configurazioni di indici univoci
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.CodiceFiscale)
                .IsUnique();

            modelBuilder.Entity<Proprietario>()
                .HasIndex(p => p.Codicefiscale)
                .IsUnique();

            // Configurazioni delle colonne
            modelBuilder.Entity<Prodotto>()
                .Property(p => p.PrezzoUnitario)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Ricoveri>()
                .Property(r => r.Costo)
                .HasColumnType("decimal(10,2)");

            // Configurazioni delle lunghezze massime
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .HasMaxLength(50);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Indirizzo)
                .HasMaxLength(50);

            modelBuilder.Entity<Fornitore>()
                .Property(f => f.Nome)
                .HasMaxLength(50);

            modelBuilder.Entity<Fornitore>()
                .Property(f => f.Recapito)
                .HasMaxLength(20);

            modelBuilder.Entity<Fornitore>()
                .Property(f => f.Indirizzo)
                .HasMaxLength(256);

            modelBuilder.Entity<Prodotto>()
                .Property(p => p.Nome)
                .HasMaxLength(50);

            modelBuilder.Entity<Prodotto>()
                .Property(p => p.ElencoUsi)
                .HasMaxLength(500);

            modelBuilder.Entity<Vendita>()
                .Property(v => v.NumeroRicettaMedica)
                .HasMaxLength(50);

            modelBuilder.Entity<Animali>()
                .Property(a => a.NomeAnimale)
                .HasMaxLength(50);

            modelBuilder.Entity<Animali>()
                .Property(a => a.Tipologia)
                .HasMaxLength(50);

            modelBuilder.Entity<Animali>()
                .Property(a => a.ColoreMantello)
                .HasMaxLength(50);

            modelBuilder.Entity<Ruoli>()
                .Property(r => r.NomeRuolo)
                .HasMaxLength(50);

            modelBuilder.Entity<Users>()
                .Property(u => u.NomeUser)
                .HasMaxLength(50);

            modelBuilder.Entity<Users>()
                .Property(u => u.CognomeUser)
                .HasMaxLength(50);

            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .HasMaxLength(256);

            modelBuilder.Entity<Users>()
                .Property(u => u.PasswordHash)
                .HasMaxLength(50);

            modelBuilder.Entity<Visite>()
                .Property(v => v.EsameObiettivo)
                .HasMaxLength(500);

            modelBuilder.Entity<Visite>()
                .Property(v => v.DescrizioneCura)
                .HasMaxLength(500);

            // Seed Ruoli
            modelBuilder.Entity<Ruoli>().HasData(
                new Ruoli { RuoloID = 1, NomeRuolo = "Veterinario" },
                new Ruoli { RuoloID = 2, NomeRuolo = "Farmacista" },
                new Ruoli { RuoloID = 3, NomeRuolo = "User" }
            );

            modelBuilder.Entity<Armadio>().HasData(
            new Armadio { ArmadioID = 1, CodiceUnivoco = "AR001" },
            new Armadio { ArmadioID = 2, CodiceUnivoco = "AR002" },
            new Armadio { ArmadioID = 3, CodiceUnivoco = "AR003" },
            new Armadio { ArmadioID = 4, CodiceUnivoco = "AR004" },
            new Armadio { ArmadioID = 5, CodiceUnivoco = "AR005" }
        );

            // Seed per i Cassetti
            modelBuilder.Entity<Cassetto>().HasData(
                // Armadio 1
                new Cassetto { CassettoID = 1, NumeroCassetto = 1, ArmadioID = 1 },
                new Cassetto { CassettoID = 2, NumeroCassetto = 2, ArmadioID = 1 },
                new Cassetto { CassettoID = 3, NumeroCassetto = 3, ArmadioID = 1 },
                new Cassetto { CassettoID = 4, NumeroCassetto = 4, ArmadioID = 1 },
                new Cassetto { CassettoID = 5, NumeroCassetto = 5, ArmadioID = 1 },
                new Cassetto { CassettoID = 6, NumeroCassetto = 6, ArmadioID = 1 },
                new Cassetto { CassettoID = 7, NumeroCassetto = 7, ArmadioID = 1 },
                new Cassetto { CassettoID = 8, NumeroCassetto = 8, ArmadioID = 1 },

                // Armadio 2
                new Cassetto { CassettoID = 9, NumeroCassetto = 1, ArmadioID = 2 },
                new Cassetto { CassettoID = 10, NumeroCassetto = 2, ArmadioID = 2 },
                new Cassetto { CassettoID = 11, NumeroCassetto = 3, ArmadioID = 2 },
                new Cassetto { CassettoID = 12, NumeroCassetto = 4, ArmadioID = 2 },
                new Cassetto { CassettoID = 13, NumeroCassetto = 5, ArmadioID = 2 },
                new Cassetto { CassettoID = 14, NumeroCassetto = 6, ArmadioID = 2 },
                new Cassetto { CassettoID = 15, NumeroCassetto = 7, ArmadioID = 2 },
                new Cassetto { CassettoID = 16, NumeroCassetto = 8, ArmadioID = 2 },

                // Armadio 3
                new Cassetto { CassettoID = 17, NumeroCassetto = 1, ArmadioID = 3 },
                new Cassetto { CassettoID = 18, NumeroCassetto = 2, ArmadioID = 3 },
                new Cassetto { CassettoID = 19, NumeroCassetto = 3, ArmadioID = 3 },
                new Cassetto { CassettoID = 20, NumeroCassetto = 4, ArmadioID = 3 },
                new Cassetto { CassettoID = 21, NumeroCassetto = 5, ArmadioID = 3 },
                new Cassetto { CassettoID = 22, NumeroCassetto = 6, ArmadioID = 3 },
                new Cassetto { CassettoID = 23, NumeroCassetto = 7, ArmadioID = 3 },
                new Cassetto { CassettoID = 24, NumeroCassetto = 8, ArmadioID = 3 },

                // Armadio 4
                new Cassetto { CassettoID = 25, NumeroCassetto = 1, ArmadioID = 4 },
                new Cassetto { CassettoID = 26, NumeroCassetto = 2, ArmadioID = 4 },
                new Cassetto { CassettoID = 27, NumeroCassetto = 3, ArmadioID = 4 },
                new Cassetto { CassettoID = 28, NumeroCassetto = 4, ArmadioID = 4 },
                new Cassetto { CassettoID = 29, NumeroCassetto = 5, ArmadioID = 4 },
                new Cassetto { CassettoID = 30, NumeroCassetto = 6, ArmadioID = 4 },
                new Cassetto { CassettoID = 31, NumeroCassetto = 7, ArmadioID = 4 },
                new Cassetto { CassettoID = 32, NumeroCassetto = 8, ArmadioID = 4 },

                // Armadio 5
                new Cassetto { CassettoID = 33, NumeroCassetto = 1, ArmadioID = 5 },
                new Cassetto { CassettoID = 34, NumeroCassetto = 2, ArmadioID = 5 },
                new Cassetto { CassettoID = 35, NumeroCassetto = 3, ArmadioID = 5 },
                new Cassetto { CassettoID = 36, NumeroCassetto = 4, ArmadioID = 5 },
                new Cassetto { CassettoID = 37, NumeroCassetto = 5, ArmadioID = 5 },
                new Cassetto { CassettoID = 38, NumeroCassetto = 6, ArmadioID = 5 },
                new Cassetto { CassettoID = 39, NumeroCassetto = 7, ArmadioID = 5 },
                new Cassetto { CassettoID = 40, NumeroCassetto = 8, ArmadioID = 5 }
                );


        }
    }
}
