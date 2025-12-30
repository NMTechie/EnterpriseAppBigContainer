// See https://aka.ms/new-console-template for more information
using ApplicationLayer.BusinessHandlers;
using ApplicationLayer.DTO;
using ApplicationLayer.UseCases.Rule1;
using ApplicationLayer.UseCases.Rule2;
using ApplicationLayer.UseCases.Rule3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var services = new ServiceCollection();
services.AddSingleton(config);

// Register command factories
services.AddTransient<IRuleFactory, BusinessRule1Factory>();
services.AddTransient<IRuleFactory, BusinessRule2Factory>();
services.AddTransient<IRuleFactory, BusinessRule3Factory>();

// Register pipeline builder
services.AddSingleton<RuleEngineBuilderFromConfig>();
services.AddSingleton<RuleEnginePipelineBuilder>();

var serviceProvider = services.BuildServiceProvider();

Console.WriteLine(" Program Started .... config loaded successfully ");

var ruleEngineDefinitionBuilder = serviceProvider.GetRequiredService<RuleEngineBuilderFromConfig>();
var pipelineBuilder = serviceProvider.GetRequiredService<RuleEnginePipelineBuilder>();
// TO DO FROM HERE
var ruleEngineDefinition = ruleEngineDefinitionBuilder.Build();
var category1Pipeline = pipelineBuilder.Build(
                                                ruleEngineDefinition.Definitions
                                               .Where(t=>t.CategoryTypeId==1).First().Rules    
                                              );
var category2Pipeline = pipelineBuilder.Build(
                                                ruleEngineDefinition.Definitions
                                               .Where(t => t.CategoryTypeId == 2).First().Rules
                                              );
var category3Pipeline = pipelineBuilder.Build(
                                                ruleEngineDefinition.Definitions
                                               .Where(t => t.CategoryTypeId == 3).First().Rules
                                              );

Console.WriteLine(" Executing category1Pipeline .... ");
foreach (var command in category1Pipeline)
{
    command.Execute();
}
Console.WriteLine(" Execution of category1Pipeline is finished.... ");

Console.WriteLine(" Executing category2Pipeline .... ");
foreach (var command in category2Pipeline)
{
    command.Execute();
}
Console.WriteLine(" Execution of category2Pipeline is finished.... ");

Console.WriteLine(" Executing category3Pipeline .... ");
foreach (var command in category3Pipeline)
{
    command.Execute();
}
Console.WriteLine(" Execution of category3Pipeline is finished.... ");

Console.WriteLine(" Program Ended .... ");


