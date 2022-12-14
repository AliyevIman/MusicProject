using Entites;
using Entites.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class MusicDbContext :IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            base.OnConfiguring(option);
            option.UseSqlServer(@"Server=DESKTOP-0LV8GT4\SQLEXPRESS;Database=FinalMusicDB;Trusted_Connection=true;MultipleActiveResultSets=True");
        }
        public DbSet<Music> Musics { get; set; }
        //public DbSet<Musician> Musicians{ get; set; }
        public DbSet<Albums> Albums { get; set; }

        //public DbSet<Genre> Genres{ get; set; }           
        public DbSet<LiveShows> LiveShows { get; set; }
        public DbSet<MusicianShows> MusicianShows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Role { get; set; }
        public DbSet<Slider> Slider{ get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Roles");

        }

    }
}