using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.dtos.Certificate;

public class CertificateUpdateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateId { get; set; }

    public string CertificateName { get; set; } = null!;

    public DateTime CompletionDate { get; set; }

    public string CertificateLink { get; set; } = null!;

    public int ProfileId { get; set; }
}