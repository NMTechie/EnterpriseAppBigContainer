using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace FirstApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Register IHttpClientFactory
        builder.Services.AddHttpClient();
        // Configure OpenTelemetry with tracing and auto-start.
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService(serviceName: "FirstApi", serviceVersion: "1.0.0");
                resource.AddAttributes(new[]
                {
                    new KeyValuePair<string, object>("environment", builder.Environment.EnvironmentName),
                    new KeyValuePair<string, object>("MyCustomText", "Hello from FirstApi!")
                });
            })
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddConsoleExporter()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                })
            )
            .WithMetrics(metrics => metrics
                                    .AddAspNetCoreInstrumentation()
                                    .AddConsoleExporter((exporterOptions, metricReaderOptions) =>
                                    {
                                        metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 1000;
                                    })
                                    .AddAzureMonitorMetricExporter(options =>
                                    {
                                        options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                                    })
            )
            .WithLogging(logging => logging
                                    .AddAzureMonitorLogExporter(options =>
                                    {
                                        options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                                    })
            );

        var app = builder.Build();
        app.Logger.LogInformation("Application Starting Up");

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
