using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEFCore.Configurations
{
    internal class ArmeEntityTypeConfiguration : IEntityTypeConfiguration<Arme>
    {
        public void Configure(EntityTypeBuilder<Arme> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.ToTable("Arme");
        }
    }
}
