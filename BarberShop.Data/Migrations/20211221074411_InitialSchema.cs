using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop.Data.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PublicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barbers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true),
                    PurchaseStatus = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b534670c-d8ba-4b67-9cdf-5716bc511a1c", null, false, false, null, "Kobak Károly", null, null, null, null, false, "barberImages/1.jpg", null, false, null },
                    { 2, 0, "bed56fed-e9e5-45e6-b112-acff7a311242", null, false, false, null, "Bajusz Béla", null, null, null, null, false, "barberImages/2.jpg", null, false, null },
                    { 3, 0, "4d1e554c-d4d3-4844-8efb-ddcf1620f13b", null, false, false, null, "Szakáll Sándor", null, null, null, null, false, "barberImages/3.jpg", null, false, null },
                    { 4, 0, "1ab01094-e7a3-44d2-a018-4944e2e16db4", null, false, false, null, "Borbély Bertalan", null, null, null, null, false, "barberImages/4.jpg", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Comment", "DateOfCreation", "DateOfUpdate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hajvágás", 5000.0 },
                    { 2, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gyermek hajvágás", 4000.0 },
                    { 3, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borbély élmény", 7000.0 },
                    { 4, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borotválás", 3000.0 },
                    { 5, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Szakállvágás", 3000.0 }
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "IsDeleted", "PublicDescription" },
                values: new object[,]
                {
                    { 1, false, "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 2, false, "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 3, false, "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 4, false, "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppUserId",
                table: "Appointments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Date_BarberId",
                table: "Appointments",
                columns: new[] { "Date", "BarberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId");

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
                name: "IX_ServiceTypes_Name",
                table: "ServiceTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

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
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
