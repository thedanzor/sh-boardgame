﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SecretHitler.API.Repositories;
using SecretHitler.Models.Entities;
using System;

namespace SecretHitler.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180118211841_AddedVoteAndChoice")]
    partial class AddedVoteAndChoice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecretHitler.Models.Entities.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChoiceRoundId");

                    b.Property<int>("ChooserId");

                    b.Property<int>("ChosenId");

                    b.Property<DateTime?>("DateCreated");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceRoundId");

                    b.HasIndex("ChooserId");

                    b.HasIndex("ChosenId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.ChoiceRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ChoiceRound");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int>("GameStateId");

                    b.Property<string>("JoinKey");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int?>("Role");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("PolicyType");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<bool>("InFavor");

                    b.Property<int>("VoteRoundId");

                    b.Property<int>("VoterId");

                    b.HasKey("Id");

                    b.HasIndex("VoteRoundId");

                    b.HasIndex("VoterId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.VoteRound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<int>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("VoteRound");
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Choice", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.ChoiceRound", "ChoiceRound")
                        .WithMany()
                        .HasForeignKey("ChoiceRoundId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecretHitler.Models.Entities.Player", "Chooser")
                        .WithMany()
                        .HasForeignKey("ChooserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecretHitler.Models.Entities.Player", "Chosen")
                        .WithMany()
                        .HasForeignKey("ChosenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.ChoiceRound", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.Game", "Game")
                        .WithMany("ChoiceRounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Player", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Policy", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.Game")
                        .WithMany("Policies")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.Vote", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.VoteRound", "VoteRound")
                        .WithMany()
                        .HasForeignKey("VoteRoundId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecretHitler.Models.Entities.Player", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecretHitler.Models.Entities.VoteRound", b =>
                {
                    b.HasOne("SecretHitler.Models.Entities.Game", "Game")
                        .WithMany("VoteRounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
