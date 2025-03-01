﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using space_colonization_api.Data;

#nullable disable

namespace space_colonization_api.Migrations
{
    [DbContext(typeof(SpaceDbContext))]
    partial class SpaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("space_colonization_api.Data.Captains.Captain", b =>
                {
                    b.Property<int>("CaptainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaptainId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CaptainId");

                    b.ToTable("Captains");
                });

            modelBuilder.Entity("space_colonization_api.Data.Expeditions.Expedition", b =>
                {
                    b.Property<int>("ExpeditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpeditionId"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("ExpeditionId");

                    b.HasIndex("PlanetId");

                    b.HasIndex("TeamId");

                    b.ToTable("Expeditions");
                });

            modelBuilder.Entity("space_colonization_api.Data.Planets.Planet", b =>
                {
                    b.Property<int>("PlanetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanetId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExplored")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLifeSuitable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RobotsOnSite")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("PlanetId");

                    b.HasIndex("StatusId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("space_colonization_api.Data.RobotTeams.RobotTeam", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.Property<int>("ExpeditionId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "RobotId", "ExpeditionId");

                    b.HasIndex("ExpeditionId");

                    b.HasIndex("RobotId");

                    b.ToTable("RobotTeam");
                });

            modelBuilder.Entity("space_colonization_api.Data.Robots.Robot", b =>
                {
                    b.Property<int>("RobotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RobotId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RobotId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("space_colonization_api.Data.Shuttles.Shuttle", b =>
                {
                    b.Property<int>("ShuttleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShuttleId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ShuttleId");

                    b.ToTable("Shuttles");
                });

            modelBuilder.Entity("space_colonization_api.Data.Statuses.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "OK"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "!OK"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "!TODO"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "!En route"
                        });
                });

            modelBuilder.Entity("space_colonization_api.Data.Teams.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<int>("CaptainId")
                        .HasColumnType("int");

                    b.Property<int>("ShuttleId")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("CaptainId")
                        .IsUnique();

                    b.HasIndex("ShuttleId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("space_colonization_api.Data.Expeditions.Expedition", b =>
                {
                    b.HasOne("space_colonization_api.Data.Planets.Planet", "Planet")
                        .WithMany("Expeditions")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("space_colonization_api.Data.Teams.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("space_colonization_api.Data.Planets.Planet", b =>
                {
                    b.HasOne("space_colonization_api.Data.Statuses.Status", "Status")
                        .WithMany("Planets")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("space_colonization_api.Data.RobotTeams.RobotTeam", b =>
                {
                    b.HasOne("space_colonization_api.Data.Expeditions.Expedition", "Expedition")
                        .WithMany()
                        .HasForeignKey("ExpeditionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("space_colonization_api.Data.Robots.Robot", "Robot")
                        .WithMany("RobotTeams")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("space_colonization_api.Data.Teams.Team", "Team")
                        .WithMany("RobotTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Expedition");

                    b.Navigation("Robot");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("space_colonization_api.Data.Teams.Team", b =>
                {
                    b.HasOne("space_colonization_api.Data.Captains.Captain", "Captain")
                        .WithOne("Team")
                        .HasForeignKey("space_colonization_api.Data.Teams.Team", "CaptainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("space_colonization_api.Data.Shuttles.Shuttle", "Shuttle")
                        .WithMany("Teams")
                        .HasForeignKey("ShuttleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Captain");

                    b.Navigation("Shuttle");
                });

            modelBuilder.Entity("space_colonization_api.Data.Captains.Captain", b =>
                {
                    b.Navigation("Team")
                        .IsRequired();
                });

            modelBuilder.Entity("space_colonization_api.Data.Planets.Planet", b =>
                {
                    b.Navigation("Expeditions");
                });

            modelBuilder.Entity("space_colonization_api.Data.Robots.Robot", b =>
                {
                    b.Navigation("RobotTeams");
                });

            modelBuilder.Entity("space_colonization_api.Data.Shuttles.Shuttle", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("space_colonization_api.Data.Statuses.Status", b =>
                {
                    b.Navigation("Planets");
                });

            modelBuilder.Entity("space_colonization_api.Data.Teams.Team", b =>
                {
                    b.Navigation("RobotTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
