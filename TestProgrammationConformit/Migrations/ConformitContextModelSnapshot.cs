﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Migrations
{
    [DbContext(typeof(ConformitContext))]
    partial class ConformitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TestProgrammationConformit.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PersonId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Comment", b =>
                {
                    b.HasOne("TestProgrammationConformit.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Event", b =>
                {
                    b.HasOne("TestProgrammationConformit.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TestProgrammationConformit.Models.Event", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}