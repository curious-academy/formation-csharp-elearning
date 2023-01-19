using DecouverteEFCore.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEFCore
{
    internal class DefaultDbContext : DbContext
    {
        #region Constructors

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        protected DefaultDbContext()
        {
        }
        #endregion

        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Arme>().ToTable("Arme");
            modelBuilder.ApplyConfiguration(new ArmeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnnemyEntityTypeConfiguration());
        }
        #endregion

        #region Properties
        public DbSet<Ennemy> Ennemies { get; set; }

        public DbSet<Arme> Weapons { get; set; }  
        #endregion
    }
}
