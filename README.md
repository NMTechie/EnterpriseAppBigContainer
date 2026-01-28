- [Why the repo name is like this?](#why-the-repo-name-is-like-this)
- [Editor Setup](#editor-setup)
  - [.editorConfig vs Extention recomendation](#editorconfig-vs-extention-recomendation)
  - [devContainer vs testContainer (TO DO)](#devcontainer-vs-testcontainer-to-do)
- [Open Telemetry](#open-telemetry)
  - [The main components of Open Telemetry](#the-main-components-of-open-telemetry)
- [Coding Piece](#coding-piece)
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
## Adoption of Command Chaining
Here the intension is to create pipeline based orchestration through code that will be flexible and configuration driven. It will actually going to execute business rule/steps in a defined sequence and if being changed in configuration then the sequence will be changed. However it will not require any code change. It gives flexibility defining the rule based product offering through orchestration.

## Open Telemetry in .NET
This implementation targets to build a .net application that use open telemetry priciples for observability. Also reduce library specific dependency rather adopt OpTeL framework. 