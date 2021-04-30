﻿// <auto-generated />
using System;
using LabNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabNotes.Migrations
{
    [DbContext(typeof(ChemContext))]
    [Migration("20210430172012_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("LabNotes.Compound", b =>
                {
                    b.Property<int>("CompoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brutto")
                        .HasColumnType("TEXT");

                    b.Property<string>("IUPACName")
                        .HasColumnType("TEXT");

                    b.HasKey("CompoundId");

                    b.ToTable("Compounds");
                });

            modelBuilder.Entity("LabNotes.CompoundReaction", b =>
                {
                    b.Property<int>("CompoundReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompoundId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Equivalents")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLimiting")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReactionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompoundReactionId");

                    b.HasIndex("CompoundId");

                    b.HasIndex("ReactionId");

                    b.ToTable("CompoundReaction");
                });

            modelBuilder.Entity("LabNotes.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AtomNumber")
                        .HasColumnType("INTEGER");

                    b.Property<float>("MolarMass")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.HasKey("ElementId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("LabNotes.Reaction", b =>
                {
                    b.Property<int>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ReactionId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("LabNotes.CompoundReaction", b =>
                {
                    b.HasOne("LabNotes.Compound", "Compound")
                        .WithMany("CompoundReactions")
                        .HasForeignKey("CompoundId");

                    b.HasOne("LabNotes.Reaction", "Reaction")
                        .WithMany("CompoundReactions")
                        .HasForeignKey("ReactionId");

                    b.Navigation("Compound");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("LabNotes.Compound", b =>
                {
                    b.Navigation("CompoundReactions");
                });

            modelBuilder.Entity("LabNotes.Reaction", b =>
                {
                    b.Navigation("CompoundReactions");
                });
#pragma warning restore 612, 618
        }
    }
}