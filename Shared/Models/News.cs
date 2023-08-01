using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class News
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Required]
    public string? Author { get; set; }
}
