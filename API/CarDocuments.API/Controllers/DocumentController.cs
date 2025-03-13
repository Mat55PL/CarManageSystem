using CarDocuments.Application.Documents;
using CarDocuments.Application.Documents.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarDocuments.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController(IDocumentsService documentsService) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> GetAllDocuments()
    {
        var documents = await documentsService.GetAllDocuments();
        return Ok(documents);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var document = await documentsService.GetById(id);
        if (document is null)
            return NotFound();
        
        return Ok(document);
    }
    
    [HttpGet("Car/{carId}")]
    public async Task<IActionResult> GetByCarId(int carId)
    {
        var documents = await documentsService.GetByCarId(carId);
        if (!documents.Any())
            return NotFound();
        
        return Ok(documents);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDocumentDto documentCreateDto)
    {
        return Ok("Document created");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDocumentDto documentUpdateDto)
    {
        return Ok("Document updated");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok("Document deleted");
    }
}