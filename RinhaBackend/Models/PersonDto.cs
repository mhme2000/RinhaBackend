using System.ComponentModel.DataAnnotations;

namespace RinhaBackend.Models;

public class PersonDto
{
    [Required]
    // [MaxLength(32)]
    public string Apelido { get; set; }
    [Required]
    // [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    public string Nascimento { get; set; }
    // [MaxLength(32)]
    public List<string>? Stack { get; set; }
}