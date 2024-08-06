using clinicaVeterinariaApp.Data;
using clinicaVeterinariaApp.Models.Veterinario;
using clinicaVeterinariaApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura il contesto del database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura l'autenticazione dei cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // La pagina di login
        options.LogoutPath = "/Account/Logout"; // La pagina di logout
        options.AccessDeniedPath = "/Account/AccessDenied"; // Pagina di accesso negato
    });

// Aggiungi i servizi di account
builder.Services.AddScoped<IAccountService, AccountService>();

// Aggiungi i servizi per i controllori e le viste
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();

// Configura la pipeline delle richieste HTTP
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
