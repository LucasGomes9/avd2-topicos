using Microsoft.EntityFrameworkCore;
using Tarefa.Database.Entities;
using Tarefa.Database.Models;

namespace Tarefa.Database.Services;

public class GrupoService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
    public GrupoService(IDbContextFactory<ApplicationDbContext> dbFactory) => _dbFactory = dbFactory;

    public async Task CriarGrupoAsync(CriarGrupoModel model, CancellationToken cancellationToken = default)
    {
        if (Equals(model, null))
            throw new ArgumentNullException(nameof(model));
        await using var db = await _dbFactory.CreateDbContextAsync(cancellationToken);
        await db.Grupos.AddAsync(new() { Nome = model.Nome }, cancellationToken).ConfigureAwait(false);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Grupo>> ProcurarGruposListaAsync(string? searchText)
    {
        await using var db = await _dbFactory.CreateDbContextAsync();
        if (string.IsNullOrEmpty(searchText)) return await db.Grupos.ToArrayAsync();
        return await db.Grupos.Where(s => s.Nome.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)).ToArrayAsync();
    }

    public async Task<IEnumerable<Grupo>> ObterGruposAsync()
    {
        await using var db = await _dbFactory.CreateDbContextAsync();
        return db.Grupos.Include(s => s.Autenticacoes).Include(s => s.Pessoas).ToArray();
    }
}