using Infra;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<CompanyContext>(p=>p.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("scon")));
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "Area", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
