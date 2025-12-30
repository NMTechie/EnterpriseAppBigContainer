- [Why the repo name is like this?](#why-the-repo-name-is-like-this)
- [Editor Setup](#editor-setup)
  - [.editorConfig vs Extention recomendation](#editorconfig-vs-extention-recomendation)
  - [devContainer vs testContainer (TO DO)](#devcontainer-vs-testcontainer-to-do)
- [Coding Piece](#coding-piece)
  - [Adoption of Command Chaining](#adoption-of-command-chaining)

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

# Coding Piece
The **src** folder will contain the codes of different use cases and scenarios.
## Adoption of Command Chaining
Here the intension is to create pipeline based orchestration through code that will be flexible and configuration driven. It will actually going to execute business rule/steps in a defined sequence and if being changed in configuration then the sequence will be changed. However it will not require any code change. It gives flexibility defining the rule based product offering through orchestration.