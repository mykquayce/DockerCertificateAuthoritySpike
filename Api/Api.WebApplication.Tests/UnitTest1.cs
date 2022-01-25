using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Api.WebApplication.Tests;

public sealed class Fixture : IDisposable
{
	private readonly WebApplicationFactory<Program> _factory;

	public Fixture()
	{
		_factory = new();
		HttpClient = _factory.CreateClient();
	}

	public HttpClient HttpClient { get; }

	public void Dispose() => _factory.Dispose();
}

public class UnitTest1 : IClassFixture<Fixture>
{
	private readonly HttpClient _httpClient;

	public UnitTest1(Fixture fixture)
	{
		_httpClient = fixture.HttpClient;
	}

	[Fact]
	public async Task Test1()
	{
		var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/relay");

		var responseMessage = await _httpClient.SendAsync(requestMessage);

		var responseBody = await responseMessage.Content.ReadAsStringAsync();

		Assert.NotNull(responseMessage);
		Assert.True(System.Net.HttpStatusCode.OK == responseMessage.StatusCode, responseBody);
	}
}
