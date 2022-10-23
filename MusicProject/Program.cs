using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entites;
using Entites.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.WriteIndented = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_myAllowOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithMethods("PUT", "DELETE", "GET");
        }
     );
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(optins =>
{
    optins.AddPolicy("Artist",
        policy => policy.RequireRole("Artist"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseCors("_myAllowOrigins");

app.MapControllers();

app.Run();