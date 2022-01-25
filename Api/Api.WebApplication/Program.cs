var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddHttpClient(nameof(Api.WebApplication.Controllers.RelayController), httpClient =>
	{
		var uriString = builder.Configuration["Endpoints:WeatherForecast"];
		httpClient.BaseAddress = new Uri(uriString);
	})
	.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { AllowAutoRedirect = false, });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program { }
#pragma warning restore CA1050 // Declare types in namespaces
