using Microsoft.AspNetCore.Mvc;
using NLog;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config")); //Loglama için Configurasyon.

builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("10second", new CacheProfile() { Duration = 10 }); //Cache
})
.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly) //Presentationdaki controller'larý kullanabilmek için.
.AddNewtonsoftJson();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;  //Post iþleminde hata varsa kodu düzenleniyor.
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration); //ServiceExtensions'daki sql baðlantýmýz.
builder.Services.ConfigureRepositoryManager(); //ServiceExtensions
builder.Services.ConfigureServiceManager(); //ServiceExtensions
builder.Services.ConfigureLoggerService(); //ServiceExtensions
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureDataShapper();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeader();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Logging.ClearProviders(); //Default olarak loglama mekanizmasý var.
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>(); //ExceptionHandler 9.4
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
//Ýf'i kaldýrýrsak hem production hemde development modda swagger çalýþýr.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseResponseCaching();

app.UseHttpCacheHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
