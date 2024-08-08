using clinicaVeterinariaApp.Data;

using clinicaVeterinariaApp.Services.Interfaces;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura il contesto del database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped<IClienteService, ClienteService>()
    .AddScoped<IFornitoreService, FornitoreService>()
    .AddScoped<IAnimaliService, AnimaliService>()
    .AddScoped<IProprietarioService, ProprietarioService>()
    .AddScoped<IVenditeService, VenditeService>()
    .AddScoped<IMedicinaleService, MedicinaleService>();


// Configura l'autenticazione dei cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // La pagina di login
        options.LogoutPath = "/Account/Logout"; // La pagina di logout
        options.AccessDeniedPath = "/Account/AccessDenied"; // Pagina di accesso negato
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("VeterinarioPolicy", policy =>
        policy.RequireRole("Veterinario"));

    options.AddPolicy("FarmacistaPolicy", policy =>
        policy.RequireRole("Farmacista"));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireRole("User"));
});

// Aggiungi i servizi di account
builder.Services.AddScoped<IAccountService, AccountService>();
// service ricoveri
builder.Services.AddScoped<IRicoveriService, RicoveriService>();
// Add services to the container.
builder.Services.AddTransient<IMedicinaleService, MedicinaleService>();
// servizio per le visite
builder.Services.AddScoped<IVisiteService, VisiteService>();
// servizio per le contabilizzazioni
builder.Services.AddScoped<IContabilizzazioneRicoveriService, ContabilizzazioneRicoveriService>();
// servizio per i prodotti
builder.Services.AddScoped<IProdottoService, ProdottoService>();




builder.Services.AddTransient<IVenditeService, VenditeService>();

// Aggiungi i servizi per i controllori e le viste
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configura l'autenticazione e l'autorizzazione
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
