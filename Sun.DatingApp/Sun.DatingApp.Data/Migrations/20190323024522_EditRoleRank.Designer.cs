﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sun.DatingApp.Data.Database;

namespace Sun.DatingApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190323024522_EditRoleRank")]
    partial class EditRoleRank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.BasicOccupation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("ParentCode")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("BasicOccupation");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.BasicRegion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityCode")
                        .HasMaxLength(20);

                    b.Property<float>("Lat")
                        .HasMaxLength(60);

                    b.Property<int>("LayerLevel");

                    b.Property<float>("Lng")
                        .HasMaxLength(60);

                    b.Property<string>("MergerName")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentCode");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("PinYin")
                        .HasMaxLength(100);

                    b.Property<int>("RegionCode");

                    b.Property<string>("ShortName")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("BasicRegion");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Forbiden");

                    b.Property<DateTime?>("LatestLoginAt");

                    b.Property<DateTime?>("LockoutEndAt");

                    b.Property<string>("Mobile");

                    b.Property<string>("Nickname")
                        .HasMaxLength(100);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<Guid?>("RefreshToken");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("SystemAccount");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemAccountAvatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<long>("FileLength")
                        .HasMaxLength(100);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(800);

                    b.HasKey("Id");

                    b.ToTable("SystemAccountAvatar");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Order");

                    b.Property<string>("TagColor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("SystemMenu");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("MenuId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Order");

                    b.Property<string>("TagColor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("SystemPage");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("PageId");

                    b.Property<int>("Rank");

                    b.Property<string>("TagColor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("SystemPermission");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Intro")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Rank");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("SystemRole");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemRolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<Guid>("PageId");

                    b.Property<Guid>("PermissionId");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("SystemRolePermission");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.SystemUserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<string>("Address")
                        .HasMaxLength(150);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Company")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Intro")
                        .HasMaxLength(350);

                    b.Property<string>("Motto");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Occupation")
                        .HasMaxLength(150);

                    b.Property<string>("QQ")
                        .HasMaxLength(20);

                    b.Property<bool>("Sex");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("WeChart")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SystemUserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}