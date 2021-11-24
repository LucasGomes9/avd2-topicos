using System.ComponentModel.DataAnnotations;

namespace Tarefa.Database.Entities;

public class Grupo
{
    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Pessoa>? Pessoas { get; set; }
    public virtual ICollection<Autenticacao>? Autenticacoes { get; set; }
}