//var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
//{
//    ApplicationName = "CustomName",
//    WebRootPath = "wwwroot",
//    ContentRootPath = Directory.GetCurrentDirectory(),
//    EnvironmentName = Environments.Staging

//});

using Autofac.Extensions.DependencyInjection;
using WhatsNewInASPdotnetSix.Services;

var builder = WebApplication.CreateBuilder(args);

var appName = builder.Environment.ApplicationName;
var web = builder.Environment.WebRootPath;
var content = builder.Environment.ContentRootPath;
var envName = builder.Environment.EnvironmentName;


// Add services to the container.
builder.Services.AddControllersWithViews();
//yeni config. dosyası tanımlama:
//builder.Configuration.AddIniFile("appsettings.ini");
builder.Logging.AddConsole();
//Uygulama kapanmadan önce 30 saniye bekle
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

//Windows sunucularda, HTTP.sys dosya tabanlı HTTP server implementasyonu yapacaksanız:
//builder.WebHost.UseHttpSys();

//eğer, custom bir dependency injection provider (örnek: Autofac) eklemek isterseniz, Host üzerinden aşağıdaki kanfigürasyonu yapmalısınız: 
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddSingleton<IProductService, AlternateProductService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

IProductService service = app.Services.GetRequiredService<IProductService>();
ILogger logger = app.Logger;
IHostApplicationLifetime lifetime = app.Lifetime;
IWebHostEnvironment environment = app.Environment;

lifetime.ApplicationStarted.Register(() =>
{
    logger.LogInformation($"{environment.ApplicationName} uygulaması, {service} nesnesini enjekte ederek başladı");
});


app.Logger.LogInformation($"AppName: {appName}\nWebRoot:{web}\nContent:{content}\nEnvName:{envName}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/test", () => "Burası test sayfası!");


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
