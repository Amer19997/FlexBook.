﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FlexBook.Infrastructure.Persistence;

#nullable disable

namespace FlexBook.Infrastructure.Migrations
{
    [DbContext(typeof(FlexBookDbContext))]
    [Migration("20240924184043_UpdateLook")]
    partial class UpdateLook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.CMSSections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CMSSection");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiscriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LookUpStatus")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LookUpStatus")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculty", (string)null);
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.InterestsList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InterestsList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<int>("CMSSectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CMSSectionId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LookUpStatus")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("University");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("permissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("permissionId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsSuperAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedStatus")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MobileNumber");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("RegisterAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique()
                        .HasFilter("[CountryId] IS NOT NULL");

                    b.HasIndex("DepartmentId")
                        .IsUnique()
                        .HasFilter("[DepartmentId] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FacultyId")
                        .IsUnique()
                        .HasFilter("[FacultyId] IS NOT NULL");

                    b.HasIndex("UniversityId")
                        .IsUnique()
                        .HasFilter("[UniversityId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.UserInterstes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("InterestsListId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InterestsListId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInterstes");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserTypes", (string)null);
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Department", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.Faculty", "Faculty")
                        .WithMany("DepartmentList")
                        .HasForeignKey("FacultyId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Faculty", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.University", "University")
                        .WithMany("FacultyList")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Permission", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.CMSSections", "CMSSection")
                        .WithMany("PermissionList")
                        .HasForeignKey("CMSSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CMSSection");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.University", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.Country", "Country")
                        .WithMany("UniversityList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.Role", b =>
                {
                    b.OwnsOne("FlexBook.Domain.ValueObjects.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameAr");

                            b1.Property<string>("DescriptionEn")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NameEn");

                            b1.HasKey("RoleId");

                            b1.ToTable("Roles");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.RolePermission", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.UsersAggregate.Role", "Role")
                        .WithMany("RolePermissionList")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBook.Domain.Entities.LookUps.Permission", "Permission")
                        .WithMany("RolePermissionList")
                        .HasForeignKey("permissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.User", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.Country", "Country")
                        .WithOne()
                        .HasForeignKey("FlexBook.Domain.Entities.UsersAggregate.User", "CountryId");

                    b.HasOne("FlexBook.Domain.Entities.LookUps.Department", "Department")
                        .WithOne()
                        .HasForeignKey("FlexBook.Domain.Entities.UsersAggregate.User", "DepartmentId");

                    b.HasOne("FlexBook.Domain.Entities.LookUps.Faculty", "Faculty")
                        .WithOne()
                        .HasForeignKey("FlexBook.Domain.Entities.UsersAggregate.User", "FacultyId");

                    b.HasOne("FlexBook.Domain.Entities.LookUps.University", "University")
                        .WithOne()
                        .HasForeignKey("FlexBook.Domain.Entities.UsersAggregate.User", "UniversityId");

                    b.Navigation("Country");

                    b.Navigation("Department");

                    b.Navigation("Faculty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.UserInterstes", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.LookUps.Course", "Course")
                        .WithMany("UserInterstesList")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBook.Domain.Entities.LookUps.InterestsList", null)
                        .WithMany("UserInterstesList")
                        .HasForeignKey("InterestsListId");

                    b.HasOne("FlexBook.Domain.Entities.UsersAggregate.User", "User")
                        .WithMany("UserInterstesList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.UserRole", b =>
                {
                    b.HasOne("FlexBook.Domain.Entities.UsersAggregate.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBook.Domain.Entities.UsersAggregate.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.CMSSections", b =>
                {
                    b.Navigation("PermissionList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Country", b =>
                {
                    b.Navigation("UniversityList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Course", b =>
                {
                    b.Navigation("UserInterstesList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Faculty", b =>
                {
                    b.Navigation("DepartmentList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.InterestsList", b =>
                {
                    b.Navigation("UserInterstesList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.Permission", b =>
                {
                    b.Navigation("RolePermissionList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.LookUps.University", b =>
                {
                    b.Navigation("FacultyList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.Role", b =>
                {
                    b.Navigation("RolePermissionList");
                });

            modelBuilder.Entity("FlexBook.Domain.Entities.UsersAggregate.User", b =>
                {
                    b.Navigation("UserInterstesList");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
