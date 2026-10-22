using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LaSaforIT.Web;
using LaSaforIT.Web.Contact;
using LaSaforIT.Web.Site;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.Configure<ContactFormOptions>(builder.Configuration.GetSection(ContactFormOptions.SectionName));
builder.Services.AddScoped<IContactFormService, Web3FormsContactService>();
builder.Services.Configure<SiteOptions>(builder.Configuration.GetSection(SiteOptions.SectionName));

await builder.Build().RunAsync();
