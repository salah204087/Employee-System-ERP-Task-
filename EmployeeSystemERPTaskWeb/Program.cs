using EmployeeSystemERPTaskWeb;
using EmployeeSystemERPTaskWeb.Services;
using EmployeeSystemERPTaskWeb.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using OfficeOpenXml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddHttpClient<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddHttpClient<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpClient<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddHttpClient<ILanguageLevelService, LanguageLevelService>();
builder.Services.AddScoped<ILanguageLevelService, LanguageLevelService>();
builder.Services.AddHttpClient<ILineOfBusinessService, LineOfBusinessService>();
builder.Services.AddScoped<ILineOfBusinessService, LineOfBusinessService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpClient<IAccountLineOfBusinessService, AccountLineOfBusinessService>();
builder.Services.AddScoped<IAccountLineOfBusinessService, AccountLineOfBusinessService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.Cookie.HttpOnly = true;
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                  options.LoginPath = "/Auth/Login";
                  options.AccessDeniedPath = "/Auth/AccessDenied";
                  options.SlidingExpiration = true;
              });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "excelDownload",
    pattern: "Employee/DownloadEmployeesExcel",
    defaults: new { controller = "Employee", action = "DownloadEmployeesExcel" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
