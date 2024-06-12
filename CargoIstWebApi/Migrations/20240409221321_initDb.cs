using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class initDb : Migration
    {
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "CargoParcelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoParcelTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoParcelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoTransportationConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoTransportationConditionsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoTransportationConditionsPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoTransportationConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoTypePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMobil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMobil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighbourhood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighbourhoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighbourhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighbourhood_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesTypeId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeesType_EmployeesTypeId",
                        column: x => x.EmployeesTypeId,
                        principalTable: "EmployeesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Neighbourhood_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receiver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerMobilId = table.Column<int>(type: "int", nullable: true),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    IsInActiveDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receiver_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiver_CustomerMobil_CustomerMobilId",
                        column: x => x.CustomerMobilId,
                        principalTable: "CustomerMobil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receiver_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receiver_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiver_Neighbourhood_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiver_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomerMobilId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerAddress_CustomerMobil_CustomerMobilId",
                        column: x => x.CustomerMobilId,
                        principalTable: "CustomerMobil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallCourier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMobilId = table.Column<int>(type: "int", nullable: false),
                    CustomerMobilAdressId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    CargoParcelTypeID = table.Column<int>(type: "int", nullable: false),
                    CargoTransportationConditionsId = table.Column<int>(type: "int", nullable: false),
                    CargoTypeId = table.Column<int>(type: "int", nullable: false),
                    CargoDesi = table.Column<double>(type: "float", nullable: false),
                    CargoRealeseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CallCourierOk = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallCourier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallCourier_CargoParcelType_CargoParcelTypeID",
                        column: x => x.CargoParcelTypeID,
                        principalTable: "CargoParcelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallCourier_CargoTransportationConditions_CargoTransportationConditionsId",
                        column: x => x.CargoTransportationConditionsId,
                        principalTable: "CargoTransportationConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallCourier_CargoType_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "CargoType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallCourier_CustomerMobil_CustomerMobilId",
                        column: x => x.CustomerMobilId,
                        principalTable: "CustomerMobil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallCourier_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallCourier_Receiver_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receiver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    CustomerMobilId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerMobilAdressId = table.Column<int>(type: "int", nullable: false),
                    CargoDepartureBranchId = table.Column<int>(type: "int", nullable: false),
                    CargoArrivalBranchId = table.Column<int>(type: "int", nullable: false),
                    CargoTransportationConditionsId = table.Column<int>(type: "int", nullable: false),
                    CargoTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    CargoParcelTypeId = table.Column<int>(type: "int", nullable: false),
                    CargoStatusId = table.Column<int>(type: "int", nullable: false),
                    CargoDesi = table.Column<double>(type: "float", nullable: false),
                    CargoReleaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CargoEstimatedDeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CargoDeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CargoTrackingNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargo_Branch_CargoArrivalBranchId",
                        column: x => x.CargoArrivalBranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cargo_Branch_CargoDepartureBranchId",
                        column: x => x.CargoDepartureBranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoParcelType_CargoParcelTypeId",
                        column: x => x.CargoParcelTypeId,
                        principalTable: "CargoParcelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoStatus_CargoStatusId",
                        column: x => x.CargoStatusId,
                        principalTable: "CargoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoTransportationConditions_CargoTransportationConditionsId",
                        column: x => x.CargoTransportationConditionsId,
                        principalTable: "CargoTransportationConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoType_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalTable: "CargoType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_CustomerMobil_CustomerMobilId",
                        column: x => x.CustomerMobilId,
                        principalTable: "CustomerMobil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cargo_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cargo_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_Receiver_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receiver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoMovement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoId = table.Column<int>(type: "int", nullable: true),
                    CallCourierId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CargoStatusId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoMovement_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoMovement_CallCourier_CallCourierId",
                        column: x => x.CallCourierId,
                        principalTable: "CallCourier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoMovement_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoMovement_CargoStatus_CargoStatusId",
                        column: x => x.CargoStatusId,
                        principalTable: "CargoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1578e20c-e5bc-4bd9-bb9a-72c265861077", "95674e98-6ff8-4b91-ab10-fb9cd64773af", "Admin", "ADMIN" },
                    { "da3babac-f452-4233-a992-d313b93830e1", "690b690c-0de2-4c4e-978b-b3d94cbab48c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "CargoParcelType",
                columns: new[] { "Id", "CargoParcelTypeName", "DesiSize", "Information", "MaxSize", "Price" },
                values: new object[,]
                {
                    { 1, "Small", "6.0 - 10.0 kg", "Bu pakete ortalama boydaki bir dergiden 15 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya2 top fotokopi kağıdı sığabilir.", "31", 10.0 },
                    { 2, "Medium", "11.0 - 15.0 kg", "Bu pakete ortalama boydaki bir dergiden 25 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya3 top fotokopi kağıdı sığabilir.", "36", 20.0 },
                    { 3, "Large", "16.0 - 20.0 kg", "Bu pakete ortalama boydaki bir dergiden 25 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya4 top fotokopi kağıdı sığabilir.", "41", 30.0 },
                    { 4, "X-Large", "21.0 - 25.0 kg", "Ortalama koli boyutu 30Cm x 22cm x 22cm", "46", 40.0 },
                    { 5, "Dosya - Evrak", "5 Kg", "", "5", 20.0 },
                    { 6, "Koli", "21.0 - 25.0 kg", "Ortalama koli boyutu 30Cm x 22cm x 22cm", "45", 40.0 }
                });

            migrationBuilder.InsertData(
                table: "CargoStatus",
                columns: new[] { "Id", "Information", "ShippingStatusName" },
                values: new object[,]
                {
                    { 1, "Kargonuz çıkış şubesinden transfer merkezine gönderilmek üzere aracımıza yüklenmiştir.", "Kargoya Verildi" },
                    { 2, "Kargonuz çıkış transfer merkezinden varış transfer merkezine gönderiliyor.", "Yolda" },
                    { 3, "Kargonuz varış transfer merkezine indirilmiştir.", "Yolda" },
                    { 4, "Kargonuz varış transfer merkezinden varış şubesine gönderiliyor.", "Yolda" },
                    { 5, "Kargonuz transfer merkezimizden teslimat şubemize ulaşmıştır", "Teslimat Şubesinde" },
                    { 6, "Kargonuz teslim edilmek üzere kuryeye zimmetlenmiştir.", "Teslimatta" },
                    { 7, "Kargo alıcıya teslim edildi.", "Teslim Edildi" },
                    { 8, "Geldik yoktunuz CcC.", "Teslim Edilemedi" }
                });

            migrationBuilder.InsertData(
                table: "CargoTransportationConditions",
                columns: new[] { "Id", "CargoTransportationConditionsName", "CargoTransportationConditionsPrice" },
                values: new object[,]
                {
                    { 1, "Kırılabilir", 20.0 },
                    { 2, "Dökülebilir", 30.0 },
                    { 3, "Normal", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "CargoType",
                columns: new[] { "Id", "CargoTypeName", "CargoTypePrice" },
                values: new object[,]
                {
                    { 1, "Normal Teslimat", 15.0 },
                    { 2, "Aynı Gün Teslimat", 30.0 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryName" },
                values: new object[] { 1, "Türkiye" });

            migrationBuilder.InsertData(
                table: "CustomerMobil",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "NumberPhone", "Password", "Surname", "TcNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Local).AddTicks(4576), "test@gmail.com", "Hamza", "05417434515", "asdasd123a", "Özer", "10000000000" },
                    { 2, new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Local).AddTicks(4578), "test2@gmail.com", "Murat", "05415414141", "asdasd123asd", "Çalış", "11000000000" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "Email", "Name", "NumberPhone", "Surname", "TCNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Local).AddTicks(4428), "2.09.2023", "test@gmail.com", "Hamza", "01234567890", "Özer", "00000000000" },
                    { 2, new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Local).AddTicks(4434), "2.09.2023", "test2@gmail.com", "Murat", "01234567891", "Çalış", "00000000001" },
                    { 3, new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Local).AddTicks(4435), "2.09.2023", "test3@gmail.com", "Ömer", "01234567892", "Küçükahıskalı", "00000000002" }
                });

            migrationBuilder.InsertData(
                table: "EmployeesType",
                columns: new[] { "Id", "EmployeesTypeName" },
                values: new object[,]
                {
                    { 1, "Müdür" },
                    { 2, "Kasiyer" },
                    { 3, "Kurye" }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[,]
                {
                    { 1, "Alıcı Ödemeli" },
                    { 2, "Gönderici Ödemeli" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CountryId", "ProvinceName" },
                values: new object[] { 1, 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "DistrictName", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Adalar", 1 },
                    { 2, "Arnavutköy", 1 },
                    { 3, "Ataşehir", 1 },
                    { 4, "Avcılar", 1 },
                    { 5, "Bağcılar", 1 },
                    { 6, "Bahçelievler", 1 },
                    { 7, "Bakırköy", 1 },
                    { 8, "Başakşehir", 1 },
                    { 9, "Bayrampaşa", 1 },
                    { 10, "Beşiktaş", 1 },
                    { 11, "Beykoz", 1 },
                    { 12, "Beylikdüzü", 1 },
                    { 13, "Beyoğlu", 1 },
                    { 14, "Büyükçekmece", 1 },
                    { 15, "Çatalca", 1 },
                    { 16, "Çekmeköy", 1 },
                    { 17, "Esenler", 1 },
                    { 18, "Esenyurt", 1 },
                    { 19, "Eyüpsultan", 1 },
                    { 20, "Fatih", 1 },
                    { 21, "Gaziosmanpaşa", 1 },
                    { 22, "Güngören", 1 },
                    { 23, "Kadıköy", 1 },
                    { 24, "Kağıthane", 1 },
                    { 25, "Kartal", 1 },
                    { 26, "Küçükçekmece", 1 },
                    { 27, "Maltepe", 1 },
                    { 28, "Pendik", 1 },
                    { 29, "Sancaktepe", 1 },
                    { 30, "Sarıyer", 1 },
                    { 31, "Silivri", 1 },
                    { 32, "Sultanbeyli", 1 },
                    { 33, "Sultangazi", 1 },
                    { 34, "Şile", 1 },
                    { 35, "Şişli", 1 },
                    { 36, "Tuzla", 1 },
                    { 37, "Ümraniye", 1 },
                    { 38, "Üsküdar", 1 },
                    { 39, "Zeytinburnu", 1 }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BranchName", "DistrictId" },
                values: new object[,]
                {
                    { 1, "Adalar", 1 },
                    { 2, "Arnavutköy", 2 },
                    { 3, "Ataşehir", 3 },
                    { 4, "Avcılar", 4 },
                    { 5, "Bağcılar", 5 },
                    { 6, "Bahçelievler", 6 },
                    { 7, "Bakırköy", 7 },
                    { 8, "Başakşehir", 8 },
                    { 9, "Bayrampaşa", 9 },
                    { 10, "Beşiktaş", 10 },
                    { 11, "Beykoz", 11 },
                    { 12, "Beylikdüzü", 12 },
                    { 13, "Beyoğlu", 13 },
                    { 14, "Büyükçekmece", 14 },
                    { 15, "Çatalca", 15 },
                    { 16, "Çekmeköy", 16 },
                    { 17, "Esenler", 17 },
                    { 18, "Esenyurt", 18 },
                    { 19, "Eyüpsultan", 19 },
                    { 20, "Fatih", 20 },
                    { 21, "Gaziosmanpaşa", 21 },
                    { 22, "Güngören", 22 },
                    { 23, "Kadıköy", 23 },
                    { 24, "Kağıthane", 24 },
                    { 25, "Kartal", 25 },
                    { 26, "Küçükçekmece", 26 },
                    { 27, "Maltepe", 27 },
                    { 28, "Pendik", 28 },
                    { 29, "Sancaktepe", 29 },
                    { 30, "Sarıyer", 30 },
                    { 31, "Silivri", 31 },
                    { 32, "Sultanbeyli", 32 },
                    { 33, "Sultangazi", 33 },
                    { 34, "Şile", 34 },
                    { 35, "Şişli", 35 },
                    { 36, "Tuzla", 36 },
                    { 37, "Ümraniye", 37 },
                    { 38, "Üsküdar", 38 },
                    { 39, "Zeytinburnu", 39 }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 1, 1, "Maden Mahallesi" },
                    { 2, 1, "Burgazada Mahallesi" },
                    { 3, 1, "Heybeliada Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 4, 1, "Kınalıada Mahallesi" },
                    { 5, 1, "Nizam Mahallesi" },
                    { 6, 2, "Çilingir Mahallesi" },
                    { 7, 2, "Adnan Menderes Mahallesi" },
                    { 8, 2, "Anadolu Mahallesi" },
                    { 9, 2, "Baklalı Mahallesi" },
                    { 10, 2, "Balaban Mahallesi" },
                    { 11, 2, "Boğazköy İstiklal Mahallesi" },
                    { 12, 2, "Bolluca Mahallesi" },
                    { 13, 2, "Boyalık Mahallesi" },
                    { 14, 2, "Deliklikaya Mahallesi" },
                    { 15, 2, "Dursunköy Mahallesi" },
                    { 16, 2, "Durusu Mahallesi" },
                    { 17, 2, "Fatih Mahallesi" },
                    { 18, 2, "Hacımaşlı Mahallesi" },
                    { 19, 2, "Hadımköy Mahallesi" },
                    { 20, 2, "Haraççı Mahallesi" },
                    { 21, 2, "Hastane Mahallesi" },
                    { 22, 2, "Hicret Mahallesi" },
                    { 23, 2, "İslambey Mahallesi" },
                    { 24, 2, "İmrehor Mahallesi" },
                    { 25, 2, "Karaburun Mahallesi" },
                    { 26, 2, "Karlıbayır Mahallesi" },
                    { 27, 2, "M.Fevzi Çakmak Mahallesi" },
                    { 28, 2, "Mavigöl Mahallesi" },
                    { 29, 2, "Mehmet Akif Ersoy Mahallesi" },
                    { 30, 2, "Merkez Mahallesi" },
                    { 31, 2, "Merkez Atatürk Mahallesi" },
                    { 32, 2, "Mustafa Kemal Paşa Mahallesi" },
                    { 33, 2, "Nenehatun Mahallesi" },
                    { 34, 2, "Ömerli Mahallesi" },
                    { 35, 2, "Sazlıbosna Mahallesi" },
                    { 36, 2, "Taşoluk Mahallesi" },
                    { 37, 2, "Tayakadın Mahallesi" },
                    { 38, 2, "Terkos Mahallesi" },
                    { 39, 2, "Yassıören Mahallesi" },
                    { 40, 2, "Yavuz Selim Mahallesi" },
                    { 41, 2, "Yeniköy Mahallesi" },
                    { 42, 2, "Yeşilbayır Mahallesi" },
                    { 43, 2, "Yunusemre Mahallesi" },
                    { 44, 3, "Mustafa Kemal Mahallesi" },
                    { 45, 3, "Aşık Veysel Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 46, 3, "Atatürk Mahallesi" },
                    { 47, 3, "Barbaros Mahallesi" },
                    { 48, 3, "Esatpaşa Mahallesi" },
                    { 49, 3, "Ferhatpaşa Mahallesi" },
                    { 50, 3, "Fetih Mahallesi" },
                    { 51, 3, "İçerenköy Mahallesi" },
                    { 52, 3, "İnönü Mahallesi" },
                    { 53, 3, "Kayışdağı Mahallesi" },
                    { 54, 3, "Küçükbakkalköy Mahallesi" },
                    { 55, 3, "Mevlana Mahallesi" },
                    { 56, 3, "Mimar Sinan Mahallesi" },
                    { 57, 3, "Örnek Mahallesi" },
                    { 58, 3, "Yeni Çamlıca Mahallesi" },
                    { 59, 3, "Yenişehir Mahallesi" },
                    { 60, 3, "Yeni Sahra Mahallesi" },
                    { 61, 4, "Cihangir Mahallesi" },
                    { 62, 4, "Ambarlı Mahallesi" },
                    { 63, 4, "Denizköşkler Mahallesi" },
                    { 64, 4, "Firuzköy Mahallesi" },
                    { 65, 4, "Gümüşpala Mahallesi" },
                    { 66, 4, "M.K.Paşa Mahallesi" },
                    { 67, 4, "Merkez Mahallesi" },
                    { 68, 4, "Üniversite Mahallesi" },
                    { 69, 4, "Tahtakale Mahallesi" },
                    { 70, 4, "Yeşilkent Mahallesi" },
                    { 71, 5, "Yıldıztepe Mahallesi" },
                    { 72, 5, "15 Temmuz Mahallesi" },
                    { 73, 5, "100.Yıl Mahallesi" },
                    { 74, 5, "Bağlar Mahallesi" },
                    { 75, 5, "Barboros Mahallesi" },
                    { 76, 5, "Çınar Mahallesi" },
                    { 77, 5, "Demirkapı Mahallesi" },
                    { 78, 5, "Fatih Mahallesi" },
                    { 79, 5, "Fevzi Çakmak Mahallesi" },
                    { 80, 5, "Göztepe Mahallesi" },
                    { 81, 5, "Güneşli Mahallesi" },
                    { 82, 5, "Hürriyet Mahallesi" },
                    { 83, 5, "İnönü Mahallesi" },
                    { 84, 5, "Kazım Karabekir Mahallesi" },
                    { 85, 5, "Kemalpaşa Mahallesi" },
                    { 86, 5, "Kirazlı Mahallesi" },
                    { 87, 5, "Mahmutbey Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 88, 5, "Merkez Mahallesi" },
                    { 89, 5, "Sancaktepe Mahallesi" },
                    { 90, 5, "Yavuzselim Mahallesi" },
                    { 91, 5, "Yenigün Mahallesi" },
                    { 92, 5, "Yenimahalle Mahallesi" },
                    { 93, 6, "Siyavuşpaşa Mahallesi" },
                    { 94, 6, "Bahçelievler Mahallesi" },
                    { 95, 6, "Cumhuriyet Mahallesi" },
                    { 96, 6, "Çobançeşme Mahallesi" },
                    { 97, 6, "Fevziçakmak Mahallesi" },
                    { 98, 6, "Hürriyet Mahallesi" },
                    { 99, 6, "Kocasinan Mahallesi" },
                    { 100, 6, "Soğanlı Mahallesi" },
                    { 101, 6, "Şirinevler Mahallesi" },
                    { 102, 6, "Yenibosna Merkez Mahallesi" },
                    { 103, 6, "Zafer Mahallesi" },
                    { 104, 7, "Osmaniye Mahallesi" },
                    { 105, 7, "Ataköy 1.Kısım Mahallesi" },
                    { 106, 7, "Ataköy 2.5.6.Kısım Mahallesi" },
                    { 107, 7, "Ataköy 3.4.11. Kısım Mahallesi" },
                    { 108, 7, "Ataköy 7-8-9-10.Kısım Mahallesi" },
                    { 109, 7, "Basınköy Mahallesi" },
                    { 110, 7, "Cevizlik Mahallesi" },
                    { 111, 7, "Kartaltepe Mahallesi" },
                    { 112, 7, "Sakızağacı Mahallesi" },
                    { 113, 7, "Şenlikköy Mahallesi" },
                    { 114, 7, "Yenimahalle Mahallesi" },
                    { 115, 7, "Yeşilköy Mahallesi" },
                    { 116, 7, "Yeşilyurt Mahallesi" },
                    { 117, 7, "Zeytinlik Mahallesi" },
                    { 118, 7, "Zuhuratbaba Mahallesi" },
                    { 119, 8, "Kayabaşı Mahallesi" },
                    { 120, 8, "Altınşehir Mahallesi" },
                    { 121, 8, "Başakşehir Mahallesi" },
                    { 122, 8, "Bahçeşehir 1.Kısım Mahallesi" },
                    { 123, 8, "Bahçeşehir 2.Kısım Mahallesi" },
                    { 124, 8, "Başak Mahallesi" },
                    { 125, 8, "Güvercintepe Mahallesi" },
                    { 126, 8, "Şahintepesi Mahallesi" },
                    { 127, 8, "Şamlar Mahallesi" },
                    { 128, 8, "Ziya Gökalp Mahallesi" },
                    { 129, 9, "Terazidere Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 130, 9, "Altıntepsi Mahallesi" },
                    { 131, 9, "Cevatpaşa Mahallesi" },
                    { 132, 9, "İsmetpaşa Mahallesi" },
                    { 133, 9, "Kartaltepe Mahallesi" },
                    { 134, 9, "Kocatepe Mahallesi" },
                    { 135, 9, "Muratpaşa Mahallesi" },
                    { 136, 9, "Orta Mahallesi" },
                    { 137, 9, "Vatan Mahallesi" },
                    { 138, 9, "Yenidoğan Mahallesi" },
                    { 139, 9, "Yıldırım Mahallesi" },
                    { 140, 10, "Türkali Mahallesi" },
                    { 141, 10, "Abbasağa Mahallesi" },
                    { 142, 10, "Akat Mahallesi" },
                    { 143, 10, "Arnavutköy Mahallesi" },
                    { 144, 10, "Balmumcu Mahallesi" },
                    { 145, 10, "Bebek Mahallesi" },
                    { 146, 10, "Cihannüma Mahallesi" },
                    { 147, 10, "Dikilitaş Mahallesi" },
                    { 148, 10, "Etiler Mahallesi" },
                    { 149, 10, "Gayrettepe Mahallesi" },
                    { 150, 10, "Konaklar Mahallesi" },
                    { 151, 10, "Kuruçeşme Mahallesi" },
                    { 152, 10, "Kültür Mahallesi" },
                    { 153, 10, "Levazım Mahallesi" },
                    { 154, 10, "Levent Mahallesi" },
                    { 155, 10, "Mecidiye Mahallesi" },
                    { 156, 10, "Muradiye Mahallesi" },
                    { 157, 10, "Nisbetiye Mahallesi" },
                    { 158, 10, "Ortaköy Mahallesi" },
                    { 159, 10, "Sinanpaşa Mahallesi" },
                    { 160, 10, "Ulus Mahallesi" },
                    { 161, 10, "Vişnezade Mahallesi" },
                    { 162, 10, "Yıldız Mahallesi" },
                    { 163, 11, "Rüzgarlıbahçe Mahallesi" },
                    { 164, 11, "Acarlar Mahallesi" },
                    { 165, 11, "Akbaba Mahallesi" },
                    { 166, 11, "Alibahadır Mahallesi" },
                    { 167, 11, "A.Hisarı Mahallesi" },
                    { 168, 11, "A.Feneri Mahallesi" },
                    { 169, 11, "A.Kavağı Mahallesi" },
                    { 170, 11, "Baklacı Mahallesi" },
                    { 171, 11, "Beykoz Merkez Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 172, 11, "Bozhane Mahallesi" },
                    { 173, 11, "Cumhuriyet Mahallesi" },
                    { 174, 11, "Çamlıbahçe Mahallesi" },
                    { 175, 11, "Çengeldere Mahallesi" },
                    { 176, 11, "Çiftlik Mahallesi" },
                    { 177, 11, "Çigdem Mahallesi" },
                    { 178, 11, "Çubuklu Mahallesi" },
                    { 179, 11, "Dereseki Mahallesi" },
                    { 180, 11, "Elmalı Mahallesi" },
                    { 181, 11, "Fatih Mahallesi" },
                    { 182, 11, "Göksu Mahallesi" },
                    { 183, 11, "Göllü Mahallesi" },
                    { 184, 11, "Görele Mahallesi" },
                    { 185, 11, "Göztepe Mahallesi" },
                    { 186, 11, "Gümüşsuyu Mahallesi" },
                    { 187, 11, "İncirköy Mahallesi" },
                    { 188, 11, "İshaklı Mahallesi" },
                    { 189, 11, "Kanlıca Mahallesi" },
                    { 190, 11, "Kavacık Mahallesi" },
                    { 191, 11, "Kaynarca Mahallesi" },
                    { 192, 11, "Kılıçlı Mahallesi" },
                    { 193, 11, "M.Şevketpaşa Mahallesi" },
                    { 194, 11, "Ortaçeşme Mahallesi" },
                    { 195, 11, "Öğümce Mahallesi" },
                    { 196, 11, "Örnekköy Mahallesi" },
                    { 197, 11, "Paşabahçe Mahallesi" },
                    { 198, 11, "Paşamandıra Mahallesi" },
                    { 199, 11, "Polenezköy Mahallesi" },
                    { 200, 11, "Poyrazköy Mahallesi" },
                    { 201, 11, "Riva Mahallesi" },
                    { 202, 11, "Soğuksu Mahallesi" },
                    { 203, 11, "Tokatköy Mahallesi" },
                    { 204, 11, "Yalıköy Mahallesi" },
                    { 205, 11, "Yavuzselim Mahallesi" },
                    { 206, 11, "Yenimahalle Mahallesi" },
                    { 207, 11, "Zerzevatçı Mahallesi" },
                    { 208, 12, "Yakuplu Mahallesi" },
                    { 209, 12, "Adnan Kahveci Mahallesi" },
                    { 210, 12, "Barış Mahallesi" },
                    { 211, 12, "Büyükşehir Mahallesi" },
                    { 212, 12, "Cumhuriyet Mahallesi" },
                    { 213, 12, "Dereağzı Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 214, 12, "Gürpınar Mahallesi" },
                    { 215, 12, "Kavaklı Mahallesi" },
                    { 216, 12, "Marmara Mahallesi" },
                    { 217, 12, "Sahil Mahallesi" },
                    { 218, 13, "Çukur Mahallesi" },
                    { 219, 13, "Emekyemez Mahallesi" },
                    { 220, 13, "Evliya Çelebi Mahallesi" },
                    { 221, 13, "Fetihtepe Mahallesi" },
                    { 222, 13, "Firuzağa Mahallesi" },
                    { 223, 13, "Gümüşsuyu Mahallesi" },
                    { 224, 13, "Hacıahmet Mahallesi" },
                    { 225, 13, "Hacımimi Mahallesi" },
                    { 226, 13, "Halıcıoğlu Mahallesi" },
                    { 227, 13, "Hüseyinağa Mahallesi" },
                    { 228, 13, "İstiklal Mahallesi" },
                    { 229, 13, "Kadımehmet Mahallesi" },
                    { 230, 13, "Kalyoncukulluk Mahallesi" },
                    { 231, 13, "Kamerhatun Mahallesi" },
                    { 232, 13, "Kaptanpaşa Mahallesi" },
                    { 233, 13, "Katip Mustafa Çelebi Mahallesi" },
                    { 234, 13, "Keçecipiri Mahallesi" },
                    { 235, 13, "Kemankeş Mahallesi" },
                    { 236, 13, "Kılıçalipaşa Mahallesi" },
                    { 237, 13, "Kocatepe Mahallesi" },
                    { 238, 13, "Kulaksız Mahallesi" },
                    { 239, 13, "Kuloğlu Mahallesi" },
                    { 240, 13, "Küçükpiyale Mahallesi" },
                    { 241, 13, "Müeyyetzade Mahallesi" },
                    { 242, 13, "Ömeravni Mahallesi" },
                    { 243, 13, "Örnektepe Mahallesi" },
                    { 244, 13, "Pirimehmetpaşa Mahallesi" },
                    { 245, 13, "Piyalepaşa Mahallesi" },
                    { 246, 13, "Pürtelaş Mahallesi" },
                    { 247, 13, "Sururi Mahallesi" },
                    { 248, 13, "Sütlüce Mahallesi" },
                    { 249, 13, "Şahkulu Mahallesi" },
                    { 250, 13, "Şehit Muhtar Mahallesi" },
                    { 251, 13, "Yahya Kahya Mahallesi" },
                    { 252, 13, "Yenişehir Mahallesi" },
                    { 253, 14, "Fatih Mahallesi" },
                    { 254, 14, "19 Mayıs Mahallesi" },
                    { 255, 14, "Ahmediye Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 256, 14, "Alkent 2000 Mahallesi" },
                    { 257, 14, "Atatürk Mahallesi" },
                    { 258, 14, "Bahçelievler Mahallesi" },
                    { 259, 14, "Celaliye Mahallesi" },
                    { 260, 14, "Cumhuriyet Mahallesi" },
                    { 261, 14, "Çakmaklı Mahallesi" },
                    { 262, 14, "Dizdariye Mahallesi" },
                    { 263, 14, "Ekinoba Mahallesi" },
                    { 264, 14, "Güzelce Mahallesi" },
                    { 265, 14, "Hürriyet Mahallesi" },
                    { 266, 14, "Kamiloba Mahallesi" },
                    { 267, 14, "Karaağaç Mahallesi" },
                    { 268, 14, "Kumburgaz Mahallesi" },
                    { 269, 14, "Mimaroba Mahallesi" },
                    { 270, 14, "Mimarsinan Mahallesi" },
                    { 271, 14, "Muratçeşme Mahallesi" },
                    { 272, 14, "Pınartepe Mahallesi" },
                    { 273, 14, "Sinanoba Mahallesi" },
                    { 274, 14, "Türkoba Mahallesi" },
                    { 275, 14, "Ulus Mahallesi" },
                    { 276, 14, "Yenimahalle Mahallesi" },
                    { 277, 15, "Yazlık Mahallesi" },
                    { 278, 15, "Akalan Mahallesi" },
                    { 279, 15, "Atatürk Mahallesi" },
                    { 280, 15, "Aydınlar Mahallesi" },
                    { 281, 15, "Bahşayiş Mahallesi" },
                    { 282, 15, "Başak Mahallesi" },
                    { 283, 15, "Belgrat Mahallesi" },
                    { 284, 15, "Celepköy Mahallesi" },
                    { 285, 15, "Çakıl Mahallesi" },
                    { 286, 15, "Çanakça Mahallesi" },
                    { 287, 15, "Çiftlikköy Mahallesi" },
                    { 288, 15, "Dağyenice Mahallesi" },
                    { 289, 15, "Elbasan Mahallesi" },
                    { 290, 15, "Fatih Mahallesi" },
                    { 291, 15, "Ferhatpaşa Mahallesi" },
                    { 292, 15, "Gökçeali Mahallesi" },
                    { 293, 15, "Gümüşpınar Mahallesi" },
                    { 294, 15, "Hallaçlı Mahallesi" },
                    { 295, 15, "Hisarbeyli Mahallesi" },
                    { 296, 15, "İhsaniye Mahallesi" },
                    { 297, 15, "İnceğiz Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 298, 15, "İzzettin Mahallesi" },
                    { 299, 15, "Kabakça Mahallesi" },
                    { 300, 15, "Kaleiçi Mahallesi" },
                    { 301, 15, "Kalfa Mahallesi" },
                    { 302, 15, "Karacaköy Mahallesi" },
                    { 303, 15, "Karamandere Mahallesi" },
                    { 304, 15, "Kestanelik Mahallesi" },
                    { 305, 15, "Kızılcaali Mahallesi" },
                    { 306, 15, "Muratbey Mahallesi" },
                    { 307, 15, "Nakkaş Mahallesi" },
                    { 308, 15, "Oklalı Mahallesi" },
                    { 309, 15, "Ormanlı Mahallesi" },
                    { 310, 15, "Ovayenice Mahallesi" },
                    { 311, 15, "Örcünlü Mahallesi" },
                    { 312, 15, "Örencik Mahallesi" },
                    { 313, 15, "Subaşı Mahallesi" },
                    { 314, 15, "Yalıköy Mahallesi" },
                    { 315, 15, "Yaylacık Mahallesi" },
                    { 316, 16, "Sırapınar Mahallesi" },
                    { 317, 16, "Alemdağ Mahallesi" },
                    { 318, 16, "Aydınlar Mahallesi" },
                    { 319, 16, "Cumhuriyet Mahallesi" },
                    { 320, 16, "Çamlık Mahallesi" },
                    { 321, 16, "Çatalmeşe Mahallesi" },
                    { 322, 16, "Ekşioğlu Mahallesi" },
                    { 323, 16, "Güngören Mahallesi" },
                    { 324, 16, "Hamidiye Mahallesi" },
                    { 325, 16, "Hüseyinli Mahallesi" },
                    { 326, 16, "Kirazlıdere Mahallesi" },
                    { 327, 16, "Koçullu Mahallesi" },
                    { 328, 16, "Mehmet Akif Mahallesi" },
                    { 329, 16, "Merkez Mahallesi" },
                    { 330, 16, "Mimar Sinan Mahallesi" },
                    { 331, 16, "Nişantepe Mahallesi" },
                    { 332, 16, "Ömerli Mahallesi" },
                    { 333, 16, "Reşadiye Mahallesi" },
                    { 334, 16, "Soğukpınar Mahallesi" },
                    { 335, 16, "Sultançiftliği Mahallesi" },
                    { 336, 16, "Taşdelen Mahallesi" },
                    { 337, 17, "Fatih Mahallesi" },
                    { 338, 17, "15 Temmuz Mahallesi" },
                    { 339, 17, "Birlik Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 340, 17, "Çiftehavuzlar Mahallesi" },
                    { 341, 17, "Davutpaşa Mahallesi" },
                    { 342, 17, "Fevziçakmak Mahallesi" },
                    { 343, 17, "Havaalanı Mahallesi" },
                    { 344, 17, "K.Karabekir Mahallesi" },
                    { 345, 17, "Kemer Mahallesi" },
                    { 346, 17, "Menderes Mahallesi" },
                    { 347, 17, "Mimarsinan Mahallesi" },
                    { 348, 17, "Namıkkemal Mahallesi" },
                    { 349, 17, "Ninehatun Mahallesi" },
                    { 350, 17, "Oruçreis Mahallesi" },
                    { 351, 17, "Tuna Mahallesi" },
                    { 352, 17, "Turgutreis Mahallesi" },
                    { 353, 17, "Yavuzselim Mahallesi" },
                    { 354, 18, "İncirtepe Mahallesi" },
                    { 355, 18, "Akçaburgaz Mahallesi" },
                    { 356, 18, "Akevler Mahallesi" },
                    { 357, 18, "Akşemseddin Mahallesi" },
                    { 358, 18, "Ardıçlı Mahallesi" },
                    { 359, 18, "Aşık Veysel Mahallesi" },
                    { 360, 18, "Atatürk Mahallesi" },
                    { 361, 18, "Bağlarçeşme Mahallesi" },
                    { 362, 18, "Balıkyolu Mahallesi" },
                    { 363, 18, "Barbaros Hayrettin Paşa Mahallesi" },
                    { 364, 18, "Battalgazi Mahallesi" },
                    { 365, 18, "Cumhuriyet Mahallesi" },
                    { 366, 18, "Çınar Mahallesi" },
                    { 367, 18, "Esenkent Mahallesi" },
                    { 368, 18, "Fatih Mahallesi" },
                    { 369, 18, "Gökevler Mahallesi" },
                    { 370, 18, "Güzelyurt Mahallesi" },
                    { 371, 18, "Hürriyet Mahallesi" },
                    { 372, 18, "İnönü Mahallesi" },
                    { 373, 18, "İstiklal Mahallesi" },
                    { 374, 18, "Koza Mahallesi" },
                    { 375, 18, "Mehmet Akif Ersoy Mahallesi" },
                    { 376, 18, "Mehterçeşme Mahallesi" },
                    { 377, 18, "Mevlana Mahallesi" },
                    { 378, 18, "Namık Kemal Mahallesi" },
                    { 379, 18, "Necip Fazıl Kısakürek Mahallesi" },
                    { 380, 18, "Orhan Gazi Mahallesi" },
                    { 381, 18, "Osmangazi Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 382, 18, "Örnek Mahallesi" },
                    { 383, 18, "Pınar Mahallesi" },
                    { 384, 18, "Piri Reis Mahallesi" },
                    { 385, 18, "Saadetdere Mahallesi" },
                    { 386, 18, "Selahaddin Eyyubi Mahallesi" },
                    { 387, 18, "Sultaniye Mahallesi" },
                    { 388, 18, "Süleymaniye Mahallesi" },
                    { 389, 18, "Şehitler Mahallesi" },
                    { 390, 18, "Talatpaşa Mahallesi" },
                    { 391, 18, "Turgut Özal Mahallesi" },
                    { 392, 18, "Üçevler Mahallesi" },
                    { 393, 18, "Yenikent Mahallesi" },
                    { 394, 18, "Yeşilkent Mahallesi" },
                    { 395, 18, "Yunus Emre Mahallesi" },
                    { 396, 18, "Zafer Mahallesi" },
                    { 397, 19, "Eyüpsultan Merkez Mahallesi" },
                    { 398, 19, "5.Levent Mahallesi" },
                    { 399, 19, "Ağaçlı Mahallesi" },
                    { 400, 19, "Akpınar Mahallesi" },
                    { 401, 19, "Akşemsettin Mahallesi" },
                    { 402, 19, "Alibeyköy Mahallesi" },
                    { 403, 19, "Çırçır Mahallesi" },
                    { 404, 19, "Çiftalan Mahallesi" },
                    { 405, 19, "Defterdar Mahallesi" },
                    { 406, 19, "Düğmeciler Mahallesi" },
                    { 407, 19, "Emniyettepe Mahallesi" },
                    { 408, 19, "Esentepe Mahallesi" },
                    { 409, 19, "Göktürk Merkez Mahallesi" },
                    { 410, 19, "Güzeltepe Mahallesi" },
                    { 411, 19, "Işıklar Mahallesi" },
                    { 412, 19, "İhsaniye Mahallesi" },
                    { 413, 19, "İslambey Mahallesi" },
                    { 414, 19, "Karadolap Mahallesi" },
                    { 415, 19, "Mimarsinan Mahallesi" },
                    { 416, 19, "Mithatpaşa Mahallesi" },
                    { 417, 19, "Nişanca Mahallesi" },
                    { 418, 19, "Odayeri Mahallesi" },
                    { 419, 19, "Pirinçci Mahallesi" },
                    { 420, 19, "Rami Cuma Mahallesi" },
                    { 421, 19, "Rami Yeni Mahallesi" },
                    { 422, 19, "Sakarya Mahallesi" },
                    { 423, 19, "Silahtarağa Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 424, 19, "Topçular Mahallesi" },
                    { 425, 19, "Yeşilpınar Mahallesi" },
                    { 426, 20, "Şehsuvarbey Mahallesi" },
                    { 427, 20, "Yavuz Sinan Mahallesi" },
                    { 428, 20, "Aksaray Mahallesi" },
                    { 429, 20, "Akşemsettin Mahallesi" },
                    { 430, 20, "Alemdar Mahallesi" },
                    { 431, 20, "Ali Kuşçu Mahallesi" },
                    { 432, 20, "Atikali Mahallesi" },
                    { 433, 20, "Ayvansaray Mahallesi" },
                    { 434, 20, "Balabanağa Mahallesi" },
                    { 435, 20, "Balat Mahallesi" },
                    { 436, 20, "Beyazıt Mahallesi" },
                    { 437, 20, "Binbirdirek Mahallesi" },
                    { 438, 20, "Cankurtaran Mahallesi" },
                    { 439, 20, "Cerrahpaşa Mahallesi" },
                    { 440, 20, "Cibali Mahallesi" },
                    { 441, 20, "Demirtaş Mahallesi" },
                    { 442, 20, "Dervişali Mahallesi" },
                    { 443, 20, "Emin Sinan Mahallesi" },
                    { 444, 20, "Hacı Kadın Mahallesi" },
                    { 445, 20, "Haseki Sultan Mahallesi" },
                    { 446, 20, "Hırka-İ Şerif Mahallesi" },
                    { 447, 20, "Hobyar Mahallesi" },
                    { 448, 20, "Hoca Gıyasettin Mahallesi" },
                    { 449, 20, "Hocapaşa Mahallesi" },
                    { 450, 20, "İskenderpaşa Mahallesi" },
                    { 451, 20, "Kalenderhane Mahallesi" },
                    { 452, 20, "Karagümrük Mahallesi" },
                    { 453, 20, "Katip Kasım Mahallesi" },
                    { 454, 20, "Kemalpaşa Mahallesi" },
                    { 455, 20, "Kocamustafapaşa Mahallesi" },
                    { 456, 20, "Küçükayasofya Mahallesi" },
                    { 457, 20, "Mercan Mahallesi" },
                    { 458, 20, "Mesihpaşa Mahallesi" },
                    { 459, 20, "Mevlanakapı Mahallesi" },
                    { 460, 20, "Mimar Hayrettin Mahallesi" },
                    { 461, 20, "Mimar Kemalettin Mahallesi" },
                    { 462, 20, "Molla Gürani Mahallesi" },
                    { 463, 20, "Molla Fenari Mahallesi" },
                    { 464, 20, "Molla Hüsrev Mahallesi" },
                    { 465, 20, "Muhsine Hatun Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 466, 20, "Nişanca Mahallesi" },
                    { 467, 20, "Rüstempaşa Mahallesi" },
                    { 468, 20, "Saraçishak Mahallesi" },
                    { 469, 20, "Sarıdemir Mahallesi" },
                    { 470, 20, "Seyyid Ömer Mahallesi" },
                    { 471, 20, "Silivrikapı Mahallesi" },
                    { 472, 20, "Sultanahmet Mahallesi" },
                    { 473, 20, "Sururi Mahallesi" },
                    { 474, 20, "Süleymaniye Mahallesi" },
                    { 475, 20, "Sümbülefendi Mahallesi" },
                    { 476, 20, "Şehremini Mahallesi" },
                    { 477, 20, "Tahtakale Mahallesi" },
                    { 478, 20, "Tayahatun Mahallesi" },
                    { 479, 20, "Topkapı Mahallesi" },
                    { 480, 20, "Yavuz Selim Mahallesi" },
                    { 481, 20, "Yedikule Mahallesi" },
                    { 482, 20, "Zeyrek Mahallesi" },
                    { 483, 21, "Karayolları Mahallesi" },
                    { 484, 21, "B.H.Paşa Mahallesi" },
                    { 485, 21, "Bağlarbaşı Mahallesi" },
                    { 486, 21, "Fevziçakmak Mahallesi" },
                    { 487, 21, "Hürriyet Mahallesi" },
                    { 488, 21, "Karadeniz Mahallesi" },
                    { 489, 21, "Karlıtepe Mahallesi" },
                    { 490, 21, "Kazım Karabekir Mahallesi" },
                    { 491, 21, "Merkez Mahallesi" },
                    { 492, 21, "Mevlana Mahallesi" },
                    { 493, 21, "Pazariçi Mahallesi" },
                    { 494, 21, "Sarıgöl Mahallesi" },
                    { 495, 21, "Şemsipaşa Mahallesi" },
                    { 496, 21, "Yeni Mahalle" },
                    { 497, 21, "Yenidoğan Mahallesi" },
                    { 498, 21, "Yıldıztabya Mahallesi" },
                    { 499, 22, "Mareşal Çakmak Mahallesi" },
                    { 500, 22, "Abdurrahman Nafiz Gürman Mahallesi" },
                    { 501, 22, "Akıncılar Mahallesi" },
                    { 502, 22, "Gençosman Mahallesi" },
                    { 503, 22, "Güneştepe Mahallesi" },
                    { 504, 22, "Güven Mahallesi" },
                    { 505, 22, "Haznedar Mahallesi" },
                    { 506, 22, "Mehmet Nesih Özmen Mahallesi" },
                    { 507, 22, "Merkez Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 508, 22, "Sanayi Mahallesi" },
                    { 509, 22, "Tozkoroparan Mahallesi" },
                    { 510, 23, "Dumlupınar Mahallesi" },
                    { 511, 23, "Acıbadem Mahallesi" },
                    { 512, 23, "Bostancı Mahallesi" },
                    { 513, 23, "Caddebostan Mahallesi" },
                    { 514, 23, "Caferağa Mahallesi" },
                    { 515, 23, "Eğitim Mahallesi" },
                    { 516, 23, "Erenköy Mahallesi" },
                    { 517, 23, "Fenerbahçe Mahallesi" },
                    { 518, 23, "Feneryolu Mahallesi" },
                    { 519, 23, "Fikirtepe Mahallesi" },
                    { 520, 23, "Göztepe Mahallesi" },
                    { 521, 23, "Hasanpaşa Mahallesi" },
                    { 522, 23, "Koşuyolu Mahallesi" },
                    { 523, 23, "Kozyatağı Mahallesi" },
                    { 524, 23, "Merdivenköy Mahallesi" },
                    { 525, 23, "Ondokuz Mayıs Mahallesi" },
                    { 526, 23, "Osmanağa Mahallesi" },
                    { 527, 23, "Rasimpaşa Mahallesi" },
                    { 528, 23, "Sahrayıcedit Mahallesi" },
                    { 529, 23, "Suadiye Mahallesi" },
                    { 530, 23, "Zühtüpaşa Mahallesi" },
                    { 531, 24, "Gültepe Mahallesi" },
                    { 532, 24, "Çağlayan Mahallesi" },
                    { 533, 24, "Çeliktepe Mahallesi" },
                    { 534, 24, "Emniyetevleri Mahallesi" },
                    { 535, 24, "Gürsel Mahallesi" },
                    { 536, 24, "Hamidiye Mahallesi" },
                    { 537, 24, "Harmantepe Mahallesi" },
                    { 538, 24, "Hürriyet Mahallesi" },
                    { 539, 24, "M.Akif Ersoy Mahallesi" },
                    { 540, 24, "Merkez Mahallesi" },
                    { 541, 24, "Nurtepe Mahallesi" },
                    { 542, 24, "Ortabayır Mahallesi" },
                    { 543, 24, "Seyrantepe Mahallesi" },
                    { 544, 24, "Sultan Selim Mahallesi" },
                    { 545, 24, "Şirintepe Mahallesi" },
                    { 546, 24, "Talatpaşa Mahallesi" },
                    { 547, 24, "Telsizler Mahallesi" },
                    { 548, 24, "Yahya Kemal Mahallesi" },
                    { 549, 24, "Yeşilce Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 550, 25, "Orta Mahallesi" },
                    { 551, 25, "Atalar Mahallesi" },
                    { 552, 25, "Cevizli Mahallesi" },
                    { 553, 25, "Cumhuriyet Mahallesi" },
                    { 554, 25, "Çavuşoğlu Mahallesi" },
                    { 555, 25, "Esentepe Mahallesi" },
                    { 556, 25, "Gümüşpınar Mahallesi" },
                    { 557, 25, "Hürriyet Mahallesi" },
                    { 558, 25, "Karlıktepe Mahallesi" },
                    { 559, 25, "Kordonboyu Mahallesi" },
                    { 560, 25, "Orhantepe Mahallesi" },
                    { 561, 25, "Petrol İş Mahallesi" },
                    { 562, 25, "Soğanlık Yeni Mahallesi" },
                    { 563, 25, "Topselvi Mahallesi" },
                    { 564, 25, "Uğur Mumcu Mahallesi" },
                    { 565, 25, "Yakacık Çarşı Mahallesi" },
                    { 566, 25, "Yakacık Yeni Mahallesi" },
                    { 567, 25, "Yalı Mahallesi" },
                    { 568, 25, "Yukarı Mahallesi" },
                    { 569, 25, "Yunus Mahallesi" },
                    { 570, 26, "Yeşilova Mahallesi" },
                    { 571, 26, "Atatürk Mahallesi" },
                    { 572, 26, "Atakent Mahallesi" },
                    { 573, 26, "Beşyol Mahallesi" },
                    { 574, 26, "Cennet Mahallesi" },
                    { 575, 26, "Cumhuriyet Mahallesi" },
                    { 576, 26, "Fatih Mahallesi" },
                    { 577, 26, "Fevzi Çakmak Mahallesi" },
                    { 578, 26, "Gültepe Mahallesi" },
                    { 579, 26, "Halkalı Merkez Mahallesi" },
                    { 580, 26, "İnönü Mahallesi" },
                    { 581, 26, "İstasyon Mahallesi" },
                    { 582, 26, "Kartaltepe Mahallesi" },
                    { 583, 26, "Kanarya Mahallesi" },
                    { 584, 26, "Kemalpaşa Mahallesi" },
                    { 585, 26, "Mehmet Akif Mahallesi" },
                    { 586, 26, "Söğütlüçeşme Mahallesi" },
                    { 587, 26, "Sultanmurat Mahallesi" },
                    { 588, 26, "Tevfikbey Mahallesi" },
                    { 589, 26, "Yarımburgaz Mahallesi" },
                    { 590, 26, "Yenimahalle Mahallesi" },
                    { 591, 27, "Aydınevler Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 592, 27, "Altayçeşme Mahallesi" },
                    { 593, 27, "Altıntepe Mahallesi" },
                    { 594, 27, "Bağlarbaşı Mahallesi" },
                    { 595, 27, "Başıbüyük Mahallesi" },
                    { 596, 27, "Büyükbakkalköy Mahallesi" },
                    { 597, 27, "Cevizli Mahallesi" },
                    { 598, 27, "Çınar Mahallesi" },
                    { 599, 27, "Esenkent Mahallesi" },
                    { 600, 27, "Feyzullah Mahallesi" },
                    { 601, 27, "Fındıklı Mahallesi" },
                    { 602, 27, "Girne Mahallesi" },
                    { 603, 27, "Gülensu Mahallesi" },
                    { 604, 27, "Gülsuyu Mahallesi" },
                    { 605, 27, "İdealtepe Mahallesi" },
                    { 606, 27, "Küçükyalı Mahallesi" },
                    { 607, 27, "Yalı Mahallesi" },
                    { 608, 27, "Zümrütevler Mahallesi" },
                    { 609, 28, "Kurna Mahallesi" },
                    { 610, 28, "Ahmet Yesevi Mahallesi" },
                    { 611, 28, "Bahçelievler Mahallesi" },
                    { 612, 28, "Ballıca Mahallesi" },
                    { 613, 28, "Batı Mahallesi" },
                    { 614, 28, "Çamçeşme Mahallesi" },
                    { 615, 28, "Çamlık Mahallesi" },
                    { 616, 28, "Çınardere Mahallesi" },
                    { 617, 28, "Doğu Mahallesi" },
                    { 618, 28, "Dumlupınar Mahallesi" },
                    { 619, 28, "Emirli Mahallesi" },
                    { 620, 28, "Ertuğrulgazi Mahallesi" },
                    { 621, 28, "Esenler Mahallesi" },
                    { 622, 28, "Esenyalı Mahallesi" },
                    { 623, 28, "Fatih Mahallesi" },
                    { 624, 28, "Fevzi Çakmak Mahallesi" },
                    { 625, 28, "Göçbeyli Mahallesi" },
                    { 626, 28, "Güllübağlar Mahallesi" },
                    { 627, 28, "Güzelyalı Mahallesi" },
                    { 628, 28, "Harmandere Mahallesi" },
                    { 629, 28, "Kavakpınar Mahallesi" },
                    { 630, 28, "Kaynarca Mahallesi" },
                    { 631, 28, "Kurtdoğmuş Mahallesi" },
                    { 632, 28, "Kurtköy Mahallesi" },
                    { 633, 28, "Orhangazi Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 634, 28, "Orta Mahallesi" },
                    { 635, 28, "Ramazanoğlu Mahallesi" },
                    { 636, 28, "Sanayi Mahallesi" },
                    { 637, 28, "Sapanbağları Mahallesi" },
                    { 638, 28, "Sülüntepe Mahallesi" },
                    { 639, 28, "Şeyhli Mahallesi" },
                    { 640, 28, "Velibaba Mahallesi" },
                    { 641, 28, "Yayalar Mahallesi" },
                    { 642, 28, "Yeni Mahallesi" },
                    { 643, 28, "Yenişehir Mahallesi" },
                    { 644, 28, "Yeşilbağlar Mahallesi" },
                    { 645, 29, "Abdurrahmangazi Mahallesi" },
                    { 646, 29, "Akpınar Mahallesi" },
                    { 647, 29, "Atatürk Mahallesi" },
                    { 648, 29, "Emek Mahallesi" },
                    { 649, 29, "Eyüp Sultan Mahallesi" },
                    { 650, 29, "Fatih Mahallesi" },
                    { 651, 29, "Hilal Mahallesi" },
                    { 652, 29, "İnönü Mahallesi" },
                    { 653, 29, "Kemal Türkler Mahallesi" },
                    { 654, 29, "Meclis Mahallesi" },
                    { 655, 29, "Merve Mahallesi" },
                    { 656, 29, "Mevlana Mahallesi" },
                    { 657, 29, "Osmangazi Mahallesi" },
                    { 658, 29, "Paşaköy Mahallesi" },
                    { 659, 29, "Safa Mahallesi" },
                    { 660, 29, "Sarıgazi Mahallesi" },
                    { 661, 29, "Veysel Karani Mahallesi" },
                    { 662, 29, "Yenidoğan Mahallesi" },
                    { 663, 29, "Yunus Emre Mahallesi" },
                    { 664, 30, "Darüşşafaka Mahallesi" },
                    { 665, 30, "Ayazağa Mahallesi" },
                    { 666, 30, "Baltalimanı Mahallesi" },
                    { 667, 30, "Büyükdere Mahallesi" },
                    { 668, 30, "Cumhuriyet Mahallesi" },
                    { 669, 30, "Çamlıtepe (Derbent) Mahallesi" },
                    { 670, 30, "Çayırbaşı Mahallesi" },
                    { 671, 30, "Demirciköy Mahallesi" },
                    { 672, 30, "Emirgan Mahallesi" },
                    { 673, 30, "Fatih Sultan Mehmet Mahallesi" },
                    { 674, 30, "Ferahevler Mahallesi" },
                    { 675, 30, "Garipçe Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 676, 30, "Gümüşdere Mahallesi" },
                    { 677, 30, "Huzur Mahallesi" },
                    { 678, 30, "İstinye Mahallesi" },
                    { 679, 30, "Kazım Karabekir Paşa Mahallesi" },
                    { 680, 30, "Kemer (Bahçeköy) Mahallesi" },
                    { 681, 30, "Kısırkaya Mahallesi" },
                    { 682, 30, "Kilyos Mahallesi" },
                    { 683, 30, "Kireçburnu Mahallesi" },
                    { 684, 30, "Kocataş Mahallesi" },
                    { 685, 30, "Maden Mahallesi" },
                    { 686, 30, "Merkez Bahçeköy Mahallesi" },
                    { 687, 30, "Maslak Mahallesi" },
                    { 688, 30, "Pınar Mahallesi" },
                    { 689, 30, "P.T.T Evleri Mahallesi" },
                    { 690, 30, "Poligon Mahallesi" },
                    { 691, 30, "Reşitpaşa Mahallesi" },
                    { 692, 30, "Rumelifeneri Mahallesi" },
                    { 693, 30, "Rumelihisarı Mahallesi" },
                    { 694, 30, "Rumelikavağı Mahallesi" },
                    { 695, 30, "Sarıyer Merkez Mahallesi" },
                    { 696, 30, "Tarabya Mahallesi" },
                    { 697, 30, "Uskumruköy Mahallesi" },
                    { 698, 30, "Yeni (Bahçeköy) Mahallesi" },
                    { 699, 30, "Yeni (Sarıyer) Mahallesi" },
                    { 700, 30, "Yeniköy Mahallesi" },
                    { 701, 30, "Zekeriyaköy Mahallesi" },
                    { 702, 31, "Sayalar Mahallesi" },
                    { 703, 31, "Akören Mahallesi" },
                    { 704, 31, "Alipaşa Mahallesi" },
                    { 705, 31, "Alibey Mahallesi" },
                    { 706, 31, "B. Çavuşlu Mahallesi" },
                    { 707, 31, "Bekirli Mahallesi" },
                    { 708, 31, "Beyciler Mahallesi" },
                    { 709, 31, "B. Kılıçlı Mahallesi" },
                    { 710, 31, "B. Sinekli Mahallesi" },
                    { 711, 31, "Cumhuriyet Mahallesi" },
                    { 712, 31, "Çanta Balaban Mahallesi" },
                    { 713, 31, "Çanta Sancaktepe Mahallesi" },
                    { 714, 31, "Çayırdere Mahallesi" },
                    { 715, 31, "Çeltik Mahallesi" },
                    { 716, 31, "Danamandıra Mahallesi" },
                    { 717, 31, "Değirmenköy İsmetpaşa Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 718, 31, "Değirmenköy Fevzipaşa Mahallesi" },
                    { 719, 31, "Fatih Mahallesi" },
                    { 720, 31, "Fener Mahallesi" },
                    { 721, 31, "Gazitepe Mahallesi" },
                    { 722, 31, "Gümüşyaka Mahallesi" },
                    { 723, 31, "Kadıköy Mahallesi" },
                    { 724, 31, "Kavaklı Hürriyet Mahallesi" },
                    { 725, 31, "Kavaklı Mahallesi" },
                    { 726, 31, "K Sinekli Mahallesi" },
                    { 727, 31, "Kurfallı Mahallesi" },
                    { 728, 31, "K. Kılıçlı Mahallesi" },
                    { 729, 31, "Mimarsinan Mahallesi" },
                    { 730, 31, "Ortaköy Mahallesi" },
                    { 731, 31, "Piri Mehmet Paşa Mahallesi" },
                    { 732, 31, "Semizkumlar Mahallesi" },
                    { 733, 31, "Selimpaşa Mahallesi" },
                    { 734, 31, "Seymen Mahallesi" },
                    { 735, 31, "Yeni Mahallesi" },
                    { 736, 31, "Yolçatı Mahallesi" },
                    { 737, 32, "Hasanpaşa Mahallesi" },
                    { 738, 32, "Abdurrahmangazi Mahallesi" },
                    { 739, 32, "Adil Mahallesi" },
                    { 740, 32, "Ahmet Yesevi Mahallesi" },
                    { 741, 32, "Akşemsettin Mahallesi" },
                    { 742, 32, "Battalgazi Mahallesi" },
                    { 743, 32, "Fatih Mahallesi" },
                    { 744, 32, "Hamidiye Mahallesi" },
                    { 745, 32, "Mecidiye Mahallesi" },
                    { 746, 32, "Mehmet Akif Mahallesi" },
                    { 747, 32, "Mimar Sinan Mahallesi" },
                    { 748, 32, "Necip Fazıl Mahallesi" },
                    { 749, 32, "Orhangazi Mahallesi" },
                    { 750, 32, "Turgutreis Mahallesi" },
                    { 751, 32, "Yavuz Selim Mahallesi" },
                    { 752, 33, "Esentepe Mahallesi" },
                    { 753, 33, "50.Yıl Mahallesi" },
                    { 754, 33, "75.yıl Mahallesi" },
                    { 755, 33, "Cebeci Mahallesi" },
                    { 756, 33, "Cumhuriyet Mahallesi" },
                    { 757, 33, "Eski Habibler Mahallesi" },
                    { 758, 33, "Gazi Mahallesi" },
                    { 759, 33, "Habibler Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 760, 33, "İsmetpaşa Mahallesi" },
                    { 761, 33, "Malkoçoğlu Mahallesi" },
                    { 762, 33, "Sultançiftliği Mahallesi" },
                    { 763, 33, "Uğurmumcu Mahallesi" },
                    { 764, 33, "Yayla Mahallesi" },
                    { 765, 33, "Yunusemre Mahallesi" },
                    { 766, 33, "Zübeyde Hanım Mahallesi" },
                    { 767, 34, "Kabakoz Mahallesi" },
                    { 768, 34, "Ağaçdere Mahallesi" },
                    { 769, 34, "Ağva Mahallesi" },
                    { 770, 34, "Ahmetli Mahallesi" },
                    { 771, 34, "Akçakese Mahallesi" },
                    { 772, 34, "Alacalı Mahallesi" },
                    { 773, 34, "Avcıkoru Mahallesi" },
                    { 774, 34, "Balibey Mahallesi" },
                    { 775, 34, "Bıçkıdere Mahallesi" },
                    { 776, 34, "Bozgoca Mahallesi" },
                    { 777, 34, "Bucaklı Mahallesi" },
                    { 778, 34, "Çataklı Mahallesi" },
                    { 779, 34, "Çavuş Mahallesi" },
                    { 780, 34, "Çayırbaşı Mahallesi" },
                    { 781, 34, "Çelebi Mahallesi" },
                    { 782, 34, "Çengilli Mahallesi" },
                    { 783, 34, "Darlık Mahallesi" },
                    { 784, 34, "Değirmençayırı Mahallesi" },
                    { 785, 34, "Doğancılı Mahallesi" },
                    { 786, 34, "Erenler Mahallesi" },
                    { 787, 34, "Esenceli Mahallesi" },
                    { 788, 34, "Geredeli Mahallesi" },
                    { 789, 34, "Göçe Mahallesi" },
                    { 790, 34, "Gökmaslı Mahallesi" },
                    { 791, 34, "Göksu Mahallesi" },
                    { 792, 34, "Hacıkasım Mahallesi" },
                    { 793, 34, "Hacıllı Mahallesi" },
                    { 794, 34, "Hasanlı Mahallesi" },
                    { 795, 34, "İmrendere Mahallesi" },
                    { 796, 34, "İmrenli Mahallesi" },
                    { 797, 34, "İsaköy Mahallesi" },
                    { 798, 34, "Kadıköy Mahallesi" },
                    { 799, 34, "Kalemköy Mahallesi" },
                    { 800, 34, "Karabeyli Mahallesi" },
                    { 801, 34, "Karacaköy Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 802, 34, "Karamandere Mahallesi" },
                    { 803, 34, "Karakiraz Mahallesi" },
                    { 804, 34, "Kervansaray Mahallesi" },
                    { 805, 34, "Kızılcaköy Mahallesi" },
                    { 806, 34, "Korucuköy Mahallesi" },
                    { 807, 34, "Kumbaba Mahallesi" },
                    { 808, 34, "Kurna Mahallesi" },
                    { 809, 34, "Kurfallı Mahallesi" },
                    { 810, 34, "Kömürlük Mahallesi" },
                    { 811, 34, "Meşrutiyet Mahallesi" },
                    { 812, 34, "Oruçoğlu Mahallesi" },
                    { 813, 34, "Osmanköy Mahallesi" },
                    { 814, 34, "Ovacık Mahallesi" },
                    { 815, 34, "Sahilköy Mahallesi" },
                    { 816, 34, "Satmazlı Mahallesi" },
                    { 817, 34, "Sofular Mahallesi" },
                    { 818, 34, "Soğullu Mahallesi" },
                    { 819, 34, "Sortullu Mahallesi" },
                    { 820, 34, "Şuayipli Mahallesi" },
                    { 821, 34, "Teke Mahallesi" },
                    { 822, 34, "Ulupelit Mahallesi" },
                    { 823, 34, "Üvezli Mahallesi" },
                    { 824, 34, "Yaka Mahallesi" },
                    { 825, 34, "Yaylalı Mahallesi" },
                    { 826, 34, "Yazımanayır Mahallesi" },
                    { 827, 34, "Yeniköy Mahallesi" },
                    { 828, 34, "Yeşilvadi Mahallesi" },
                    { 829, 35, "19 Mayıs Mahallesi" },
                    { 830, 35, "Bozkurt Mahallesi" },
                    { 831, 35, "Cumhuriyet Mahallesi" },
                    { 832, 35, "Duatepe Mahallesi" },
                    { 833, 35, "Ergenekon Mahallesi" },
                    { 834, 35, "Esentepe Mahallesi" },
                    { 835, 35, "Eskişehir Mahallesi" },
                    { 836, 35, "Feriköy Mahallesi" },
                    { 837, 35, "Fulya Mahallesi" },
                    { 838, 35, "Gülbahar Mahallesi" },
                    { 839, 35, "Halaskargazi Mahallesi" },
                    { 840, 35, "Halide Edip Adıvar Mahallesi" },
                    { 841, 35, "Halil Rıfat Paşa Mahallesi" },
                    { 842, 35, "Harbiye Mahallesi" },
                    { 843, 35, "İnönü Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 844, 35, "İzzetpaşa Mahallesi" },
                    { 845, 35, "Kaptanpaşa Mahallesi" },
                    { 846, 35, "Kuştepe Mahallesi" },
                    { 847, 35, "M.Şevket Paşa Mahallesi" },
                    { 848, 35, "Mecidiyeköy Mahallesi" },
                    { 849, 35, "Merkez Mahallesi" },
                    { 850, 35, "Meşrutiyet Mahallesi" },
                    { 851, 35, "Paşa Mahallesi" },
                    { 852, 35, "Teşvikiye Mahallesi" },
                    { 853, 35, "Yayla Mahallesi" },
                    { 854, 36, "Evliya Çelebi Mahallesi" },
                    { 855, 36, "Akfırat Mahallesi" },
                    { 856, 36, "Anadolu Mahallesi" },
                    { 857, 36, "Aydınlı Mahallesi" },
                    { 858, 36, "Aydıntepe Mahallesi" },
                    { 859, 36, "Cami Mahallesi" },
                    { 860, 36, "Fatih Mahallesi" },
                    { 861, 36, "İçmeler Mahallesi" },
                    { 862, 36, "İstasyon Mahallesi" },
                    { 863, 36, "Mescit Mahallesi" },
                    { 864, 36, "Mimar Sinan Mahallesi" },
                    { 865, 36, "Orhanlı Mahallesi" },
                    { 866, 36, "Orta Mahallesi" },
                    { 867, 36, "Postane Mahallesi" },
                    { 868, 36, "Şifa Mahallesi" },
                    { 869, 36, "Tepeören Mahallesi" },
                    { 870, 36, "Yayla Mahallesi" },
                    { 871, 37, "Necip Fazıl Mahallesi" },
                    { 872, 37, "Topağacı Mahallesi" },
                    { 873, 37, "Adem Yavuz Mahallesi" },
                    { 874, 37, "Altınşehir Mahallesi" },
                    { 875, 37, "Armağanevler Mahallesi" },
                    { 876, 37, "Aşağı Dudullu Mahallesi" },
                    { 877, 37, "Atakent Mahallesi" },
                    { 878, 37, "Atatürk Mahallesi" },
                    { 879, 37, "Cemil Meriç Mahallesi" },
                    { 880, 37, "Çakmak Mahallesi" },
                    { 881, 37, "Çamlık Mahallesi" },
                    { 882, 37, "Dumlupınar Mahallesi" },
                    { 883, 37, "Elmalıkent Mahallesi" },
                    { 884, 37, "Esenevler Mahallesi" },
                    { 885, 37, "Esenkent Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 886, 37, "Esenşehir Mahallesi" },
                    { 887, 37, "Fatih Sultan Mehmet Mahallesi" },
                    { 888, 37, "Finanskent Mahallesi" },
                    { 889, 37, "Hekimbaşı Mahallesi" },
                    { 890, 37, "Huzur Mahallesi" },
                    { 891, 37, "Ihlamurkuyu Mahallesi" },
                    { 892, 37, "İnkilap Mahallesi" },
                    { 893, 37, "İstiklal Mahallesi" },
                    { 894, 37, "Kazım Karabekir Mahallesi" },
                    { 895, 37, "Madenler Mahallesi" },
                    { 896, 37, "Mehmet Akif Mahallesi" },
                    { 897, 37, "Namık Kemal Mahallesi" },
                    { 898, 37, "Parseller Mahallesi" },
                    { 899, 37, "Saray Mahallesi" },
                    { 900, 37, "Site Mahallesi" },
                    { 901, 37, "Şerifali Mahallesi" },
                    { 902, 37, "Tantavi Mahallesi" },
                    { 903, 37, "Tatlısu Mahallesi" },
                    { 904, 37, "Tepeüstü Mahallesi" },
                    { 905, 37, "Yamanevler Mahallesi" },
                    { 906, 37, "Yenişehir Mahallesi" },
                    { 907, 37, "Yukarı Dudullu Mahallesi" },
                    { 908, 38, "Valide_i Atik Mahallesi" },
                    { 909, 38, "Acıbadem Mahallesi" },
                    { 910, 38, "Ahmediye Mahallesi" },
                    { 911, 38, "Altunizade Mahallesi" },
                    { 912, 38, "Aziz Mahmut Hüdayi Mahallesi" },
                    { 913, 38, "Bahçelievler Mahallesi" },
                    { 914, 38, "Barbaros Mahallesi" },
                    { 915, 38, "Beylerbeyi Mahallesi" },
                    { 916, 38, "Bulgurlu Mahallesi" },
                    { 917, 38, "Burhaniye Mahallesi" },
                    { 918, 38, "Cumhuriyet Mahallesi" },
                    { 919, 38, "Çengelköy Mahallesi" },
                    { 920, 38, "Ferah Mahallesi" },
                    { 921, 38, "Güzeltepe Mahallesi" },
                    { 922, 38, "İcadiye Mahallesi" },
                    { 923, 38, "Kandilli Mahallesi" },
                    { 924, 38, "Kısıklı Mahallesi" },
                    { 925, 38, "Kirazlıtepe Mahallesi" },
                    { 926, 38, "Kuleli Mahallesi" },
                    { 927, 38, "Kuzguncuk Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Neighbourhood",
                columns: new[] { "Id", "DistrictId", "NeighbourhoodName" },
                values: new object[,]
                {
                    { 928, 38, "Küçük Çamlıca Mahallesi" },
                    { 929, 38, "Küçüksu Mahallesi" },
                    { 930, 38, "Küplüce Mahallesi" },
                    { 931, 38, "M.Akif Ersoy Mahallesi" },
                    { 932, 38, "Mimar Sinan Mahallesi" },
                    { 933, 38, "Muratreis Mahallesi" },
                    { 934, 38, "Salacak Mahallesi" },
                    { 935, 38, "Selamiali Mahallesi" },
                    { 936, 38, "Selimiye Mahallesi" },
                    { 937, 38, "Sultantepe Mahallesi" },
                    { 938, 38, "Ünalan mahallesi" },
                    { 939, 38, "Yavuztürk Mahallesi" },
                    { 940, 38, "Zeynep Kamil Mahallesi" },
                    { 941, 39, "Yeşiltepe Mahallesi" },
                    { 942, 39, "Beştelsiz Mahallesi" },
                    { 943, 39, "Çırpıcı Mahallesi" },
                    { 944, 39, "Gökalp Mahallesi" },
                    { 945, 39, "Kazlıçeşme Mahallesi" },
                    { 946, 39, "Maltepe Mahallesi" },
                    { 947, 39, "Merkezefendi Mahallesi" },
                    { 948, 39, "Nuripaşa Mahallesi" },
                    { 949, 39, "Seyitnizam Mahallesi" },
                    { 950, 39, "Sümer Mahallesi" },
                    { 951, 39, "Telsiz Mahallesi" },
                    { 952, 39, "Veliefendi Mahallesi" },
                    { 953, 39, "Yenidoğan Mahallesi" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNumber", "BuildingNo", "CountryId", "Description", "DistrictId", "Floor", "NeighbourhoodId", "ProvinceId", "Street", "Title" },
                values: new object[,]
                {
                    { 1, "3", "40", 1, "Test Açıklama", 1, 2, 1, 1, "Garanti Caddesi", "Ev" },
                    { 2, "10", "20", 1, "Test Açıklama", 1, 5, 1, 1, "Gazeteci Sokak", "Ev" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BranchId", "EmployeesTypeId", "Name", "NumberPhone", "Password", "Surname", "TcNo" },
                values: new object[,]
                {
                    { 1, 14, 1, "Name", "05417434511", "Password", "Surname", "99999999999" },
                    { 2, 19, 2, "Surname", "05417434510", "Password1", "Name", "99999999998" }
                });

            migrationBuilder.InsertData(
                table: "Receiver",
                columns: new[] { "Id", "ApartmentNumber", "BuildingNo", "CountryId", "CustomerId", "CustomerMobilId", "Description", "DistrictId", "Email", "Floor", "IsInActive", "IsInActiveDate", "NameSurname", "NeighbourhoodId", "NumberPhone", "ProvinceId", "Street", "Title" },
                values: new object[] { 1, "9", "42", 1, null, 1, "Test Açıklama", 1, "Test@gmail.com", 1, false, null, "Mehmet Sakip", 1, "0364106788", 1, "Garanti", "Mehmet Ev" });

            migrationBuilder.InsertData(
                table: "CallCourier",
                columns: new[] { "Id", "CallCourierOk", "CargoDesi", "CargoParcelTypeID", "CargoRealeseDate", "CargoTransportationConditionsId", "CargoTypeId", "CustomerMobilAdressId", "CustomerMobilId", "PaymentTypeId", "Price", "ReceiverId" },
                values: new object[] { 1, false, 1.24, 1, new DateTimeOffset(new DateTime(2024, 4, 9, 22, 13, 20, 607, DateTimeKind.Unspecified).AddTicks(7574), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, 2, 1, 1, 40.0, 1 });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "CargoArrivalBranchId", "CargoDeliveryDate", "CargoDepartureBranchId", "CargoDesi", "CargoEstimatedDeliveryDate", "CargoParcelTypeId", "CargoReleaseDate", "CargoStatusId", "CargoTrackingNo", "CargoTransportationConditionsId", "CargoTypeId", "CustomerId", "CustomerMobilAdressId", "CustomerMobilId", "PaymentTypeId", "Price", "ReceiverId" },
                values: new object[] { 1, 2, new DateTimeOffset(new DateTime(2024, 4, 13, 1, 13, 20, 608, DateTimeKind.Unspecified).AddTicks(820), new TimeSpan(0, 3, 0, 0, 0)), 1, 19.0, new DateTimeOffset(new DateTime(2024, 4, 15, 1, 13, 20, 608, DateTimeKind.Unspecified).AddTicks(830), new TimeSpan(0, 3, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 3, 0, 0, 0)), 1, "KT10100100", 1, 1, null, 1, 1, 1, 122.0, 1 });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "Id", "AddressId", "BranchId", "CustomerId", "CustomerMobilId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null },
                    { 2, 2, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CargoMovement",
                columns: new[] { "Id", "BranchId", "CallCourierId", "CargoId", "CargoStatusId", "Date" },
                values: new object[] { 1, 1, 1, null, 7, new DateTimeOffset(new DateTime(2024, 4, 10, 1, 13, 20, 608, DateTimeKind.Unspecified).AddTicks(1035), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighbourhoodId",
                table: "Addresses",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses",
                column: "ProvinceId");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DistrictId",
                table: "Branch",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_CargoParcelTypeID",
                table: "CallCourier",
                column: "CargoParcelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_CargoTransportationConditionsId",
                table: "CallCourier",
                column: "CargoTransportationConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_CargoTypeId",
                table: "CallCourier",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_CustomerMobilId",
                table: "CallCourier",
                column: "CustomerMobilId");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_PaymentTypeId",
                table: "CallCourier",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CallCourier_ReceiverId",
                table: "CallCourier",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoArrivalBranchId",
                table: "Cargo",
                column: "CargoArrivalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoDepartureBranchId",
                table: "Cargo",
                column: "CargoDepartureBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoParcelTypeId",
                table: "Cargo",
                column: "CargoParcelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoStatusId",
                table: "Cargo",
                column: "CargoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoTransportationConditionsId",
                table: "Cargo",
                column: "CargoTransportationConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoTypeId",
                table: "Cargo",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CustomerId",
                table: "Cargo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CustomerMobilId",
                table: "Cargo",
                column: "CustomerMobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_PaymentTypeId",
                table: "Cargo",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_ReceiverId",
                table: "Cargo",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoMovement_BranchId",
                table: "CargoMovement",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoMovement_CallCourierId",
                table: "CargoMovement",
                column: "CallCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoMovement_CargoId",
                table: "CargoMovement",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoMovement_CargoStatusId",
                table: "CargoMovement",
                column: "CargoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressId",
                table: "CustomerAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_BranchId",
                table: "CustomerAddress",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerMobilId",
                table: "CustomerAddress",
                column: "CustomerMobilId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeesTypeId",
                table: "Employees",
                column: "EmployeesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighbourhood_DistrictId",
                table: "Neighbourhood",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                table: "Province",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_CountryId",
                table: "Receiver",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_CustomerId",
                table: "Receiver",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_CustomerMobilId",
                table: "Receiver",
                column: "CustomerMobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_DistrictId",
                table: "Receiver",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_NeighbourhoodId",
                table: "Receiver",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_ProvinceId",
                table: "Receiver",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CargoMovement");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CallCourier");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "EmployeesType");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "CargoParcelType");

            migrationBuilder.DropTable(
                name: "CargoStatus");

            migrationBuilder.DropTable(
                name: "CargoTransportationConditions");

            migrationBuilder.DropTable(
                name: "CargoType");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Receiver");

            migrationBuilder.DropTable(
                name: "CustomerMobil");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Neighbourhood");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
