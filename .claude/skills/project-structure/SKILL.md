---
name: project-structure
description: Estructura de la solución La Safor I.T. (Blazor WebAssembly standalone net10.0) — proyectos, carpetas y ficheros clave.
---

# Estructura del proyecto

## Solución
- `LaSaforIT.sln` — un único proyecto: `src/LaSaforIT.Web/LaSaforIT.Web.csproj`

## Proyecto `LaSaforIT.Web`
- SDK: `Microsoft.NET.Sdk.BlazorWebAssembly`
- Target framework: `net10.0`
- `OverrideHtmlAssetPlaceholders` = true (index.html usa placeholders de fingerprint en `_framework/blazor.webassembly#[.{fingerprint}].js`)

| Ruta | Función |
|------|---------|
| `Program.cs` | Crea `WebAssemblyHostBuilder`, registra `App` en `#app`, `HeadOutlet` en `head::after` y `HttpClient` con `BaseAddress` del host |
| `App.razor` | `Router` con `NotFoundPage="typeof(Pages.NotFound)"`, layout por defecto `MainLayout`, `FocusOnNavigate` sobre `h1` |
| `_Imports.razor` | Usings globales de componentes |
| `Layout/MainLayout.razor` | Layout principal |
| `Pages/Home.razor` | Página raíz |
| `Pages/NotFound.razor` | Página 404 del router |
| `wwwroot/index.html` | Documento host (`base href="/"`, `lang="en"`) |
| `wwwroot/css/app.css` | Estilos globales |
| `wwwroot/icon-192.png` | Icono |

## Configuración
- No existe `wwwroot/appsettings.json` todavía.
- No hay base de datos ni backend.

## Artefactos SDD
`docs/explore`, `docs/design`, `docs/tasks`, `docs/verify`, `docs/proposals`, `docs/specs`, `docs/plans`; `ESTADO-web-desarrollador.md` en la raíz.
