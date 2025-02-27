﻿// <auto-generated />
using System;
using BiometricManagement_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiometricManagement_MVC.Migrations
{
    [DbContext(typeof(BiometricContext))]
    partial class BiometricContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiometricManagement_MVC.Models.DeviceIn", b =>
                {
                    b.Property<int>("DeviceInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceInId"));

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeviceInId");

                    b.HasIndex("UserId");

                    b.ToTable("DevicesIn");
                });

            modelBuilder.Entity("BiometricManagement_MVC.Models.DeviceOut", b =>
                {
                    b.Property<int>("DeviceOutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceOutId"));

                    b.Property<DateTime>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeviceOutId");

                    b.HasIndex("UserId");

                    b.ToTable("DevicesOut");
                });

            modelBuilder.Entity("BiometricManagement_MVC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BiometricManagement_MVC.Models.DeviceIn", b =>
                {
                    b.HasOne("BiometricManagement_MVC.Models.User", "User")
                        .WithMany("DevicesIn")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BiometricManagement_MVC.Models.DeviceOut", b =>
                {
                    b.HasOne("BiometricManagement_MVC.Models.User", "User")
                        .WithMany("DevicesOut")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BiometricManagement_MVC.Models.User", b =>
                {
                    b.Navigation("DevicesIn");

                    b.Navigation("DevicesOut");
                });
#pragma warning restore 612, 618
        }
    }
}
