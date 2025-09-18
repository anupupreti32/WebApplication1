using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Certificate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateId { get; set; }

    public required string CertificateName { get; set; }

    public DateTime CompletionDate { get; set; }

    public required string CertificateLink { get; set; } 

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
