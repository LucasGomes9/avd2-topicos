using System.ComponentModel.DataAnnotations;
using Tarefa.Database.Entities;

namespace Tarefa.Database.Models;

public class CriarPessoaModel
{
    [Required] public string Nome { get; set; } = string.Empty;
    public IList<Grupo> Grupos { get; set; }
}