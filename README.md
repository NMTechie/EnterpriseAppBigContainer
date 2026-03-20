- [Why the repo name is like this?](#why-the-repo-name-is-like-this)
- [Editor Setup](#editor-setup)
  - [.editorConfig vs Extention recomendation](#editorconfig-vs-extention-recomendation)
  - [devContainer vs testContainer (TO DO)](#devcontainer-vs-testcontainer-to-do)
- [Open Telemetry](#open-telemetry)
  - [The main components of Open Telemetry](#the-main-components-of-open-telemetry)
  - [What are exemplars](#what-are-exemplars)
  - [Notes](#notes)
- [MAUI (Multi-platform App UI):](#maui-multi-platform-app-ui)
- [IaaC](#iaac)
  - [Pulumi](#pulumi)
    - [Pulumi Naming Convention](#pulumi-naming-convention)
- [Coding Piece](#coding-piece)
  - [Setting Up VS Code for .NET Development](#setting-up-vs-code-for-net-development)
    - [How to generate launch.json](#how-to-generate-launchjson)
    - [The deatils structure of launch.json](#the-deatils-structure-of-launchjson)
    - [Create a New Project using .NET CLI Templates](#create-a-new-project-using-net-cli-templates)
      - [Create a New Project:](#create-a-new-project)
      - [Manage Solutions (.sln files) like Visual Studio](#manage-solutions-sln-files-like-visual-studio)
      - [More in Project Templates:](#more-in-project-templates)
      - [Nuget Package Management](#nuget-package-management)
      - [How you run multiple project in a solution](#how-you-run-multiple-project-in-a-solution)
    - [What is global.json](#what-is-globaljson)
      - [Where does .NET search for global.json?](#where-does-net-search-for-globaljson)
      - [⚙️ How does global.json behave?](#️-how-does-globaljson-behave)
      - [🛠️ How to create global.json](#️-how-to-create-globaljson)
  - [Adoption of Command Chaining](#adoption-of-command-chaining)
  - [Open Telemetry in .NET](#open-telemetry-in-net)
    - [Adding Trace](#adding-trace)
  - [MAUI (Multi-platform App UI )](#maui-multi-platform-app-ui-)

# Why the repo name is like this?
The main moto is to stick onto one single repo and add technology based experiments in different folder. This will help to maintainence and further promote automation. The final goal is to create better documentation with every single thought and trade-offs and also integrate full automation with the extent possible. 

# Editor Setup
## .editorConfig vs Extention recomendation
When I investigated about the .editorconfig, it has been realized that this is powerful but majorly not seen in large enterprise development scenarios. Reason being that IDE(s) and local development machine and software list are kind of standardized. Even on the new line marker denotation is majorly being handled by the runtime of the programming language (e.g. dotnet core, java, python etc. ) in modern days.

Thus looks for the options that I have through I could enforce / warn about recomended extensions in vscode. It leads me to the path of the extension recomendation technique through workbench recomendation section. Details as below.
> 1. Create a .vscode folder in your project root (if not already present).
> 2. Add or edit the extensions.json file:
> ```JSON
> {
>  "recommendations": [
>    "ms-python.python",
>    "esbenp.prettier-vscode",
>    "ms-vscode.csharp"
>  ],
>  "unwantedRecommendations": [
>    "some.extension-you-do-NOT-want"
>  ]
> }
> ```
> Use the extension IDs from the VS Code Marketplace, not display names.The recommendations array lists extensions you want to strongly recommend.The unwantedRecommendations array (optional) lists extensions you want team members to avoid.
> 
> 3. Commit .vscode/extensions.json to your repo.

## devContainer vs testContainer (TO DO)
<< TO DO >>

# Open Telemetry
The details of the basic things are available at https://opentelemetry.io/docs/. The ![Static Badge](https://img.shields.io/badge/dotnet_specific_implementation-red) could be found here https://opentelemetry.io/docs/languages/dotnet/.

## The main components of Open Telemetry
1. Span :--> A span represents a unit of work or operation. Spans are the building blocks of Traces. For more info please visit https://opentelemetry.io/docs/concepts/signals/traces/#spans
2. Trace :--> Traces give us the big picture of what happens when a request is made to an application. Whether your application is a monolith with a single database or a sophisticated mesh of services, traces are essential to understanding the full “path” a request takes in your application. For more info please visit https://opentelemetry.io/docs/concepts/signals/traces/
3. Metrics :--> A metric is a measurement of a service captured at runtime. The moment of capturing a measurement is known as a metric event, which consists not only of the measurement itself, but also the time at which it was captured and associated metadata. For more info please visit https://opentelemetry.io/docs/concepts/signals/metrics/ 
4. Log :--> A log is a timestamped text record, either structured (recommended) or unstructured, with optional metadata. For more info please visit https://opentelemetry.io/docs/concepts/signals/logs/
5. Context Propagation :--> With context propagation, signals (traces, metrics, and logs) can be correlated with each other, regardless of where they are generated. Although not limited to tracing, context propagation allows traces to build causal information about a system across services that are arbitrarily distributed across process and network boundaries. For more info please visit https://opentelemetry.io/docs/concepts/context-propagation/
6. Baggage :--> In OpenTelemetry, Baggage is contextual information that resides next to context. Baggage is a key-value store, which means it lets you propagate any data you like alongside context. 

## What are exemplars
[Exemplars](https://opentelemetry.io/docs/languages/dotnet/metrics/exemplars/) are example data points for aggregated data. They provide specific context to otherwise general aggregations. One common use case is to gain the ability to correlate metrics to traces (and logs).

Exemplars represent individual measurements that are part of an aggregated metric. They allow you to:
- Link metrics to traces that were active when the measurement was taken
- Identify outliers or interesting data points within aggregated metrics
- Better understand the causes of metric changes by exploring associated traces

> _**At the time of wirtting this article AppInsight does not support the concept of Exemplars like Google Cloud Monitoring or Prometheus+Grafana stack**_

## Notes

> - So, lets say there is controller ..... request lands here .... then it flows through the presentation .... application .... business .... data access .... DB .... layers ......having said that ....... trace probabaly capture the request that lands in presentation and the DB layer as it falls in same transaction ..... but will not be able to info about  presentation .... application .... business .... data access layers ..... probably here the logs come into play ....... r8 ?

You are absolutely right—and your understanding is solid!

Ideally: Instrument as many meaningful layers as possible for tracing, so you can see end-to-end span relationships (but avoid excessive span granularity for performance reasons).

Practically: Most teams instrument entry/exit points and key dependencies for tracing, and rely on logs for finer-grained events, especially in business, application, and data access layers.

Tracing shines for visualizing the flow and timing between layers, if those layers are instrumented. Logs fill in the gaps—providing high-detail context, capturing events not covered by tracing, and helping pinpoint logic and business-level issues within those layers.

# MAUI (Multi-platform App UI):
The Guidence documentaion could be found [here](./ChildReadMes/MAUI.md#maui-guidence)

# IaaC 
Everybody knows about it.
## Pulumi
Lets try it. Documentation link is https://www.pulumi.com/docs/.

> The very first thing that you need to do is 
> https://www.pulumi.com/docs/iac/get-started/azure/configure/

> For a beginner tutorial follow: https://www.youtube.com/watch?v=aW8C6iePwho&list=PL1-YVF0mZ9gn77jus2WAqpzRy9g7m1HN5&index=1


If you want to use DIY backend for Pulumi then follow along https://www.pulumi.com/docs/iac/concepts/state-and-backends/#local-filesystem

For this experiment using local file system so 
```pwsh
az login # required to as Pulumi uses azure login to proceed 
pulumi login file://../PulumiState
pulumi logout
az logout
```

### Pulumi Naming Convention
How Pulumi manages the resource naming and their updates is really interesting. It is worth to understand and available [here](https://www.pulumi.com/docs/iac/concepts/resources/names/#autonaming).

Pulumi [registry link](https://www.pulumi.com/registry/) where you could explore different provider specific option and how to configure them.


# Coding Piece
The **src** folder will contain the codes of different use cases and scenarios.

## Setting Up VS Code for .NET Development
* The main extension that requires C# Dev Kit (by Microsoft). 
* Nuget project manager should be handled by command line interface through vs code integrated terminal
* To work the intellisense properly open the folder in vscode that contain .sln file (in case of multi-project support) or the .csproj file. 
* The above being the constarint you should have your `launch.json` and `task.json` files at the root of your solution folder
* > This opens up an interesting observation. If you look closely then you will realize that `launch.json` and `task.json` files sits inside the `.vscode` folder which is vscode IDE specific. In the same way `.vs` folder is Visual Studio IDE specific.
* Continuing to the above it gives flexibility to define launch technique at different level which is awesome.

_**The "Setup as Startup Project Option"**_ is not available in VS Code rather you need to managed by defining debug configurations in the launch.json file. This file resides at: .vscode/launch.json within your workspace (project) folder.

### How to generate launch.json
1. Go to the Run and Debug tab (sidebar or Ctrl+Shift+D).
2. Click "create a launch.json file", select .NET/C# if prompted.

### The deatils structure of launch.json
Explanation of the Most Important Settings. 
| Property      | What It Does / Example Value                                                                                                                                |
| ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| name          | Displayed in Run/Debug list in VS Code. Any string.                                                                                                         |
| type          | Must be coreclr for .NET/C# debugging.                                                                                                                      |
| request       | "launch" (start new process) or "attach" (attach to running).                                                                                               |
| preLaunchTask | Optionally runs a named task before debugging (like "build").                                                                                               |
| program       | Critical — path to the .NET assembly (.dll) or executable you want to debug. Use variables: ${workspaceFolder} points to the root folder opened in VS Code. |
| args          | Command-line arguments (array of strings).                                                                                                                  |
| cwd           | Current working directory at start.                                                                                                                         |
| stopAtEntry   | true = debugger breaks immediately on startup.                                                                                                              |
| console       | Where app output appears—internalConsole, integratedTerminal, or externalTerminal.                                                                          |
| env           | Environment variables as key-value pairs.                                                                                                                   |
| envFile       | Path to a .env file to load additional environment variables.                                                                                               |
| justMyCode    | true = step through your code only, not dependencies. 
| launchSettingsFilePath    | The path of the launchSettings path of your project that you want to launch through launch.json. 
| launchSettingsProfile    | Specify the profiles that you want to use when launching the application during debug. 

### Create a New Project using .NET CLI Templates
Open your terminal (command prompt, bash, PowerShell, etc.), not in VS Code’s menus.
```sh
dotnet new list
```
You’ll see many choices, like `console`, `classlib`, `webapi`, `mvc`, `wpf`, `maui`, etc.

#### Create a New Project:
```sh
dotnet new console -n MyConsoleApp
```
This creates a ![Static Badge](https://img.shields.io/badge/MyconsoleApp_folder-red) and puts all starter files inside.
```sh
# More Examples
dotnet new classlib -n MyLibrary
dotnet new wpf -n MyWpfApp        # Windows only
dotnet new maui -n MyMauiApp      # Cross-platform UI (extra setup required)
dotnet new worker -n MyWorker     # Background service template
dotnet new blazorserver -n MyBlazorApp
```
Full list at [.NET templates docs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new).

#### Manage Solutions (.sln files) like Visual Studio
Most templates create a single project, not a solution.To create a solution (multi-project setup):
```sh
dotnet new sln -n ExampleOfOpenTelemetry -f sln
dotnet new sln --help
dotnet sln MySolution.sln add MyConsoleApp/MyConsoleApp.csproj
dotnet sln MySolution.sln add MyLibrary/MyLibrary.csproj
```
Then open the folder containing the .sln file in VS Code. if you want to _**Add More Projects to Your Solution**_ then 
```sh
dotnet new classlib -n MyLibrary
dotnet sln add MyLibrary/MyLibrary.csproj
```
#### More in Project Templates:
You can combine options and flags!. Like
```sh
dotnet new webapi -n MyApiApp --framework net8.0
# The most extensive command that could be arised in daily use (check dotnet new webapi --help)
dotnet new webapi -n FirstApi -f net10.0 -au None --exclude-launch-settings false --no-https false --no-openapi true --use-program-main true --use-controllers true -lang C#
```

#### Nuget Package Management

dotnet add path/to/ProjectFile.csproj package PackageName

1. Using the .NET CLI
You can add, remove, or update package sources right from your terminal:

To Add a Custom Source:
sh
dotnet nuget add source "https://custom-source-url/" --name CustomSource
Replace the URL and CustomSource with your actual feed and name.
If your feed requires authentication, see below.
To Remove a Source:
sh
dotnet nuget remove source CustomSource
To List All Sources:
sh
dotnet nuget list source
This modifies your user-level or specified nuget.config.

#### How you run multiple project in a solution

> Follow the example of ExOfOptel in this repo to understnd the scenario better.

You can do this in VS Code by combining a task (to run the “no-debug” project) with a debug launch config (for the project you want to debug), and then trigger both together using a compound configuration.

> when I setup , and started .... vscode said it is waiting for pre-launch task but actually it does not proceed and stuck ..... then I have to press Cntrl + C and then I see the project B started running ..... what happened ?

This usually happens when the preLaunchTask is a long‑running server (e.g., dotnet run, npm start, python app.py) and VS Code is waiting for it to finish before starting your debug config. When you press Ctrl+C, you kill that task, so the debugger proceeds to start Project B—exactly what you observed.
To make VS Code start debugging once Project A is “ready” (not terminated), the task must be marked as a background task and include a problem matcher that tells VS Code when the app is ready.

### What is global.json
global.json is a configuration file used by the .NET CLI to tell it which .NET SDK version to use when running any dotnet command in a directory (or its children).
Microsoft’s documentation states:

> “The global.json file allows you to define which .NET SDK version is used when you run .NET CLI commands.”

👉 Even if multiple SDKs are installed
the CLI will use the SDK version specified in global.json, not the newest one on your machine.

👉 SDK selection is SDK-only
It does not control the runtime version your project targets.
Microsoft clarifies that SDK selection is independent from the runtime target.

#### Where does .NET search for global.json?
The CLI looks for global.json:

In the current directory

If not found → in parent directories, walking up the folder tree.

This means putting a global.json at the root of a repo affects all projects in that repository.

#### ⚙️ How does global.json behave?

- 1️⃣ It locks the SDK version
Example from Microsoft Docs:
``` json

{
  "sdk": {
    "version": "10.0.100"
  }
}
This tells .NET CLI:

“Always use SDK version 10.0.100 in this folder.”

Microsoft states the version must be a full version number like 10.0.100 (no wildcards like 10.0.*).
```
- 2️⃣ It supports roll-forward rules
You can allow using newer SDK versions in the same band.
Example from docs:
``` json

{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestFeature"
  }
}
The docs explain that rollForward determines whether the CLI can use a later SDK version if the exact version is not installed.
```
- 3️⃣ It ensures reproducible builds
This avoids scenarios where:

Developer A builds with SDK 8.0.100
Developer B builds with SDK 8.0.300
CI builds with 9.0-preview

→ Resulting in inconsistent binaries and failures.

#### 🛠️ How to create global.json

- Using .NET CLI:
``` pwsh
dotnet new global.json --sdk-version 10.0.103
```

## Adoption of Command Chaining
Here the intension is to create pipeline based orchestration through code that will be flexible and configuration driven. It will actually going to execute business rule/steps in a defined sequence and if being changed in configuration then the sequence will be changed. However it will not require any code change. It gives flexibility defining the rule based product offering through orchestration.

## Open Telemetry in .NET
This implementation targets to build a .net application that use open telemetry priciples for observability. Also reduce library specific dependency rather adopt OpTeL framework. 

### Adding Trace  
> First add the nuget packges to the project by means to inject OpTel .net dependencies
```sh 
dotnet add .\src\ExOFOpTel\FirstApi\FirstApi.csproj package OpenTelemetry.Extensions.Hosting --version 1.15.0
dotnet add .\src\ExOFOpTel\FirstApi\FirstApi.csproj package OpenTelemetry.Instrumentation.AspNetCore --version 1.15.0
dotnet add .\src\ExOFOpTel\FirstApi\FirstApi.csproj package OpenTelemetry.Exporter.Console --version 1.15.0
```
> Then check whether all dependencies installed successfully 
```sh 
dotnet list .\src\ExOFOpTel\FirstApi\FirstApi.csproj package 
```
> Update the `Program.cs` file with the following code:
```csharp
using System.Diagnostics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Configure OpenTelemetry with tracing and auto-start.
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(serviceName: builder.Environment.ApplicationName))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter());

var app = builder.Build();

app.MapGet("/", () => $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}");

app.Run();

```
## MAUI (Multi-platform App UI )
The details of Implementaion would be found [here](./ChildReadMes/MAUI.md#maui-implementation).