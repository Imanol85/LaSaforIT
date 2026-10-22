---
name: project-conventions
description: Convenciones de código y de flujo del proyecto La Safor I.T.
---

# Convenciones del proyecto

## Verificadas
- Namespace raíz: `LaSaforIT.Web` (subcarpetas: `LaSaforIT.Web.Layout`, `LaSaforIT.Web.Pages`)
- `Nullable` e `ImplicitUsings` habilitados en el `.csproj`
- Componentes de página en `Pages/`, layouts en `Layout/`
- Estilos: CSS propio en `wwwroot/css/app.css`; sin Bootstrap
- Commits: `<tipo>(<ámbito-funcional>): <descripción imperativa>`, sin códigos de tarea o ticket

## Pendientes
- Nombrado de componentes y secciones: [Pendiente de análisis]
- Uso de CSS aislado (`*.razor.css`): [Pendiente de análisis]
- Patrón de servicios y DI: [Pendiente de análisis]
- Validación de formularios: [Pendiente de análisis]
- Tests: [Pendiente de análisis] — no existe proyecto de tests
