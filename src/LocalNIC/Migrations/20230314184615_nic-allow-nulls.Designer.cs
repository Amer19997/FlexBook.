﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Waqfi.LocalNIC.Persistence;

#nullable disable

namespace LocalNIC.Migrations
{
    [DbContext(typeof(NICDbContext))]
    [Migration("20230314184615_nic-allow-nulls")]
    partial class nicallownulls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.BoardChairman", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BoardEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BoardStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId")
                        .IsUnique()
                        .HasFilter("[SocietyId] IS NOT NULL");

                    b.ToTable("BoardChairmans");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.BoardMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.ToTable("BoardMember");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.CEO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId")
                        .IsUnique();

                    b.ToTable("CEOs");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Delegate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.ToTable("Delegates");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderIndex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.FirstSubclass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FirstSubclasses");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.GovernanceClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GovernanceClassifications");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderAddress", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BriefAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CityBaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailedAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SideNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityBaseId");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SocietyId")
                        .IsUnique()
                        .HasFilter("[SocietyId] IS NOT NULL");

                    b.ToTable("ProviderAddresses");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderContactDetails", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumberCountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumberCountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId")
                        .IsUnique()
                        .HasFilter("[SocietyId] IS NOT NULL");

                    b.ToTable("ProviderContactDetails");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Size")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SocietyId");

                    b.ToTable("ProviderFiles");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderFinancialAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BeneficiaryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SwiftCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("SocietyId");

                    b.ToTable("ProviderFinancialAccounts");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.QualitativeClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QualitativeClassifications");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.SecondSubclass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecondSubclasses");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.SocialAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Instgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Snapchat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SocityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TickTok")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SocityId")
                        .IsUnique();

                    b.ToTable("SocialAccounts");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Society", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommercialRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FirstSubclassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GovernanceClassification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GovernanceClassificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("GovernanceDegree")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LicenseEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LicenseStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("QualitativeClassificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("SecondSubclassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SocietyStatus")
                        .HasColumnType("int");

                    b.Property<int?>("TargetGender")
                        .HasColumnType("int");

                    b.Property<Guid?>("TransparencyStandardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FirstSubclassId");

                    b.HasIndex("GovernanceClassificationId");

                    b.HasIndex("QualitativeClassificationId");

                    b.HasIndex("SecondSubclassId");

                    b.HasIndex("TransparencyStandardId");

                    b.ToTable("Societies");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.TransparencyStandard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransparencyStandard");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Bank", b =>
                {
                    b.OwnsOne("Waqfi.LocalNIC.Entities.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("BankId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BankId");

                            b1.ToTable("Banks");

                            b1.WithOwner()
                                .HasForeignKey("BankId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.BoardChairman", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithOne("BoardChairman")
                        .HasForeignKey("Waqfi.LocalNIC.Entities.BoardChairman", "SocietyId");

                    b.OwnsOne("Waqfi.LocalNIC.Entities.PhoneNumber", "MobileNumber", b1 =>
                        {
                            b1.Property<Guid>("BoardChairmanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MobileNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BoardChairmanId");

                            b1.ToTable("BoardChairmans");

                            b1.WithOwner()
                                .HasForeignKey("BoardChairmanId");
                        });

                    b.Navigation("MobileNumber");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.BoardMember", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithMany("BoardMembers")
                        .HasForeignKey("SocietyId");

                    b.OwnsOne("Waqfi.LocalNIC.Entities.PhoneNumber", "MobileNumber", b1 =>
                        {
                            b1.Property<Guid>("BoardMemberId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MobileNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BoardMemberId");

                            b1.ToTable("BoardMember");

                            b1.WithOwner()
                                .HasForeignKey("BoardMemberId");
                        });

                    b.Navigation("MobileNumber");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.CEO", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithOne("CEO")
                        .HasForeignKey("Waqfi.LocalNIC.Entities.CEO", "SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Waqfi.LocalNIC.Entities.PhoneNumber", "MobileNumber", b1 =>
                        {
                            b1.Property<Guid>("CEOId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MobileNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CEOId");

                            b1.ToTable("CEOs");

                            b1.WithOwner()
                                .HasForeignKey("CEOId");
                        });

                    b.Navigation("MobileNumber");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.City", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId");

                    b.OwnsOne("Waqfi.LocalNIC.Entities.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("CityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CityId");

                            b1.ToTable("Cities");

                            b1.WithOwner()
                                .HasForeignKey("CityId");
                        });

                    b.Navigation("Name");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Delegate", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithMany("Delegates")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Waqfi.LocalNIC.Entities.PhoneNumber", "MobileNumber", b1 =>
                        {
                            b1.Property<Guid>("DelegateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CountryCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MobileNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DelegateId");

                            b1.ToTable("Delegates");

                            b1.WithOwner()
                                .HasForeignKey("DelegateId");
                        });

                    b.Navigation("MobileNumber")
                        .IsRequired();

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.District", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId");

                    b.OwnsOne("Waqfi.LocalNIC.Entities.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("DistrictId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DistrictId");

                            b1.ToTable("Districts");

                            b1.WithOwner()
                                .HasForeignKey("DistrictId");
                        });

                    b.Navigation("City");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderAddress", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.City", "CityBase")
                        .WithMany("ProviderAddressesBase")
                        .HasForeignKey("CityBaseId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Waqfi.LocalNIC.Entities.City", "City")
                        .WithMany("ProviderAddresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Waqfi.LocalNIC.Entities.District", "District")
                        .WithMany("ProviderAddresses")
                        .HasForeignKey("DistrictId");

                    b.HasOne("Waqfi.LocalNIC.Entities.Region", "Region")
                        .WithMany("ProviderAddresses")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithOne("Address")
                        .HasForeignKey("Waqfi.LocalNIC.Entities.ProviderAddress", "SocietyId");

                    b.Navigation("City");

                    b.Navigation("CityBase");

                    b.Navigation("District");

                    b.Navigation("Region");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderContactDetails", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithOne("Contacts")
                        .HasForeignKey("Waqfi.LocalNIC.Entities.ProviderContactDetails", "SocietyId");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderFile", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithMany("ProviderFiles")
                        .HasForeignKey("SocietyId");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.ProviderFinancialAccount", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Bank", "Bank")
                        .WithMany("ProviderFinancialAccounts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithMany("ProviderFinancialAccounts")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Region", b =>
                {
                    b.OwnsOne("Waqfi.LocalNIC.Entities.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("RegionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RegionId");

                            b1.ToTable("Regions");

                            b1.WithOwner()
                                .HasForeignKey("RegionId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.SocialAccount", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.Society", "Society")
                        .WithOne("SocialAccount")
                        .HasForeignKey("Waqfi.LocalNIC.Entities.SocialAccount", "SocityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Society");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Society", b =>
                {
                    b.HasOne("Waqfi.LocalNIC.Entities.FirstSubclass", "FirstSubclass")
                        .WithMany("Societies")
                        .HasForeignKey("FirstSubclassId");

                    b.HasOne("Waqfi.LocalNIC.Entities.GovernanceClassification", null)
                        .WithMany("Societies")
                        .HasForeignKey("GovernanceClassificationId");

                    b.HasOne("Waqfi.LocalNIC.Entities.QualitativeClassification", "QualitativeClassification")
                        .WithMany("Societies")
                        .HasForeignKey("QualitativeClassificationId");

                    b.HasOne("Waqfi.LocalNIC.Entities.SecondSubclass", "SecondSubclass")
                        .WithMany("Societies")
                        .HasForeignKey("SecondSubclassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Waqfi.LocalNIC.Entities.TransparencyStandard", "TransparencyStandard")
                        .WithMany("Societies")
                        .HasForeignKey("TransparencyStandardId");

                    b.OwnsOne("Waqfi.LocalNIC.Entities.DescriptionLocalized", "Name", b1 =>
                        {
                            b1.Property<Guid>("SocietyId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DescriptionAr")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DescriptionEn")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SocietyId");

                            b1.ToTable("Societies");

                            b1.WithOwner()
                                .HasForeignKey("SocietyId");
                        });

                    b.Navigation("FirstSubclass");

                    b.Navigation("Name");

                    b.Navigation("QualitativeClassification");

                    b.Navigation("SecondSubclass");

                    b.Navigation("TransparencyStandard");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Bank", b =>
                {
                    b.Navigation("ProviderFinancialAccounts");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.City", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("ProviderAddresses");

                    b.Navigation("ProviderAddressesBase");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.District", b =>
                {
                    b.Navigation("ProviderAddresses");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.FirstSubclass", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.GovernanceClassification", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.QualitativeClassification", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Region", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("ProviderAddresses");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.SecondSubclass", b =>
                {
                    b.Navigation("Societies");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.Society", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("BoardChairman");

                    b.Navigation("BoardMembers");

                    b.Navigation("CEO");

                    b.Navigation("Contacts");

                    b.Navigation("Delegates");

                    b.Navigation("ProviderFiles");

                    b.Navigation("ProviderFinancialAccounts");

                    b.Navigation("SocialAccount");
                });

            modelBuilder.Entity("Waqfi.LocalNIC.Entities.TransparencyStandard", b =>
                {
                    b.Navigation("Societies");
                });
#pragma warning restore 612, 618
        }
    }
}
