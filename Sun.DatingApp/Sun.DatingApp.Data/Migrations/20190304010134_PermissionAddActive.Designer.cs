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
    [Migration("20190304010134_PermissionAddActive")]
    partial class PermissionAddActive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.Occupation", b =>
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

                    b.HasIndex("Code");

                    b.HasIndex("ParentId");

                    b.ToTable("Occupations","Basic");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.Region", b =>
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

                    b.HasIndex("LayerLevel");

                    b.HasIndex("ParentId");

                    b.HasIndex("RegionCode");

                    b.ToTable("Regions","Basic");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Account", b =>
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

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<Guid?>("RefreshToken");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Remark")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Organizations","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Permission", b =>
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

                    b.Property<Guid?>("ParentId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.ProfilePicture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("FileLength")
                        .HasMaxLength(20);

                    b.Property<string>("FileName")
                        .HasMaxLength(100);

                    b.Property<string>("FileType")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ProfilePictures","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Prompt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("LastInfo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("OrganizationId");

                    b.Property<int>("UpdateNum");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Prompts","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30);

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

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.ToTable("Roles","System");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea5a8774-149f-4cbe-9db2-6d1221796a8c"),
                            Code = "SuperAdmin",
                            CreatedAt = new DateTime(2019, 3, 4, 9, 1, 34, 277, DateTimeKind.Local).AddTicks(7872),
                            Deleted = false,
                            Intro = "超级管理员拥有所有的权限",
                            Name = "超级管理员"
                        },
                        new
                        {
                            Id = new Guid("17a4f91a-819f-4f4d-8380-89bd992485bb"),
                            Code = "Admin",
                            CreatedAt = new DateTime(2019, 3, 4, 9, 1, 34, 279, DateTimeKind.Local).AddTicks(7711),
                            Deleted = false,
                            Intro = "管理员用于管理用户权限",
                            Name = "管理员"
                        },
                        new
                        {
                            Id = new Guid("52b7dbf4-7589-4f9a-a176-aab2e6b63b92"),
                            Code = "User",
                            CreatedAt = new DateTime(2019, 3, 4, 9, 1, 34, 279, DateTimeKind.Local).AddTicks(7723),
                            Deleted = false,
                            Intro = "可以使用基本功能",
                            Name = "用户"
                        });
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<Guid>("PermissionId");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("BaseAddressId");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("CreatedById");

                    b.Property<Guid>("CurrentAddressId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("DeletedById");

                    b.Property<string>("Intro")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("OccupationId");

                    b.Property<string>("PhoneNum")
                        .HasMaxLength(20);

                    b.Property<Guid?>("ProfilePictureId");

                    b.Property<string>("QQ")
                        .HasMaxLength(20);

                    b.Property<bool>("Sex");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<string>("WeChart")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrentAddressId");

                    b.HasIndex("OccupationId");

                    b.ToTable("UserInfos","System");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.Occupation", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.Basic.Occupation", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.Basic.Region", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.Basic.Region", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Account", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.System.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Organization", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.System.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Permission", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.System.Permission", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.Prompt", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.System.Organization", "Organization")
                        .WithMany("Prompts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.RolePermission", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.System.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sun.DatingApp.Data.Entities.System.UserInfo", b =>
                {
                    b.HasOne("Sun.DatingApp.Data.Entities.Basic.Region", "Region")
                        .WithMany("UserInfos")
                        .HasForeignKey("CurrentAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sun.DatingApp.Data.Entities.Basic.Occupation", "Occupation")
                        .WithMany("UserInfos")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}