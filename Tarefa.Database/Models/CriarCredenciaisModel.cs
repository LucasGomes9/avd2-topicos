using System.ComponentModel.DataAnnotations;

namespace Tarefa.Database.Models;

public class CriarCredenciaisModel
{
    [Required] public string Username { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}