using Microsoft.AspNetCore.Mvc;

namespace Api.WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class RelayController : ControllerBase
{
	private readonly HttpClient _httpClient;

	public RelayController(IHttpClientFactory httpClientFactory)
	{
		ArgumentNullException.ThrowIfNull(httpClientFactory);
		_httpClient = httpClientFactory.CreateClient(nameof(RelayController));
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var uri = new Uri("/weatherforecast", UriKind.Relative);

		var response = await _httpClient.GetStringAsync(uri);

		return Ok(response);
	}
}
