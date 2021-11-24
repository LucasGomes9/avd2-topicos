using Microsoft.EntityFrameworkCore;
using Tarefa.Database.Models;

namespace Tarefa.Database.Services;

public class AutenticacaoService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
    public AutenticacaoService(IDbContextFactory<ApplicationDbContext> dbFactory) => _dbFactory = dbFactory;

    public async Task CriarCredenciaisAsync(Guid grupoId, CriarCredenciaisModel model, CancellationToken cancellationToken = default)
    {
        if (Equals(model, null))
            throw new ArgumentNullException(nameof(model));
        
        await using var db = await _dbFactory.CreateDbContextAsync(cancellationToken);
        await db.Autenticacoes.AddAsync(new()
        {
            GrupoId = grupoId, 
            Usuario = model.Username, 
            Senha = model.Password
        }, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }
}