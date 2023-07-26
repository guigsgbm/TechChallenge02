using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Notice
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public DateTime DataPublicacao { get; set; } = DateTime.Now;

    [Required]
    public string Autor { get; set; }
}
