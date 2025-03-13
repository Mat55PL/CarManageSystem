namespace CarDocuments.Application.Documents.Dtos;

public class CreateDocumentDto
{
    public string Name { get; set; } = default!;
    public int CarId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}