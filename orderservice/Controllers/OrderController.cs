using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() =>
        Ok(new[] { new { Id = 1, Product = "Book", Quantity = 2 } });

    private readonly IHttpClientFactory _httpClientFactory;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("with-product")]
    public async Task<IActionResult> GetWithProduct()
    {
        var client = _httpClientFactory.CreateClient("product");

        var response = await client.GetAsync("/products");
        var content = await response.Content.ReadAsStringAsync();

        return Ok(new
        {
            OrderId = 1,
            ProductData = JsonDocument.Parse(content)
        });
    }
}