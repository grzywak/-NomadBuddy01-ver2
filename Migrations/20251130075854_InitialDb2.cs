using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomadBuddy00.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelerPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferenceKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSystemType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    AverageInternetSpeedMbps = table.Column<double>(type: "float", nullable: false),
                    NumberOfCoworkingSpaces = table.Column<int>(type: "int", nullable: false),
                    HealthcareQuality = table.Column<int>(type: "int", nullable: false),
                    CostOfLiving = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisaPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    AccessType = table.Column<int>(type: "int", nullable: false),
                    AllowedStayDays = table.Column<int>(type: "int", nullable: true),
                    VisaFreePeriodDays = table.Column<int>(type: "int", nullable: true),
                    EstimatedCostUSD = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisaPolicies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisaPolicies_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelerQuestions_TravelerTypes_TravelerTypeId",
                        column: x => x.TravelerTypeId,
                        principalTable: "TravelerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerTypePreference",
                columns: table => new
                {
                    SuggestedForTypesId = table.Column<int>(type: "int", nullable: false),
                    SuggestedPreferencesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerTypePreference", x => new { x.SuggestedForTypesId, x.SuggestedPreferencesId });
                    table.ForeignKey(
                        name: "FK_TravelerTypePreference_TravelerPreferences_SuggestedPreferencesId",
                        column: x => x.SuggestedPreferencesId,
                        principalTable: "TravelerPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelerTypePreference_TravelerTypes_SuggestedForTypesId",
                        column: x => x.SuggestedForTypesId,
                        principalTable: "TravelerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buddies",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buddies", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Buddies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupports_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupports_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nomads",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    PreferredLanguage = table.Column<int>(type: "int", nullable: false),
                    TravelBudget = table.Column<int>(type: "int", nullable: false),
                    NomadType = table.Column<int>(type: "int", nullable: false),
                    CurrentCountryId = table.Column<int>(type: "int", nullable: true),
                    CurrentCityId = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectedMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomads", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Nomads_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nomads_Cities_CurrentCityId",
                        column: x => x.CurrentCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomads_Countries_CurrentCountryId",
                        column: x => x.CurrentCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomads_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLeadBuddy = table.Column<bool>(type: "bit", nullable: false),
                    Compensation = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityAssignments_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAssignments_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportId = table.Column<int>(type: "int", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportAssignments_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupportAssignments_BuddySupports_BuddySupportId",
                        column: x => x.BuddySupportId,
                        principalTable: "BuddySupports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityReservations_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityReservations_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<int>(type: "int", nullable: false),
                    NomadUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportRequests_BuddySupports_BuddySupportId",
                        column: x => x.BuddySupportId,
                        principalTable: "BuddySupports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuddySupportRequests_Nomads_NomadUserId",
                        column: x => x.NomadUserId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityCostOfLivingRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsMonthly = table.Column<bool>(type: "bit", nullable: false),
                    BudgetLevel = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Housing = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Transport = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Leisure = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCostOfLivingRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityCostOfLivingRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCostOfLivingRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityEntertainmentRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NightlifeScore = table.Column<int>(type: "int", nullable: false),
                    EventsFrequencyScore = table.Column<int>(type: "int", nullable: false),
                    YouthVibeScore = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntertainmentRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityEntertainmentRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityEntertainmentRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityHealthcareRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AvailabilityScore = table.Column<int>(type: "int", nullable: false),
                    AvgInsuranceMonthlyCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AvgDoctorVisitCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHealthcareRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityHealthcareRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityHealthcareRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityOverallRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OverallScore = table.Column<double>(type: "float", nullable: false),
                    IsSystemGenerated = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityOverallRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityOverallRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityOverallRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitySafetyRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DaySafety = table.Column<int>(type: "int", nullable: false),
                    NightSafety = table.Column<int>(type: "int", nullable: false),
                    FeltHarassed = table.Column<bool>(type: "bit", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitySafetyRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitySafetyRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitySafetyRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTagVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityTagId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VotedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTagVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTagVotes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTagVotes_CityTags_CityTagId",
                        column: x => x.CityTagId,
                        principalTable: "CityTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTagVotes_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTransportRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublicTransportScore = table.Column<int>(type: "int", nullable: false),
                    NightTransportScore = table.Column<int>(type: "int", nullable: false),
                    BikeFriendlyScore = table.Column<int>(type: "int", nullable: false),
                    WalkabilityScore = table.Column<int>(type: "int", nullable: false),
                    TransportCostScore = table.Column<int>(type: "int", nullable: false),
                    AppConvenienceScore = table.Column<int>(type: "int", nullable: false),
                    MotorbikeEaseScore = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTransportRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTransportRatings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityTransportRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendsProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FunFact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPartyAnimal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendsProfiles_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetworkingProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookingFor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkingProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkingProfiles_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomadCompatibilityScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetNomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomadCompatibilityScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomadCompatibilityScores_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_NomadCompatibilityScores_Nomads_TargetNomadId",
                        column: x => x.TargetNomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "NomadInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomadInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomadInterests_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomadLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomadLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomadLikes_Nomads_LikerId",
                        column: x => x.LikerId,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_NomadLikes_Nomads_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "NomadMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomad1Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nomad2Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    MatchedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalMatchScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomadMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomadMatches_Nomads_Nomad1Id",
                        column: x => x.Nomad1Id,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_NomadMatches_Nomads_Nomad2Id",
                        column: x => x.Nomad2Id,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "NomadPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TravelerPreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomadPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomadPreferences_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NomadPreferences_TravelerPreferences_TravelerPreferenceId",
                        column: x => x.TravelerPreferenceId,
                        principalTable: "TravelerPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerQuestionId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelerAnswers_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelerAnswers_TravelerQuestions_TravelerQuestionId",
                        column: x => x.TravelerQuestionId,
                        principalTable: "TravelerQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelerTypeScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerTypeId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerTypeScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelerTypeScores_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelerTypeScores_TravelerTypes_TravelerTypeId",
                        column: x => x.TravelerTypeId,
                        principalTable: "TravelerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPlans_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportRequestId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionStatus = table.Column<int>(type: "int", nullable: false),
                    OptionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_BuddySupportRequests_BuddySupportRequestId",
                        column: x => x.BuddySupportRequestId,
                        principalTable: "BuddySupportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupportSessions_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollabSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadMatchId = table.Column<int>(type: "int", nullable: false),
                    SharedGoal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollabSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollabSpaces_NomadMatches_NomadMatchId",
                        column: x => x.NomadMatchId,
                        principalTable: "NomadMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripPins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomadMatchId = table.Column<int>(type: "int", nullable: false),
                    AddedByNomadId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripPinStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPins_NomadMatches_NomadMatchId",
                        column: x => x.NomadMatchId,
                        principalTable: "NomadMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripPins_Nomads_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Nomads",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TripStops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripPlanId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisaPolicyId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripStops_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripStops_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripStops_TripPlans_TripPlanId",
                        column: x => x.TripPlanId,
                        principalTable: "TripPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripStops_VisaPolicies_VisaPolicyId",
                        column: x => x.VisaPolicyId,
                        principalTable: "VisaPolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuddySupportRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuddySupportSessionId = table.Column<int>(type: "int", nullable: false),
                    NomadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuddyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatedOnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuddySupportRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_Buddies_BuddyId",
                        column: x => x.BuddyId,
                        principalTable: "Buddies",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_BuddySupportSessions_BuddySupportSessionId",
                        column: x => x.BuddySupportSessionId,
                        principalTable: "BuddySupportSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuddySupportRatings_Nomads_NomadId",
                        column: x => x.NomadId,
                        principalTable: "Nomads",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollabIdeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollabSpaceId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollabIdeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollabIdeas_CollabSpaces_CollabSpaceId",
                        column: x => x.CollabSpaceId,
                        principalTable: "CollabSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedById",
                table: "Activities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAssignments_ActivityId",
                table: "ActivityAssignments",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAssignments_BuddyId",
                table: "ActivityAssignments",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityReservations_ActivityId",
                table: "ActivityReservations",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityReservations_NomadId",
                table: "ActivityReservations",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportAssignments_BuddyId",
                table: "BuddySupportAssignments",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportAssignments_BuddySupportId",
                table: "BuddySupportAssignments",
                column: "BuddySupportId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_BuddyId",
                table: "BuddySupportRatings",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_BuddySupportSessionId",
                table: "BuddySupportRatings",
                column: "BuddySupportSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRatings_NomadId",
                table: "BuddySupportRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRequests_BuddySupportId",
                table: "BuddySupportRequests",
                column: "BuddySupportId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportRequests_NomadUserId",
                table: "BuddySupportRequests",
                column: "NomadUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupports_CityId",
                table: "BuddySupports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupports_CountryId",
                table: "BuddySupports",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_BuddyId",
                table: "BuddySupportSessions",
                column: "BuddyId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_BuddySupportRequestId",
                table: "BuddySupportSessions",
                column: "BuddySupportRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddySupportSessions_NomadId",
                table: "BuddySupportSessions",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCostOfLivingRatings_CityId",
                table: "CityCostOfLivingRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCostOfLivingRatings_NomadId",
                table: "CityCostOfLivingRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CityEntertainmentRatings_CityId",
                table: "CityEntertainmentRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityEntertainmentRatings_NomadId",
                table: "CityEntertainmentRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHealthcareRatings_CityId",
                table: "CityHealthcareRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHealthcareRatings_NomadId",
                table: "CityHealthcareRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CityOverallRatings_CityId",
                table: "CityOverallRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityOverallRatings_NomadId",
                table: "CityOverallRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CitySafetyRatings_CityId",
                table: "CitySafetyRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitySafetyRatings_NomadId",
                table: "CitySafetyRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTagVotes_CityId",
                table: "CityTagVotes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTagVotes_CityTagId",
                table: "CityTagVotes",
                column: "CityTagId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTagVotes_NomadId",
                table: "CityTagVotes",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTransportRatings_CityId",
                table: "CityTransportRatings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTransportRatings_NomadId",
                table: "CityTransportRatings",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_CollabIdeas_CollabSpaceId",
                table: "CollabIdeas",
                column: "CollabSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CollabSpaces_NomadMatchId",
                table: "CollabSpaces",
                column: "NomadMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsProfiles_NomadId",
                table: "FriendsProfiles",
                column: "NomadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NetworkingProfiles_NomadId",
                table: "NetworkingProfiles",
                column: "NomadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NomadCompatibilityScores_NomadId",
                table: "NomadCompatibilityScores",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadCompatibilityScores_TargetNomadId",
                table: "NomadCompatibilityScores",
                column: "TargetNomadId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadInterests_NomadId",
                table: "NomadInterests",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadLikes_LikerId",
                table: "NomadLikes",
                column: "LikerId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadLikes_TargetId",
                table: "NomadLikes",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadMatches_Nomad1Id",
                table: "NomadMatches",
                column: "Nomad1Id");

            migrationBuilder.CreateIndex(
                name: "IX_NomadMatches_Nomad2Id",
                table: "NomadMatches",
                column: "Nomad2Id");

            migrationBuilder.CreateIndex(
                name: "IX_NomadPreferences_NomadId",
                table: "NomadPreferences",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_NomadPreferences_TravelerPreferenceId",
                table: "NomadPreferences",
                column: "TravelerPreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomads_CurrentCityId",
                table: "Nomads",
                column: "CurrentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomads_CurrentCountryId",
                table: "Nomads",
                column: "CurrentCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomads_NationalityId",
                table: "Nomads",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerAnswers_NomadId",
                table: "TravelerAnswers",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerAnswers_TravelerQuestionId",
                table: "TravelerAnswers",
                column: "TravelerQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerQuestions_TravelerTypeId",
                table: "TravelerQuestions",
                column: "TravelerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerTypePreference_SuggestedPreferencesId",
                table: "TravelerTypePreference",
                column: "SuggestedPreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerTypeScores_NomadId",
                table: "TravelerTypeScores",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerTypeScores_TravelerTypeId",
                table: "TravelerTypeScores",
                column: "TravelerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPins_AddedByUserId",
                table: "TripPins",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPins_NomadMatchId",
                table: "TripPins",
                column: "NomadMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlans_NomadId",
                table: "TripPlans",
                column: "NomadId");

            migrationBuilder.CreateIndex(
                name: "IX_TripStops_CityId",
                table: "TripStops",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripStops_CountryId",
                table: "TripStops",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TripStops_TripPlanId",
                table: "TripStops",
                column: "TripPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TripStops_VisaPolicyId",
                table: "TripStops",
                column: "VisaPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaPolicies_CountryId",
                table: "VisaPolicies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaPolicies_NationalityId",
                table: "VisaPolicies",
                column: "NationalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAssignments");

            migrationBuilder.DropTable(
                name: "ActivityReservations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BuddySupportAssignments");

            migrationBuilder.DropTable(
                name: "BuddySupportRatings");

            migrationBuilder.DropTable(
                name: "CityCostOfLivingRatings");

            migrationBuilder.DropTable(
                name: "CityEntertainmentRatings");

            migrationBuilder.DropTable(
                name: "CityHealthcareRatings");

            migrationBuilder.DropTable(
                name: "CityOverallRatings");

            migrationBuilder.DropTable(
                name: "CitySafetyRatings");

            migrationBuilder.DropTable(
                name: "CityTagVotes");

            migrationBuilder.DropTable(
                name: "CityTransportRatings");

            migrationBuilder.DropTable(
                name: "CollabIdeas");

            migrationBuilder.DropTable(
                name: "FriendsProfiles");

            migrationBuilder.DropTable(
                name: "NetworkingProfiles");

            migrationBuilder.DropTable(
                name: "NomadCompatibilityScores");

            migrationBuilder.DropTable(
                name: "NomadInterests");

            migrationBuilder.DropTable(
                name: "NomadLikes");

            migrationBuilder.DropTable(
                name: "NomadPreferences");

            migrationBuilder.DropTable(
                name: "TravelerAnswers");

            migrationBuilder.DropTable(
                name: "TravelerTypePreference");

            migrationBuilder.DropTable(
                name: "TravelerTypeScores");

            migrationBuilder.DropTable(
                name: "TripPins");

            migrationBuilder.DropTable(
                name: "TripStops");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BuddySupportSessions");

            migrationBuilder.DropTable(
                name: "CityTags");

            migrationBuilder.DropTable(
                name: "CollabSpaces");

            migrationBuilder.DropTable(
                name: "TravelerQuestions");

            migrationBuilder.DropTable(
                name: "TravelerPreferences");

            migrationBuilder.DropTable(
                name: "TripPlans");

            migrationBuilder.DropTable(
                name: "VisaPolicies");

            migrationBuilder.DropTable(
                name: "Buddies");

            migrationBuilder.DropTable(
                name: "BuddySupportRequests");

            migrationBuilder.DropTable(
                name: "NomadMatches");

            migrationBuilder.DropTable(
                name: "TravelerTypes");

            migrationBuilder.DropTable(
                name: "BuddySupports");

            migrationBuilder.DropTable(
                name: "Nomads");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
