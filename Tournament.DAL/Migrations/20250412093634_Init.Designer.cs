﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tournament.DAL.Data;

#nullable disable

namespace Tournament.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250412093634_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tournament.DAL.Entities.TournamentOfSpanish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountDefeat")
                        .HasColumnType("int");

                    b.Property<int>("CountDraw")
                        .HasColumnType("int");

                    b.Property<int>("CountGoals")
                        .HasColumnType("int");

                    b.Property<int>("CountSkipGoals")
                        .HasColumnType("int");

                    b.Property<int>("CountWin")
                        .HasColumnType("int");

                    b.Property<string>("NameCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameTeam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TournamentsOfSpanish");
                });
#pragma warning restore 612, 618
        }
    }
}
