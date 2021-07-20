﻿// <auto-generated />
using System;
using Cards.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cards.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Cards.Models.Credit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Batch")
                        .HasColumnType("text");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("IssueDate")
                        .HasColumnType("text");

                    b.Property<string>("QuantityRecords")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("Cards.Models.Logs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FKOperationTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Request")
                        .HasColumnType("text");

                    b.Property<string>("Response")
                        .HasColumnType("text");

                    b.Property<DateTime>("dateCreation")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Cards.Models.OperationTypes", b =>
                {
                    b.Property<int>("OperationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("OperationName")
                        .HasColumnType("text");

                    b.HasKey("OperationTypeId");

                    b.ToTable("OperationTypes");

                    b.HasData(
                        new
                        {
                            OperationTypeId = 1,
                            OperationName = "Authenticate"
                        },
                        new
                        {
                            OperationTypeId = 2,
                            OperationName = "Get"
                        },
                        new
                        {
                            OperationTypeId = 3,
                            OperationName = "GetByCardNumber"
                        },
                        new
                        {
                            OperationTypeId = 4,
                            OperationName = "Post"
                        },
                        new
                        {
                            OperationTypeId = 5,
                            OperationName = "Upload"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
