using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Certificate;

public class CertificateReadDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateId { get; set; }

    public required string CertificateName { get; set; } 

    public DateTime CompletionDate { get; set; }

    public required string CertificateLink { get; set; } 

    public int ProfileId { get; set; }
}