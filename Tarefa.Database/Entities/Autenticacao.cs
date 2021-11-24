using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefa.Database.Entities;

public class Autenticacao
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey(nameof(Grupo))]
    public Guid GrupoId { get; set; }

    public string Usuario { get; set; }
    public string Senha { get; set; }

    public virtual Grupo Grupo { get; set; }
}