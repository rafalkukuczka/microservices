using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new[] { new { Id = 1, Name = "Book", Price = 29.99 } });
}