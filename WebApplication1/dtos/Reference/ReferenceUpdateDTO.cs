namespace WebApplication1.dtos.Reference;

public class ReferenceUpdateDTO
{
    public int ReferenceId { get; set; }

    public string ReferenceName { get; set; } = null!;

    public string? ReferenceDescription { get; set; }

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int ProfileId { get; set; }
}