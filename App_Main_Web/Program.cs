using App_Service;
using App_Service.AuthorizationService;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddSessionAuthServices();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

//Externer service class (data access service , database connection service )
builder.Services.AddDataServices(builder.Configuration);

//session --new added
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.Cookie.Name = "GIMS.Cookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "GIMS.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//session --new added


//builder.Services.AddSessionAuthServices();
//Json Serializer
builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

builder.Services.AddAuthorization();

// Add configuration settings
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//encryption middelware
//app.UseMiddleware<UrlEncryptionMiddleware>();

app.UseSession();
app.UseMiddleware<SessionTimeoutMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Use Area Controller

//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapControllerRoute(
//	  name: "areas",
//	  pattern: "{area:Authorization}/{controller=Menu}/{action=Index}/{id?}"
//	);
//});

app.MapAreaControllerRoute(
            name: "MyArea",
            areaName: "Settings",
            pattern: "Settings/{controller=User}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "AuthorizationArea",
            areaName: "Authorization",
            pattern: "Authorization/{controller=Menu}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=AppLogin}/{id?}");

app.MapControllerRoute(
    name: "encrypted",
    pattern: "e/{encryptedPath}");

app.Run();
