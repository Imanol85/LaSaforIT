# CLAUDE.md — La Safor I.T.

> Instrucciones específicas del proyecto. Complementan `~/.claude/CLAUDE.md` (globales).

## Proyecto
**La Safor I.T.** — web estática de captación de clientes.

## Tecnología
- Blazor WebAssembly standalone (plantilla vacía, sin Bootstrap ni páginas de ejemplo)
- Target framework: `net10.0` (SDK 10.0.400)
- Paquetes: `Microsoft.AspNetCore.Components.WebAssembly` 10.0.11, `Microsoft.AspNetCore.Components.WebAssembly.DevServer` 10.0.11
- `Nullable` e `ImplicitUsings` habilitados
- Sin backend ni base de datos

## Estructura
```
LaSaforIT.sln
src/
  LaSaforIT.Web/            Proyecto Blazor WebAssembly
    App.razor               Router (NotFoundPage = Pages.NotFound)
    Program.cs              Arranque del host WebAssembly
    _Imports.razor
    Layout/MainLayout.razor
    Pages/Home.razor
    Pages/NotFound.razor
    Properties/launchSettings.json
    wwwroot/                index.html, css/app.css, icon-192.png
docs/
  explore/ design/ tasks/ verify/ proposals/ specs/ plans/   Artefactos SDD
ESTADO-web-desarrollador.md  Estado de la implementación activa
```

Detalle en los skills de proyecto:
- `.claude/skills/project-structure/SKILL.md`
- `.claude/skills/project-conventions/SKILL.md`
- `.claude/skills/project-restrictions/SKILL.md`

## Comandos frecuentes
```bash
dotnet build --verbosity quiet
dotnet run --project src/LaSaforIT.Web
dotnet publish src/LaSaforIT.Web -c Release
```

## Ramas
- `develop`: rama base **protegida** (sin commits, merges, rebases ni push por Claude Code)
- `work/web-la-safor-it`: rama de trabajo de la implementación activa
- Worktrees feature en `.sdd-worktrees/` (ignorado en `.gitignore`), creados desde la rama de trabajo
- Integración a `develop` únicamente vía Pull Request manual del usuario

## Convenciones de código
[Pendiente de análisis] — el proyecto solo contiene el código generado por la plantilla; las convenciones se fijarán en el DESIGN.

## Datos reales
No inventar datos de contacto, legales ni de marca. Donde falten, usar el marcador literal `[PENDIENTE]`.
