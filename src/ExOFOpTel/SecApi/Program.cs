using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
namespace SecApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Configure OpenTelemetry with tracing and auto-start.
        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService(serviceName: "SecApi", serviceVersion: "1.0.0");
                resource.AddAttributes(new[]
                {
                    new KeyValuePair<string, object>("environment", builder.Environment.EnvironmentName),
                    new KeyValuePair<string, object>("MyCustomText", "Hello from SecApi!")
                });
            })
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddAzureMonitorTraceExporter(options =>
                {
                    options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                })
            )
            .WithMetrics(metrics => metrics
                                    .AddAspNetCoreInstrumentation()
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

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
