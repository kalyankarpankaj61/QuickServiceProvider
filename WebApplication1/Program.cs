using Infra;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<CompanyContext>(p=>p.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("scon")));
builder.Services.AddScoped<ICompanyRepo,CompanyRepo>();
builder.Services.AddScoped<IMainCategoryrepo,MainCategoryRepo>();
builder.Services.AddScoped<ISubCategoryRepo,SubCategoryRepo>();
builder.Services.AddScoped<IDispatchAgencyRepo, DispatchAgencyRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
builder.Services.AddScoped<IServicePhotosRepo, ServicePhotosRepo>();
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
