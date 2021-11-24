using Microsoft.EntityFrameworkCore;
using Tarefa.Database.Entities;
using Tarefa.Database.Models;

namespace Tarefa.Database.Services;

public class PessoaService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
    public PessoaService(IDbContextFactory<ApplicationDbContext> dbFactory) => _dbFactory = dbFactory;

    public async Task CriarPessoaAsync(CriarPessoaModel model, CancellationToken token = default)
    {
        if (model is null || !model.Grupos.Any())
            throw new Exception("Por favor, escolha ao menos um grupo.");

        Pessoa pessoa = new() { Nome = model.Nome };

        await using var db = await _dbFactory.CreateDbContextAsync(token);
        await db.Pessoas.AddAsync(pessoa, token);
        await db.SaveChangesAsync(token);

        foreach (var group in model.Grupos)
        {
            group.Pessoas ??= new List<Pessoa>();
            group.Pessoas.Add(pessoa);
            db.Entry(group).State = EntityState.Modified;
        }
        await db.SaveChangesAsync(token);
    }
}