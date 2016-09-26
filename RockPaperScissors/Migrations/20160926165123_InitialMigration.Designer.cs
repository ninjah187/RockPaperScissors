using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RockPaperScissors;

namespace rockpaperscissors.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160926165123_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RockPaperScissors.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Player1Id");

                    b.Property<int?>("Player2Id");

                    b.Property<string>("Token");

                    b.Property<int?>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RockPaperScissors.Models.GameStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.Property<int>("Player1Choice");

                    b.Property<int>("Player2Choice");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("RockPaperScissors.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessCode");

                    b.Property<int?>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RockPaperScissors.Models.Game", b =>
                {
                    b.HasOne("RockPaperScissors.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id");

                    b.HasOne("RockPaperScissors.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");

                    b.HasOne("RockPaperScissors.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");
                });

            modelBuilder.Entity("RockPaperScissors.Models.GameStage", b =>
                {
                    b.HasOne("RockPaperScissors.Models.Game", "Game")
                        .WithMany("Stages")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("RockPaperScissors.Models.Player", b =>
                {
                    b.HasOne("RockPaperScissors.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");
                });
        }
    }
}
