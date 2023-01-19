using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEFCore.Configurations
{
    internal class EnnemyEntityTypeConfiguration : IEntityTypeConfiguration<Ennemy>
    {
        public void Configure(EntityTypeBuilder<Ennemy> builder)
        {
            builder.ToTable("Ennemi");
            builder.HasKey(item => item.Surname);
            builder.Property(item => item.Surname).HasColumnName("Prenom");
        }
    }
}
