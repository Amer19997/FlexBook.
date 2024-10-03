using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalNIC.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDescriptionAr = table.Column<string>(name: "Name_DescriptionAr", type: "nvarchar(max)", nullable: false),
                    NameDescriptionEn = table.Column<string>(name: "Name_DescriptionEn", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstSubclasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSubclasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernanceClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernanceClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualitativeClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitativeClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDescriptionAr = table.Column<string>(name: "Name_DescriptionAr", type: "nvarchar(max)", nullable: false),
                    NameDescriptionEn = table.Column<string>(name: "Name_DescriptionEn", type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondSubclasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondSubclasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransparencyStandards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransparencyStandards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDescriptionAr = table.Column<string>(name: "Name_DescriptionAr", type: "nvarchar(max)", nullable: false),
                    NameDescriptionEn = table.Column<string>(name: "Name_DescriptionEn", type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernanceDegree = table.Column<bool>(type: "bit", nullable: false),
                    GovernanceClassificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualitativeClassificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransparencyStandard = table.Column<int>(type: "int", nullable: false),
                    FirstSubclassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondSubclassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyStatus = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameDescriptionAr = table.Column<string>(name: "Name_DescriptionAr", type: "nvarchar(max)", nullable: false),
                    NameDescriptionEn = table.Column<string>(name: "Name_DescriptionEn", type: "nvarchar(max)", nullable: false),
                    LicenseStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LicenseEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TargetGender = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Societies_FirstSubclasses_FirstSubclassId",
                        column: x => x.FirstSubclassId,
                        principalTable: "FirstSubclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Societies_GovernanceClassifications_GovernanceClassificationId",
                        column: x => x.GovernanceClassificationId,
                        principalTable: "GovernanceClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Societies_QualitativeClassifications_QualitativeClassificationId",
                        column: x => x.QualitativeClassificationId,
                        principalTable: "QualitativeClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Societies_SecondSubclasses_SecondSubclassId",
                        column: x => x.SecondSubclassId,
                        principalTable: "SecondSubclasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameDescriptionAr = table.Column<string>(name: "Name_DescriptionAr", type: "nvarchar(max)", nullable: false),
                    NameDescriptionEn = table.Column<string>(name: "Name_DescriptionEn", type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardChairmans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberCountryCode = table.Column<string>(name: "MobileNumber_CountryCode", type: "nvarchar(max)", nullable: false),
                    MobileNumberMobileNumber = table.Column<string>(name: "MobileNumber_MobileNumber", type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardChairmans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardChairmans_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberCountryCode = table.Column<string>(name: "MobileNumber_CountryCode", type: "nvarchar(max)", nullable: false),
                    MobileNumberMobileNumber = table.Column<string>(name: "MobileNumber_MobileNumber", type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMember_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CEOs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberCountryCode = table.Column<string>(name: "MobileNumber_CountryCode", type: "nvarchar(max)", nullable: false),
                    MobileNumberMobileNumber = table.Column<string>(name: "MobileNumber_MobileNumber", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CEOs_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delegates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberCountryCode = table.Column<string>(name: "MobileNumber_CountryCode", type: "nvarchar(max)", nullable: false),
                    MobileNumberMobileNumber = table.Column<string>(name: "MobileNumber_MobileNumber", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delegates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delegates_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumberCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderContactDetails_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderFiles_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderFinancialAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderFinancialAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderFinancialAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderFinancialAccounts_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TickTok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Snapchat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialAccounts_Societies_SocityId",
                        column: x => x.SocityId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetailedAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BriefAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<short>(type: "smallint", nullable: false),
                    ZipCode = table.Column<short>(type: "smallint", nullable: false),
                    PostalCode = table.Column<short>(type: "smallint", nullable: false),
                    SideNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_Cities_CityBaseId",
                        column: x => x.CityBaseId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardChairmans_SocietyId",
                table: "BoardChairmans",
                column: "SocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_SocietyId",
                table: "BoardMember",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CEOs_SocietyId",
                table: "CEOs",
                column: "SocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Delegates_SocietyId",
                table: "Delegates",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAddresses_CityBaseId",
                table: "ProviderAddresses",
                column: "CityBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAddresses_CityId",
                table: "ProviderAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAddresses_DistrictId",
                table: "ProviderAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAddresses_RegionId",
                table: "ProviderAddresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderAddresses_SocietyId",
                table: "ProviderAddresses",
                column: "SocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProviderContactDetails_SocietyId",
                table: "ProviderContactDetails",
                column: "SocietyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProviderFiles_SocietyId",
                table: "ProviderFiles",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderFinancialAccounts_BankId",
                table: "ProviderFinancialAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderFinancialAccounts_SocietyId",
                table: "ProviderFinancialAccounts",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialAccounts_SocityId",
                table: "SocialAccounts",
                column: "SocityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Societies_FirstSubclassId",
                table: "Societies",
                column: "FirstSubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_GovernanceClassificationId",
                table: "Societies",
                column: "GovernanceClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_QualitativeClassificationId",
                table: "Societies",
                column: "QualitativeClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Societies_SecondSubclassId",
                table: "Societies",
                column: "SecondSubclassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardChairmans");

            migrationBuilder.DropTable(
                name: "BoardMember");

            migrationBuilder.DropTable(
                name: "CEOs");

            migrationBuilder.DropTable(
                name: "Delegates");

            migrationBuilder.DropTable(
                name: "ProviderAddresses");

            migrationBuilder.DropTable(
                name: "ProviderContactDetails");

            migrationBuilder.DropTable(
                name: "ProviderFiles");

            migrationBuilder.DropTable(
                name: "ProviderFinancialAccounts");

            migrationBuilder.DropTable(
                name: "SocialAccounts");

            migrationBuilder.DropTable(
                name: "TransparencyStandards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Societies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FirstSubclasses");

            migrationBuilder.DropTable(
                name: "GovernanceClassifications");

            migrationBuilder.DropTable(
                name: "QualitativeClassifications");

            migrationBuilder.DropTable(
                name: "SecondSubclasses");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
