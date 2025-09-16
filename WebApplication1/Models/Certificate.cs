using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class Certificate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CertificateId { get; set; }

    public string CertificateName { get; set; } = null!;

    public DateTime CompletionDate { get; set; }

    public string CertificateLink { get; set; } = null!;

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
