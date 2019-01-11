using Microsoft.EntityFrameworkCore;
using PetPlayBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.Domain.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Connection> Connections { get; set; }

        public ApplicationDbContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .HasKey(t => new { t.UserId, t.ToyId });

            modelBuilder.Entity<Access>()
                .HasOne(a => a.User)
                .WithMany(u => u.Accesses)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Access>()
               .HasOne(a => a.Toy)
               .WithMany(u => u.Accesses)
               .HasForeignKey(x => x.ToyId);

            modelBuilder.Entity<Connection>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<Connection>()
                .HasOne(a => a.User)
                .WithMany(u => u.Connections)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Connection>()
                .HasOne(a => a.Toy)
                .WithMany(u => u.Connections)
                .HasForeignKey(x => x.ToyId);

            modelBuilder.Entity<Role>().HasData(
                new Role {Id = 1, Name = "Admin"},
                new Role {Id = 2, Name = "Common"});

            modelBuilder.Entity<User>().Property(b => b.RoleId).HasDefaultValue(2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T806O9I\SQLEXPRESS;Initial Catalog=PetPlay;Integrated Security=True");
        }
    }
}
