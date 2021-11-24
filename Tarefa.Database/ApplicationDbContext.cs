using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Tarefa.Database.Entities;
using Tarefa.Database.Services;

namespace Tarefa.Database;

public class ApplicationDbContextFactory : DbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContextFactory(IServiceProvider serviceProvider, DbContextOptions<ApplicationDbContext> options, IDbContextFactorySource<ApplicationDbContext> factorySource) : base(serviceProvider, options, factorySource)
    {

    }

    public override ApplicationDbContext CreateDbContext()
    {
        return new ApplicationDbContext();
    }
}
public class ApplicationDbContext : DbContext
{
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Grupo> Grupos { get; set; }
    public DbSet<Autenticacao> Autenticacoes { get; set; }


    private readonly bool _migration;
    public ApplicationDbContext() => _migration = true;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_migration)
            optionsBuilder.UseSqlServer("Server=.; Database=Tarefa; User Id = sa; Password=M1yPa4ss!123; "); // não é necessário connectionstring em migrations
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pessoa>().HasMany<Grupo>(s=>s.Grupos).WithMany(s=>s.Pessoas);
        modelBuilder.Entity<Autenticacao>().HasOne<Grupo>(s=>s.Grupo).WithMany(s=>s.Autenticacoes);
    }
}

public static class DatabaseExpose
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        return services
            .AddSingleton<AutenticacaoService>()
            .AddSingleton<PessoaService>()
            .AddSingleton<GrupoService>()
            .AddDbContextFactory<ApplicationDbContext>(x => { x.UseSqlServer(connectionString); });
    }
}