<<<<<<< HEAD
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/EAyicavM)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411380)

```markdown
# Document Converters (UPT.DocumentConverters)

Proyecto con convertidores de documentos, pruebas unitarias en formato BDD y CI/CD para generar reportes.

Contenido:
- src/UPT.DocumentConverters — implementa IDocumentConverter y tres convertidores (DOCX, PDF, TXT) y una fábrica.
- tests/UPT.DocumentConverters.Tests — pruebas xUnit + TestStack.BDDfy que crean reportes HTML BDD y usan coverlet para cobertura.
- .github/workflows/ci.yml — workflow de GitHub Actions que ejecuta pruebas, genera cobertura y publica reportes en GitHub Pages.

Cómo probar localmente:
1. Instalar .NET 7 SDK.
2. dotnet restore
3. dotnet build
4. dotnet test --no-build -c Release --results-directory ./TestResults --collect:"XPlat Code Coverage"

Generar reporte HTML de cobertura (instalar reportgenerator):
- dotnet tool install -g dotnet-reportgenerator-globaltool
- reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"./reports/coverage" -reporttypes:Html

Los reportes BDD los genera TestStack.BDDfy durante la ejecución de tests y se guardan en reports/bdd.
```
=======
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411618)
>>>>>>> 89725ef294f15052f27ef6f15f7eaa3f2fd8a6d8
