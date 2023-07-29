
using Book_keeper.Mail_Services;
using Book_keeper.Settings;
using Book_Keeper_DbContext_Layer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddScoped(typeof(Repositories.User.IObjectRepo<>),typeof(Repositories.User.ObjectRepo<>));
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddDbContext<Book_Keeper_DbContext_Layer.DbContextLayer>(Options => Options.UseSqlServer(builder.Configuration
    .GetConnectionString("MVCConnectionString")));

builder.Services.AddDbContext<Book_Keeper_DbContext_Layer.AuthDbContext>(Options => Options.UseSqlServer(builder.Configuration
    .GetConnectionString("AuthDbConnectionString")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();


var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();
builder.Services.Configure<MailSettings>(config.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

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
app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
