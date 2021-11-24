using System.ComponentModel.DataAnnotations;

namespace Tarefa.Database.Entities;

public class Pessoa
{
    [Key]
    public Guid Id { get; set; }
    [Required] public string Nome { get; set; } = string.Empty;
    public virtual ICollection<Grupo> Grupos { get; set; }
}