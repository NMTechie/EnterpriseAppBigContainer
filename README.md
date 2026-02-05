- [Why the repo name is like this?](#why-the-repo-name-is-like-this)
- [Editor Setup](#editor-setup)
  - [.editorConfig vs Extention recomendation](#editorconfig-vs-extention-recomendation)
  - [devContainer vs testContainer (TO DO)](#devcontainer-vs-testcontainer-to-do)
- [Open Telemetry](#open-telemetry)
  - [The main components of Open Telemetry](#the-main-components-of-open-telemetry)
- [Coding Piece](#coding-piece)
  - [Setting Up VS Code for .NET Development](#setting-up-vs-code-for-net-development)
    - [How to generate launch.json](#how-to-generate-launchjson)
    - [The deatils structure of launch.json](#the-deatils-structure-of-launchjson)
    - [Create a New Project using .NET CLI Templates](#create-a-new-project-using-net-cli-templates)
      - [Create a New Project:](#create-a-new-project)
      - [Manage Solutions (.sln files) like Visual Studio](#manage-solutions-sln-files-like-visual-studio)
      - [More in Project Templates:](#more-in-project-templates)
  - [Adoption of Command Chaining](#adoption-of-command-chaining)
  - [Open Telemetry in .NET](#open-telemetry-in-net)

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


# Coding Piece
The **src** folder will contain the codes of different use cases and scenarios.

## Setting Up VS Code for .NET Development
* The main extension that requires C# Dev Kit (by Microsoft). 
* Nuget project manager should be handled by command line interface through vs code integrated terminal

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



## Adoption of Command Chaining
Here the intension is to create pipeline based orchestration through code that will be flexible and configuration driven. It will actually going to execute business rule/steps in a defined sequence and if being changed in configuration then the sequence will be changed. However it will not require any code change. It gives flexibility defining the rule based product offering through orchestration.

## Open Telemetry in .NET
This implementation targets to build a .net application that use open telemetry priciples for observability. Also reduce library specific dependency rather adopt OpTeL framework. 

