﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBOBackEnd;

namespace TBOBackEnd.Migrations
{
    [DbContext(typeof(_AppDbContext))]
    [Migration("20190613164843_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBOBackEnd.Models.Admin", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminRoleId")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastAccessedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AdminRoleId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminPermission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AdminPermissions");
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AdminRoles");
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminRolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminPermissionId")
                        .IsRequired();

                    b.Property<string>("AdminRoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdminPermissionId");

                    b.HasIndex("AdminRoleId");

                    b.ToTable("AdminRolePermission");
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminId")
                        .IsRequired();

                    b.Property<DateTime>("LastAccessedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("AdminTokens");
                });

            modelBuilder.Entity("TBOBackEnd.Models.Admin", b =>
                {
                    b.HasOne("TBOBackEnd.Models.AdminRole", "AdminRole")
                        .WithMany("Admins")
                        .HasForeignKey("AdminRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminRolePermission", b =>
                {
                    b.HasOne("TBOBackEnd.Models.AdminPermission", "AdminPermission")
                        .WithMany("AdminRolePermissions")
                        .HasForeignKey("AdminPermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBOBackEnd.Models.AdminRole", "AdminRole")
                        .WithMany("AdminRolePermissions")
                        .HasForeignKey("AdminRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TBOBackEnd.Models.AdminToken", b =>
                {
                    b.HasOne("TBOBackEnd.Models.Admin", "Admin")
                        .WithMany("AdminTokens")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}