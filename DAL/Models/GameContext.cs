using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Models
{
    public class GameContext : DbContext
    {
        public GameContext() : base ("4GameDB")
        {
            Database.SetInitializer<GameContext>(new CreateDatabaseIfNotExists<GameContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Environment>().ToTable("Environment");
            modelBuilder.Entity<Field>().ToTable("Field");

            modelBuilder.Entity<Player>().HasKey(x => x.OID);
            modelBuilder.Entity<Game>().HasKey(x => x.OID);
            modelBuilder.Entity<Environment>().HasKey(x => x.OID);
            modelBuilder.Entity<Field>().HasKey(x => x.OID);

            modelBuilder.Entity<Player>().Property(x => x.Name).HasMaxLength(30);           

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Player> players { get; set; }
        public DbSet<Game> games { get; set; }
        public DbSet<Environment> environment { get; set; }
        public DbSet<Field> field { get; set; }
    }
}
