using Microsoft.ApplicationInsights.Extensibility;
using Raffle.Api.Base.Authentication;
using Raffle.Api.Base.Filters;
using Raffle.Api.Base.HealthChecks;
using Raffle.Api.Base.Middlewares;
using Raffle.Infrastructure.Logger;
using Raffle.Api.Base.Extensions;
using Raffle.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddRaffleLogger(configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(AppExceptionFilterAttribute));
});
builder.Services.AddApplicationInsightsTelemetry(configuration);
builder.Services.AddTransient<AddRequestBodyToTelemetryMiddleware>();
builder.Services.AddSingleton<ITelemetryInitializer, FilterHealthchecksTelemetryInitializer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRaffleSwagger();
builder.Services.AddRaffleHealthChecks(configuration);
builder.Services.AddRaffleCors(configuration);

builder.Services.AddApplication(configuration);
builder.Services.AddInfrastructure(configuration);

builder.Services.AddApiKeyAuthentication(builder.Configuration);

builder.Services.AddHostedService<AutoMigrateDbRaffle>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (configuration.GetValue<bool>("ApplicationInsights:IncludeRequestBody"))
{
    app.UseMiddleware<AddRequestBodyToTelemetryMiddleware>();
}

app.UsePathBase(configuration.GetValue("PathBase", string.Empty));

app.UseRaffleCors();
app.UseRaffleHeaders();
app.UseRaffleSwagger(configuration);
app.UseRaffleHealthChecks(configuration);

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
