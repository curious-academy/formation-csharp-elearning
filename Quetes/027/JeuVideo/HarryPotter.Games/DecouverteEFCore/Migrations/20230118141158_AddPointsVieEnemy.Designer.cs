﻿// <auto-generated />
using DecouverteEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DecouverteEFCore.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20230118141158_AddPointsVieEnemy")]
    partial class AddPointsVieEnemy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DecouverteEFCore.Arme", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<decimal>("Dommages")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arme", (string)null);
                });

            modelBuilder.Entity("DecouverteEFCore.Ennemy", b =>
                {
                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Prenom");

                    b.Property<decimal>("ArmeId")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PointsDeVie")
                        .HasColumnType("int");

                    b.HasKey("Surname");

                    b.HasIndex("ArmeId");

                    b.ToTable("Ennemi", (string)null);
                });

            modelBuilder.Entity("DecouverteEFCore.Ennemy", b =>
                {
                    b.HasOne("DecouverteEFCore.Arme", "Arme")
                        .WithMany()
                        .HasForeignKey("ArmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arme");
                });
#pragma warning restore 612, 618
        }
    }
}
