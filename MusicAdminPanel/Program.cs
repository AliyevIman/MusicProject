using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<MusicDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
//});

//builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>();

//Scopeds
builder.Services.AddDbContext<MusicDbContext>();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MusicDbContext>();

builder.Services.AddScoped<IMusicDal, EfMusicDal>();
builder.Services.AddScoped<IMusicManager, MusicManager>();

builder.Services.AddScoped<IAlbumsDal, EfAlbumsDal>();
builder.Services.AddScoped<IAlbumManager, AlbumManager>();

builder.Services.AddScoped<ITicketDal, EfTicketDal>();
builder.Services.AddScoped<ITicketManager, TicketManager>();

builder.Services.AddScoped<IMusiciansShowsDal, EfMusicianShowDal>();
builder.Services.AddScoped<IMusicianShowManager, MusicianShowsManager>();

builder.Services.AddScoped<IMusicianDal, EfMusicianDal>();
builder.Services.AddScoped<IMusicianManager, MusicianManager>();

builder.Services.AddScoped<ILiveShowsDal, EfLiveShowsDal>();
builder.Services.AddScoped<ILiveShowsManager, LiveShowsManager>();

builder.Services.AddScoped<IMuscianMusicDal, EfMusicianMusicDal>();
builder.Services.AddScoped<IMusicianMusicManager, MusicianMusicManager>();

builder.Services.AddScoped<TokenManager>();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Controllers/Auth/login";
//    options.AccessDeniedPath = "/Controllers/Auth/login";
//});



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

app.UseAuthorization();

//app.MapControllerRoute(
//  name: "default",
//  pattern: "{controller=Dashboard}/{action=Index}/{id?}"
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
