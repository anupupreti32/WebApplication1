using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Reference;

public class ReferenceUpdateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReferenceId { get; set; }

    public required string ReferenceName { get; set; } 

    public string? ReferenceDescription { get; set; }

    public required string Email { get; set; } 

    public required string ContactNumber { get; set; } 

    public required string Position { get; set; } 

    public int ProfileId { get; set; }
}