using Autofac.Extensions.DependencyInjection;
using WebUI.Services;
using WebUI.Modules; // Assuming this contains your RepoServiceModule
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Autofac.Core;
using WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Services (before building the application)

// Register controllers and views
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// Oturum yönetimi yapýlandýrmasý
builder.Services.AddSession(options =>
{
    // Oturum süresi, çerez adý, vb. gibi ayarlarý burada yapabilirsiniz
    options.Cookie.Name = "YourSessionCookieName";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddMyHttpClient<CustomerApiServices>(new Uri(builder.Configuration["BaseUrl"]));
builder.Services.AddMyHttpClient<AuthenticationService>(new Uri(builder.Configuration["BaseUrl"]));
builder.Services.AddMyHttpClient<HomeApiService>(new Uri(builder.Configuration["BaseUrl"]));
builder.Services.AddMyHttpClient<CargoApiServices>(new Uri(builder.Configuration["BaseUrl"]));


// 2. Define flag for conditional Autofac usage (optional)
bool useAutofac = true; // Set this to true or false based on your needs

// 3. Autofac Integration (if applicable)
if (useAutofac)
{
    var containerBuilder = new ContainerBuilder();
    containerBuilder.RegisterModule(new RepoServiceModule());
    containerBuilder.Populate(builder.Services);

    // Autofac container'ý oluþtur
    var container = containerBuilder.Build();

    // AutofacServiceProvider'ý al
    var serviceProvider = new AutofacServiceProvider(container);

    // Uygulamanýn hizmet saðlayýcýsýný AutofacServiceProvider olarak ayarla
    builder.Services.AddSingleton<IServiceProvider>(serviceProvider);
}

// 4. Build the application
var app = builder.Build();

// 5. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // ... other pipeline configuration
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Oturum yönetiminin etkinleþtirilmesi
app.UseAuthorization(); // Yetkilendirme
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Login}/{id?}");
});

app.Run();
