﻿// <auto-generated />
using System;
using CadeOErro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadeOErro.Data.Migrations
{
    [DbContext(typeof(CadeOErroContext))]
    partial class CadeOErroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CadeOErro.Domain.Models.Environment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Environment");
                });

            modelBuilder.Entity("CadeOErro.Domain.Models.Log", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdDate")
                        .HasColumnName("created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("filedDate")
                        .HasColumnName("filed_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("frequency")
                        .HasColumnType("int");

                    b.Property<int>("idEnvironment")
                        .HasColumnName("id_environment")
                        .HasColumnType("int");

                    b.Property<int>("idLogLevel")
                        .HasColumnName("id_log_level")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnName("id_user")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idEnvironment");

                    b.HasIndex("idLogLevel");

                    b.HasIndex("idUser");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("CadeOErro.Domain.Models.LogLevel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("LogLevel");
                });

            modelBuilder.Entity("CadeOErro.Domain.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("createdDate")
                        .HasColumnName("created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CadeOErro.Domain.Models.Log", b =>
                {
                    b.HasOne("CadeOErro.Domain.Models.Environment", "environment")
                        .WithMany("logs")
                        .HasForeignKey("idEnvironment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadeOErro.Domain.Models.LogLevel", "logLevel")
                        .WithMany("logs")
                        .HasForeignKey("idLogLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadeOErro.Domain.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
