﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Repository.AppDBContexts;

#nullable disable

namespace TodoList.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TodoList.Core.Entities.Concrete.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts", "dbo");
                });

            modelBuilder.Entity("TodoList.Core.Entities.Concrete.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Todos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "iki ekmek al ve eve git.",
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4586),
                            Date = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4585),
                            IsDone = false,
                            Title = "Ekmek",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "süt al.",
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4589),
                            Date = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4588),
                            IsDone = false,
                            Title = "Süt",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "yoğurt al.",
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4591),
                            Date = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4590),
                            IsDone = false,
                            Title = "Yoğurt",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "un al.",
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4592),
                            Date = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4592),
                            IsDone = false,
                            Title = "Un",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("TodoList.Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4052),
                            FirstName = "Ali",
                            LastName = "Veli"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4104),
                            FirstName = "Ayşe",
                            LastName = "Fatma"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4110),
                            FirstName = "Ali",
                            LastName = "Cengiz"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 10, 18, 9, 8, 59, 524, DateTimeKind.Local).AddTicks(4111),
                            FirstName = "John",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("TodoList.Core.Entities.Concrete.Todo", b =>
                {
                    b.HasOne("TodoList.Core.Entities.Concrete.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoList.Core.Entities.Concrete.User", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
