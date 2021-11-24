using Blazored.Modal;
using Microsoft.EntityFrameworkCore;
using Tarefa.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBlazoredModal().AddAntDesign();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDatabase("Server=.; Database=Tarefa; User Id = sa; Password=M1yPa4ss!123; ");

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

// inicializar e migrar banco
using (var service = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
{
    // se houver qualquer migração pendente, migrar banco.
    if (service.Database.GetPendingMigrations().Any())
    {
        logger.LogInformation("Migrando banco...");
        service.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
