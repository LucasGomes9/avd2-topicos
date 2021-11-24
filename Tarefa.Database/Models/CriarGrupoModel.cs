using System.ComponentModel.DataAnnotations;

namespace Tarefa.Database.Models;

public class CriarGrupoModel
{
    [Required] public string Nome { get; set; } = string.Empty;
}