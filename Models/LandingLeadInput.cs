using System.ComponentModel.DataAnnotations;

namespace Adega.Models;

public sealed class LandingLeadInput
{
    [Required, StringLength(120)]
    public string Nome { get; set; } = "";

    [Required, StringLength(120)]
    public string Empresa { get; set; } = "";

    [Required, Phone, StringLength(30)]
    public string WhatsApp { get; set; } = "";

    [EmailAddress, StringLength(120)]
    public string? Email { get; set; }

    [StringLength(80)]
    public string? Cidade { get; set; }

    [StringLength(40)]
    public string? Segmento { get; set; } // Adega / Loja / Evento / Vinícola

    [StringLength(500)]
    public string? Mensagem { get; set; }

    // Honeypot anti-bot (não renderize para humanos)
    [StringLength(50)]
    public string? Website { get; set; }
}
