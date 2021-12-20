using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarberShop.Data.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
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
                table: "Barbers",
                columns: new[] { "Id", "Comment", "DateOfCreation", "DateOfUpdate", "Email", "IsDeleted", "Name", "PhotoPath", "PublicDescription" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kobakkaroly@gmail.com", false, "Kobak Károly", "doctorImages/1.jpg", "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 2, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bajuszbela@gmail.com", false, "Bajusz Béla", "doctorImages/2.jpg", "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 3, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "szakallsandor@gmail.com", false, "Szakáll Sándor", "doctorImages/3.jpg", "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." },
                    { 4, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "borbelybertalan@gmail.com", false, "Borbély Bertalan", "doctorImages/4.jpg", "Duis ac sapien laoreet, gravida justo vel, posuere leo. Curabitur mi diam, interdum vel neque in, consequat suscipit ex. Morbi porta sagittis nunc, a dictum tortor viverra et. Mauris egestas at dui in ultrices. Suspendisse tempor imperdiet justo, eget maximus nibh vulputate nec. Quisque vel urna sed ipsum venenatis facilisis. Nam rutrum, augue id rhoncus fermentum, lorem quam suscipit orci, nec lobortis lacus velit a justo. Suspendisse commodo lacus nec sagittis efficitur. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dictum aliquet sapien. Nulla id pellentesque nisi. Aliquam viverra, est vel auctor pretium, mauris magna rhoncus nisl, vel dictum arcu velit non dui. Nullam dignissim elit quis lectus aliquam, nec aliquam est molestie. Donec aliquet sed mauris in molestie. Phasellus vitae elit vel mi interdum viverra. Integer vel leo tempus, aliquam enim a, hendrerit ipsum. Pellentesque finibus libero libero, volutpat ullamcorper dui facilisis at. Praesent sit amet lacus mollis, egestas dolor nec, porta est. Integer dapibus ex ipsum, eu semper massa maximus sed. Aenean sodales, nulla ac semper blandit, quam diam dignissim nisi, lobortis posuere ipsum diam vitae justo. Ut fringilla elementum orci at faucibus. Nullam posuere porta purus, eu aliquet felis aliquam volutpat. Phasellus turpis libero, lobortis sit amet diam eget, tempor varius libero. Quisque cursus ullamcorper laoreet." }
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
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, null, 1, null, new DateTime(2021, 12, 20, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 351, null, 3, null, new DateTime(2021, 12, 24, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 347, null, 3, null, new DateTime(2021, 12, 24, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 343, null, 3, null, new DateTime(2021, 12, 24, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 339, null, 3, null, new DateTime(2021, 12, 24, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 335, null, 3, null, new DateTime(2021, 12, 24, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 331, null, 3, null, new DateTime(2021, 12, 24, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 327, null, 3, null, new DateTime(2021, 12, 24, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 323, null, 3, null, new DateTime(2021, 12, 24, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 319, null, 3, null, new DateTime(2021, 12, 23, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 315, null, 3, null, new DateTime(2021, 12, 23, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 311, null, 3, null, new DateTime(2021, 12, 23, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 307, null, 3, null, new DateTime(2021, 12, 23, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 355, null, 3, null, new DateTime(2021, 12, 24, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 303, null, 3, null, new DateTime(2021, 12, 23, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 295, null, 3, null, new DateTime(2021, 12, 23, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 291, null, 3, null, new DateTime(2021, 12, 23, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 287, null, 3, null, new DateTime(2021, 12, 23, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 283, null, 3, null, new DateTime(2021, 12, 23, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 279, null, 3, null, new DateTime(2021, 12, 23, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 275, null, 3, null, new DateTime(2021, 12, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 271, null, 3, null, new DateTime(2021, 12, 23, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 267, null, 3, null, new DateTime(2021, 12, 23, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 263, null, 3, null, new DateTime(2021, 12, 23, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 259, null, 3, null, new DateTime(2021, 12, 23, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 255, null, 3, null, new DateTime(2021, 12, 23, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 251, null, 3, null, new DateTime(2021, 12, 23, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 299, null, 3, null, new DateTime(2021, 12, 23, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 247, null, 3, null, new DateTime(2021, 12, 23, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 359, null, 3, null, new DateTime(2021, 12, 24, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 367, null, 3, null, new DateTime(2021, 12, 24, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 471, null, 3, null, new DateTime(2021, 12, 25, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 467, null, 3, null, new DateTime(2021, 12, 25, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 463, null, 3, null, new DateTime(2021, 12, 25, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 459, null, 3, null, new DateTime(2021, 12, 25, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 455, null, 3, null, new DateTime(2021, 12, 25, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 451, null, 3, null, new DateTime(2021, 12, 25, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 447, null, 3, null, new DateTime(2021, 12, 25, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 443, null, 3, null, new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 439, null, 3, null, new DateTime(2021, 12, 25, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 435, null, 3, null, new DateTime(2021, 12, 25, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 431, null, 3, null, new DateTime(2021, 12, 25, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 427, null, 3, null, new DateTime(2021, 12, 25, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 363, null, 3, null, new DateTime(2021, 12, 24, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 423, null, 3, null, new DateTime(2021, 12, 25, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 415, null, 3, null, new DateTime(2021, 12, 25, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 411, null, 3, null, new DateTime(2021, 12, 25, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 407, null, 3, null, new DateTime(2021, 12, 25, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 403, null, 3, null, new DateTime(2021, 12, 25, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 399, null, 3, null, new DateTime(2021, 12, 24, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 395, null, 3, null, new DateTime(2021, 12, 24, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 391, null, 3, null, new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 387, null, 3, null, new DateTime(2021, 12, 24, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 383, null, 3, null, new DateTime(2021, 12, 24, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 379, null, 3, null, new DateTime(2021, 12, 24, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 375, null, 3, null, new DateTime(2021, 12, 24, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 371, null, 3, null, new DateTime(2021, 12, 24, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 419, null, 3, null, new DateTime(2021, 12, 25, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 475, null, 3, null, new DateTime(2021, 12, 25, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 243, null, 3, null, new DateTime(2021, 12, 23, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 235, null, 3, null, new DateTime(2021, 12, 22, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 111, null, 3, null, new DateTime(2021, 12, 21, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 107, null, 3, null, new DateTime(2021, 12, 21, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 103, null, 3, null, new DateTime(2021, 12, 21, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 99, null, 3, null, new DateTime(2021, 12, 21, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 95, null, 3, null, new DateTime(2021, 12, 21, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 91, null, 3, null, new DateTime(2021, 12, 21, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 87, null, 3, null, new DateTime(2021, 12, 21, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 83, null, 3, null, new DateTime(2021, 12, 21, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 79, null, 3, null, new DateTime(2021, 12, 20, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 75, null, 3, null, new DateTime(2021, 12, 20, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 71, null, 3, null, new DateTime(2021, 12, 20, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 67, null, 3, null, new DateTime(2021, 12, 20, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 115, null, 3, null, new DateTime(2021, 12, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 63, null, 3, null, new DateTime(2021, 12, 20, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 55, null, 3, null, new DateTime(2021, 12, 20, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 51, null, 3, null, new DateTime(2021, 12, 20, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 47, null, 3, null, new DateTime(2021, 12, 20, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 43, null, 3, null, new DateTime(2021, 12, 20, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 39, null, 3, null, new DateTime(2021, 12, 20, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 35, null, 3, null, new DateTime(2021, 12, 20, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 31, null, 3, null, new DateTime(2021, 12, 20, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 27, null, 3, null, new DateTime(2021, 12, 20, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 23, null, 3, null, new DateTime(2021, 12, 20, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 19, null, 3, null, new DateTime(2021, 12, 20, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 15, null, 3, null, new DateTime(2021, 12, 20, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 11, null, 3, null, new DateTime(2021, 12, 20, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 59, null, 3, null, new DateTime(2021, 12, 20, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 239, null, 3, null, new DateTime(2021, 12, 22, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 119, null, 3, null, new DateTime(2021, 12, 21, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 127, null, 3, null, new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 231, null, 3, null, new DateTime(2021, 12, 22, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 227, null, 3, null, new DateTime(2021, 12, 22, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 223, null, 3, null, new DateTime(2021, 12, 22, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 219, null, 3, null, new DateTime(2021, 12, 22, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 215, null, 3, null, new DateTime(2021, 12, 22, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 211, null, 3, null, new DateTime(2021, 12, 22, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 207, null, 3, null, new DateTime(2021, 12, 22, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 203, null, 3, null, new DateTime(2021, 12, 22, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 199, null, 3, null, new DateTime(2021, 12, 22, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 195, null, 3, null, new DateTime(2021, 12, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 191, null, 3, null, new DateTime(2021, 12, 22, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 187, null, 3, null, new DateTime(2021, 12, 22, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 123, null, 3, null, new DateTime(2021, 12, 21, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 183, null, 3, null, new DateTime(2021, 12, 22, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 175, null, 3, null, new DateTime(2021, 12, 22, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 171, null, 3, null, new DateTime(2021, 12, 22, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 167, null, 3, null, new DateTime(2021, 12, 22, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 163, null, 3, null, new DateTime(2021, 12, 22, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 159, null, 3, null, new DateTime(2021, 12, 21, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 155, null, 3, null, new DateTime(2021, 12, 21, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 151, null, 3, null, new DateTime(2021, 12, 21, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 147, null, 3, null, new DateTime(2021, 12, 21, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 143, null, 3, null, new DateTime(2021, 12, 21, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 139, null, 3, null, new DateTime(2021, 12, 21, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 135, null, 3, null, new DateTime(2021, 12, 21, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 131, null, 3, null, new DateTime(2021, 12, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 179, null, 3, null, new DateTime(2021, 12, 22, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 7, null, 3, null, new DateTime(2021, 12, 20, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 479, null, 3, null, new DateTime(2021, 12, 25, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 8, null, 4, null, new DateTime(2021, 12, 20, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 352, null, 4, null, new DateTime(2021, 12, 24, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 348, null, 4, null, new DateTime(2021, 12, 24, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 344, null, 4, null, new DateTime(2021, 12, 24, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 340, null, 4, null, new DateTime(2021, 12, 24, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 336, null, 4, null, new DateTime(2021, 12, 24, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 332, null, 4, null, new DateTime(2021, 12, 24, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 328, null, 4, null, new DateTime(2021, 12, 24, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 324, null, 4, null, new DateTime(2021, 12, 24, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 320, null, 4, null, new DateTime(2021, 12, 23, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 316, null, 4, null, new DateTime(2021, 12, 23, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 312, null, 4, null, new DateTime(2021, 12, 23, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 308, null, 4, null, new DateTime(2021, 12, 23, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 356, null, 4, null, new DateTime(2021, 12, 24, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 304, null, 4, null, new DateTime(2021, 12, 23, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 296, null, 4, null, new DateTime(2021, 12, 23, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 292, null, 4, null, new DateTime(2021, 12, 23, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 288, null, 4, null, new DateTime(2021, 12, 23, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 284, null, 4, null, new DateTime(2021, 12, 23, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 280, null, 4, null, new DateTime(2021, 12, 23, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 276, null, 4, null, new DateTime(2021, 12, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 272, null, 4, null, new DateTime(2021, 12, 23, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 268, null, 4, null, new DateTime(2021, 12, 23, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 264, null, 4, null, new DateTime(2021, 12, 23, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 260, null, 4, null, new DateTime(2021, 12, 23, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 256, null, 4, null, new DateTime(2021, 12, 23, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 252, null, 4, null, new DateTime(2021, 12, 23, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 300, null, 4, null, new DateTime(2021, 12, 23, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 248, null, 4, null, new DateTime(2021, 12, 23, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 360, null, 4, null, new DateTime(2021, 12, 24, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 368, null, 4, null, new DateTime(2021, 12, 24, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 472, null, 4, null, new DateTime(2021, 12, 25, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 468, null, 4, null, new DateTime(2021, 12, 25, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 464, null, 4, null, new DateTime(2021, 12, 25, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 460, null, 4, null, new DateTime(2021, 12, 25, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 456, null, 4, null, new DateTime(2021, 12, 25, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 452, null, 4, null, new DateTime(2021, 12, 25, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 448, null, 4, null, new DateTime(2021, 12, 25, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 444, null, 4, null, new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 440, null, 4, null, new DateTime(2021, 12, 25, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 436, null, 4, null, new DateTime(2021, 12, 25, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 432, null, 4, null, new DateTime(2021, 12, 25, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 428, null, 4, null, new DateTime(2021, 12, 25, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 364, null, 4, null, new DateTime(2021, 12, 24, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 424, null, 4, null, new DateTime(2021, 12, 25, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 416, null, 4, null, new DateTime(2021, 12, 25, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 412, null, 4, null, new DateTime(2021, 12, 25, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 408, null, 4, null, new DateTime(2021, 12, 25, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 404, null, 4, null, new DateTime(2021, 12, 25, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 400, null, 4, null, new DateTime(2021, 12, 24, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 396, null, 4, null, new DateTime(2021, 12, 24, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 392, null, 4, null, new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 388, null, 4, null, new DateTime(2021, 12, 24, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 384, null, 4, null, new DateTime(2021, 12, 24, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 380, null, 4, null, new DateTime(2021, 12, 24, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 376, null, 4, null, new DateTime(2021, 12, 24, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 372, null, 4, null, new DateTime(2021, 12, 24, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 420, null, 4, null, new DateTime(2021, 12, 25, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4, null, 4, null, new DateTime(2021, 12, 20, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 244, null, 4, null, new DateTime(2021, 12, 23, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 236, null, 4, null, new DateTime(2021, 12, 22, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 112, null, 4, null, new DateTime(2021, 12, 21, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 108, null, 4, null, new DateTime(2021, 12, 21, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 104, null, 4, null, new DateTime(2021, 12, 21, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 100, null, 4, null, new DateTime(2021, 12, 21, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 96, null, 4, null, new DateTime(2021, 12, 21, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 92, null, 4, null, new DateTime(2021, 12, 21, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 88, null, 4, null, new DateTime(2021, 12, 21, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 84, null, 4, null, new DateTime(2021, 12, 21, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 80, null, 4, null, new DateTime(2021, 12, 20, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 76, null, 4, null, new DateTime(2021, 12, 20, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 72, null, 4, null, new DateTime(2021, 12, 20, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 68, null, 4, null, new DateTime(2021, 12, 20, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 116, null, 4, null, new DateTime(2021, 12, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 64, null, 4, null, new DateTime(2021, 12, 20, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 56, null, 4, null, new DateTime(2021, 12, 20, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 52, null, 4, null, new DateTime(2021, 12, 20, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 48, null, 4, null, new DateTime(2021, 12, 20, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 44, null, 4, null, new DateTime(2021, 12, 20, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 40, null, 4, null, new DateTime(2021, 12, 20, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 36, null, 4, null, new DateTime(2021, 12, 20, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 32, null, 4, null, new DateTime(2021, 12, 20, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 28, null, 4, null, new DateTime(2021, 12, 20, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 24, null, 4, null, new DateTime(2021, 12, 20, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 20, null, 4, null, new DateTime(2021, 12, 20, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 16, null, 4, null, new DateTime(2021, 12, 20, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 12, null, 4, null, new DateTime(2021, 12, 20, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 60, null, 4, null, new DateTime(2021, 12, 20, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 240, null, 4, null, new DateTime(2021, 12, 22, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 120, null, 4, null, new DateTime(2021, 12, 21, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 128, null, 4, null, new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 232, null, 4, null, new DateTime(2021, 12, 22, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 228, null, 4, null, new DateTime(2021, 12, 22, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 224, null, 4, null, new DateTime(2021, 12, 22, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 220, null, 4, null, new DateTime(2021, 12, 22, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 216, null, 4, null, new DateTime(2021, 12, 22, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 212, null, 4, null, new DateTime(2021, 12, 22, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 208, null, 4, null, new DateTime(2021, 12, 22, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 204, null, 4, null, new DateTime(2021, 12, 22, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 200, null, 4, null, new DateTime(2021, 12, 22, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 196, null, 4, null, new DateTime(2021, 12, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 192, null, 4, null, new DateTime(2021, 12, 22, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 188, null, 4, null, new DateTime(2021, 12, 22, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 124, null, 4, null, new DateTime(2021, 12, 21, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 184, null, 4, null, new DateTime(2021, 12, 22, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 176, null, 4, null, new DateTime(2021, 12, 22, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 172, null, 4, null, new DateTime(2021, 12, 22, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 168, null, 4, null, new DateTime(2021, 12, 22, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 164, null, 4, null, new DateTime(2021, 12, 22, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 160, null, 4, null, new DateTime(2021, 12, 21, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 156, null, 4, null, new DateTime(2021, 12, 21, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 152, null, 4, null, new DateTime(2021, 12, 21, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 148, null, 4, null, new DateTime(2021, 12, 21, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 144, null, 4, null, new DateTime(2021, 12, 21, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 140, null, 4, null, new DateTime(2021, 12, 21, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 136, null, 4, null, new DateTime(2021, 12, 21, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 132, null, 4, null, new DateTime(2021, 12, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 180, null, 4, null, new DateTime(2021, 12, 22, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, null, 3, null, new DateTime(2021, 12, 20, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 478, null, 2, null, new DateTime(2021, 12, 25, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 474, null, 2, null, new DateTime(2021, 12, 25, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 345, null, 1, null, new DateTime(2021, 12, 24, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 341, null, 1, null, new DateTime(2021, 12, 24, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 337, null, 1, null, new DateTime(2021, 12, 24, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 333, null, 1, null, new DateTime(2021, 12, 24, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 329, null, 1, null, new DateTime(2021, 12, 24, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 325, null, 1, null, new DateTime(2021, 12, 24, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 321, null, 1, null, new DateTime(2021, 12, 24, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 317, null, 1, null, new DateTime(2021, 12, 23, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 313, null, 1, null, new DateTime(2021, 12, 23, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 309, null, 1, null, new DateTime(2021, 12, 23, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 305, null, 1, null, new DateTime(2021, 12, 23, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 301, null, 1, null, new DateTime(2021, 12, 23, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 349, null, 1, null, new DateTime(2021, 12, 24, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 297, null, 1, null, new DateTime(2021, 12, 23, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 289, null, 1, null, new DateTime(2021, 12, 23, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 285, null, 1, null, new DateTime(2021, 12, 23, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 281, null, 1, null, new DateTime(2021, 12, 23, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 277, null, 1, null, new DateTime(2021, 12, 23, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 273, null, 1, null, new DateTime(2021, 12, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 269, null, 1, null, new DateTime(2021, 12, 23, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 265, null, 1, null, new DateTime(2021, 12, 23, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 261, null, 1, null, new DateTime(2021, 12, 23, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 257, null, 1, null, new DateTime(2021, 12, 23, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 253, null, 1, null, new DateTime(2021, 12, 23, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 249, null, 1, null, new DateTime(2021, 12, 23, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 245, null, 1, null, new DateTime(2021, 12, 23, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 293, null, 1, null, new DateTime(2021, 12, 23, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 241, null, 1, null, new DateTime(2021, 12, 23, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 353, null, 1, null, new DateTime(2021, 12, 24, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 361, null, 1, null, new DateTime(2021, 12, 24, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 465, null, 1, null, new DateTime(2021, 12, 25, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 461, null, 1, null, new DateTime(2021, 12, 25, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 457, null, 1, null, new DateTime(2021, 12, 25, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 453, null, 1, null, new DateTime(2021, 12, 25, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 449, null, 1, null, new DateTime(2021, 12, 25, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 445, null, 1, null, new DateTime(2021, 12, 25, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 441, null, 1, null, new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 437, null, 1, null, new DateTime(2021, 12, 25, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 433, null, 1, null, new DateTime(2021, 12, 25, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 429, null, 1, null, new DateTime(2021, 12, 25, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 425, null, 1, null, new DateTime(2021, 12, 25, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 421, null, 1, null, new DateTime(2021, 12, 25, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 357, null, 1, null, new DateTime(2021, 12, 24, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 417, null, 1, null, new DateTime(2021, 12, 25, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 409, null, 1, null, new DateTime(2021, 12, 25, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 405, null, 1, null, new DateTime(2021, 12, 25, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 401, null, 1, null, new DateTime(2021, 12, 25, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 397, null, 1, null, new DateTime(2021, 12, 24, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 393, null, 1, null, new DateTime(2021, 12, 24, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 389, null, 1, null, new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 385, null, 1, null, new DateTime(2021, 12, 24, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 381, null, 1, null, new DateTime(2021, 12, 24, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 377, null, 1, null, new DateTime(2021, 12, 24, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 373, null, 1, null, new DateTime(2021, 12, 24, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 369, null, 1, null, new DateTime(2021, 12, 24, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 365, null, 1, null, new DateTime(2021, 12, 24, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 413, null, 1, null, new DateTime(2021, 12, 25, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 469, null, 1, null, new DateTime(2021, 12, 25, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 237, null, 1, null, new DateTime(2021, 12, 22, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 229, null, 1, null, new DateTime(2021, 12, 22, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 105, null, 1, null, new DateTime(2021, 12, 21, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 101, null, 1, null, new DateTime(2021, 12, 21, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 97, null, 1, null, new DateTime(2021, 12, 21, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 93, null, 1, null, new DateTime(2021, 12, 21, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 89, null, 1, null, new DateTime(2021, 12, 21, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 85, null, 1, null, new DateTime(2021, 12, 21, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 81, null, 1, null, new DateTime(2021, 12, 21, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 77, null, 1, null, new DateTime(2021, 12, 20, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 73, null, 1, null, new DateTime(2021, 12, 20, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 69, null, 1, null, new DateTime(2021, 12, 20, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 65, null, 1, null, new DateTime(2021, 12, 20, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 61, null, 1, null, new DateTime(2021, 12, 20, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 109, null, 1, null, new DateTime(2021, 12, 21, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 57, null, 1, null, new DateTime(2021, 12, 20, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 49, null, 1, null, new DateTime(2021, 12, 20, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 45, null, 1, null, new DateTime(2021, 12, 20, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 41, null, 1, null, new DateTime(2021, 12, 20, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 37, null, 1, null, new DateTime(2021, 12, 20, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 33, null, 1, null, new DateTime(2021, 12, 20, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 29, null, 1, null, new DateTime(2021, 12, 20, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 25, null, 1, null, new DateTime(2021, 12, 20, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 21, null, 1, null, new DateTime(2021, 12, 20, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 17, null, 1, null, new DateTime(2021, 12, 20, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 13, null, 1, null, new DateTime(2021, 12, 20, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 9, null, 1, null, new DateTime(2021, 12, 20, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 5, null, 1, null, new DateTime(2021, 12, 20, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 53, null, 1, null, new DateTime(2021, 12, 20, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 233, null, 1, null, new DateTime(2021, 12, 22, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 113, null, 1, null, new DateTime(2021, 12, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 121, null, 1, null, new DateTime(2021, 12, 21, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 225, null, 1, null, new DateTime(2021, 12, 22, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 221, null, 1, null, new DateTime(2021, 12, 22, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 217, null, 1, null, new DateTime(2021, 12, 22, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 213, null, 1, null, new DateTime(2021, 12, 22, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 209, null, 1, null, new DateTime(2021, 12, 22, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 205, null, 1, null, new DateTime(2021, 12, 22, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 201, null, 1, null, new DateTime(2021, 12, 22, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 197, null, 1, null, new DateTime(2021, 12, 22, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 193, null, 1, null, new DateTime(2021, 12, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 189, null, 1, null, new DateTime(2021, 12, 22, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 185, null, 1, null, new DateTime(2021, 12, 22, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 181, null, 1, null, new DateTime(2021, 12, 22, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 117, null, 1, null, new DateTime(2021, 12, 21, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 177, null, 1, null, new DateTime(2021, 12, 22, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 169, null, 1, null, new DateTime(2021, 12, 22, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 165, null, 1, null, new DateTime(2021, 12, 22, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 161, null, 1, null, new DateTime(2021, 12, 22, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 157, null, 1, null, new DateTime(2021, 12, 21, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 153, null, 1, null, new DateTime(2021, 12, 21, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 149, null, 1, null, new DateTime(2021, 12, 21, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 145, null, 1, null, new DateTime(2021, 12, 21, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 141, null, 1, null, new DateTime(2021, 12, 21, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 137, null, 1, null, new DateTime(2021, 12, 21, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 133, null, 1, null, new DateTime(2021, 12, 21, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 129, null, 1, null, new DateTime(2021, 12, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 125, null, 1, null, new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 173, null, 1, null, new DateTime(2021, 12, 22, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 473, null, 1, null, new DateTime(2021, 12, 25, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 477, null, 1, null, new DateTime(2021, 12, 25, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, null, 2, null, new DateTime(2021, 12, 20, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 350, null, 2, null, new DateTime(2021, 12, 24, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 346, null, 2, null, new DateTime(2021, 12, 24, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 342, null, 2, null, new DateTime(2021, 12, 24, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 338, null, 2, null, new DateTime(2021, 12, 24, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 334, null, 2, null, new DateTime(2021, 12, 24, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 330, null, 2, null, new DateTime(2021, 12, 24, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 326, null, 2, null, new DateTime(2021, 12, 24, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 322, null, 2, null, new DateTime(2021, 12, 24, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 318, null, 2, null, new DateTime(2021, 12, 23, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 314, null, 2, null, new DateTime(2021, 12, 23, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 310, null, 2, null, new DateTime(2021, 12, 23, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 306, null, 2, null, new DateTime(2021, 12, 23, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 354, null, 2, null, new DateTime(2021, 12, 24, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 302, null, 2, null, new DateTime(2021, 12, 23, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 294, null, 2, null, new DateTime(2021, 12, 23, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 290, null, 2, null, new DateTime(2021, 12, 23, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 286, null, 2, null, new DateTime(2021, 12, 23, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 282, null, 2, null, new DateTime(2021, 12, 23, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 278, null, 2, null, new DateTime(2021, 12, 23, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 274, null, 2, null, new DateTime(2021, 12, 23, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 270, null, 2, null, new DateTime(2021, 12, 23, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 266, null, 2, null, new DateTime(2021, 12, 23, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 262, null, 2, null, new DateTime(2021, 12, 23, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 258, null, 2, null, new DateTime(2021, 12, 23, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 254, null, 2, null, new DateTime(2021, 12, 23, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 250, null, 2, null, new DateTime(2021, 12, 23, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 298, null, 2, null, new DateTime(2021, 12, 23, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 246, null, 2, null, new DateTime(2021, 12, 23, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 358, null, 2, null, new DateTime(2021, 12, 24, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 366, null, 2, null, new DateTime(2021, 12, 24, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 470, null, 2, null, new DateTime(2021, 12, 25, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 466, null, 2, null, new DateTime(2021, 12, 25, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 462, null, 2, null, new DateTime(2021, 12, 25, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 458, null, 2, null, new DateTime(2021, 12, 25, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 454, null, 2, null, new DateTime(2021, 12, 25, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 450, null, 2, null, new DateTime(2021, 12, 25, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 446, null, 2, null, new DateTime(2021, 12, 25, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 442, null, 2, null, new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 438, null, 2, null, new DateTime(2021, 12, 25, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 434, null, 2, null, new DateTime(2021, 12, 25, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 430, null, 2, null, new DateTime(2021, 12, 25, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 426, null, 2, null, new DateTime(2021, 12, 25, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 362, null, 2, null, new DateTime(2021, 12, 24, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 422, null, 2, null, new DateTime(2021, 12, 25, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 414, null, 2, null, new DateTime(2021, 12, 25, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 410, null, 2, null, new DateTime(2021, 12, 25, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 406, null, 2, null, new DateTime(2021, 12, 25, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 402, null, 2, null, new DateTime(2021, 12, 25, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 398, null, 2, null, new DateTime(2021, 12, 24, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 394, null, 2, null, new DateTime(2021, 12, 24, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 390, null, 2, null, new DateTime(2021, 12, 24, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 386, null, 2, null, new DateTime(2021, 12, 24, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 382, null, 2, null, new DateTime(2021, 12, 24, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 378, null, 2, null, new DateTime(2021, 12, 24, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 374, null, 2, null, new DateTime(2021, 12, 24, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 370, null, 2, null, new DateTime(2021, 12, 24, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 418, null, 2, null, new DateTime(2021, 12, 25, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 242, null, 2, null, new DateTime(2021, 12, 23, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 238, null, 2, null, new DateTime(2021, 12, 22, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 234, null, 2, null, new DateTime(2021, 12, 22, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 106, null, 2, null, new DateTime(2021, 12, 21, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 102, null, 2, null, new DateTime(2021, 12, 21, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 98, null, 2, null, new DateTime(2021, 12, 21, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 94, null, 2, null, new DateTime(2021, 12, 21, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 90, null, 2, null, new DateTime(2021, 12, 21, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 86, null, 2, null, new DateTime(2021, 12, 21, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 82, null, 2, null, new DateTime(2021, 12, 21, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 78, null, 2, null, new DateTime(2021, 12, 20, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 74, null, 2, null, new DateTime(2021, 12, 20, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 70, null, 2, null, new DateTime(2021, 12, 20, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 66, null, 2, null, new DateTime(2021, 12, 20, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 62, null, 2, null, new DateTime(2021, 12, 20, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 110, null, 2, null, new DateTime(2021, 12, 21, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 58, null, 2, null, new DateTime(2021, 12, 20, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 50, null, 2, null, new DateTime(2021, 12, 20, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 46, null, 2, null, new DateTime(2021, 12, 20, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 42, null, 2, null, new DateTime(2021, 12, 20, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 38, null, 2, null, new DateTime(2021, 12, 20, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 34, null, 2, null, new DateTime(2021, 12, 20, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 30, null, 2, null, new DateTime(2021, 12, 20, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 26, null, 2, null, new DateTime(2021, 12, 20, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 22, null, 2, null, new DateTime(2021, 12, 20, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 18, null, 2, null, new DateTime(2021, 12, 20, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 14, null, 2, null, new DateTime(2021, 12, 20, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 10, null, 2, null, new DateTime(2021, 12, 20, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 6, null, 2, null, new DateTime(2021, 12, 20, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 54, null, 2, null, new DateTime(2021, 12, 20, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 114, null, 2, null, new DateTime(2021, 12, 21, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 118, null, 2, null, new DateTime(2021, 12, 21, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 122, null, 2, null, new DateTime(2021, 12, 21, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 230, null, 2, null, new DateTime(2021, 12, 22, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 226, null, 2, null, new DateTime(2021, 12, 22, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 222, null, 2, null, new DateTime(2021, 12, 22, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 218, null, 2, null, new DateTime(2021, 12, 22, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 214, null, 2, null, new DateTime(2021, 12, 22, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 210, null, 2, null, new DateTime(2021, 12, 22, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 206, null, 2, null, new DateTime(2021, 12, 22, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 202, null, 2, null, new DateTime(2021, 12, 22, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 198, null, 2, null, new DateTime(2021, 12, 22, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 194, null, 2, null, new DateTime(2021, 12, 22, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 190, null, 2, null, new DateTime(2021, 12, 22, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppUserId", "BarberId", "Comment", "Date", "DateOfCreation", "DateOfUpdate", "PurchaseStatus", "ServiceTypeId" },
                values: new object[,]
                {
                    { 186, null, 2, null, new DateTime(2021, 12, 22, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 182, null, 2, null, new DateTime(2021, 12, 22, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 178, null, 2, null, new DateTime(2021, 12, 22, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 174, null, 2, null, new DateTime(2021, 12, 22, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 170, null, 2, null, new DateTime(2021, 12, 22, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 166, null, 2, null, new DateTime(2021, 12, 22, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 162, null, 2, null, new DateTime(2021, 12, 22, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 158, null, 2, null, new DateTime(2021, 12, 21, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 154, null, 2, null, new DateTime(2021, 12, 21, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 150, null, 2, null, new DateTime(2021, 12, 21, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 146, null, 2, null, new DateTime(2021, 12, 21, 16, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 142, null, 2, null, new DateTime(2021, 12, 21, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 138, null, 2, null, new DateTime(2021, 12, 21, 15, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 134, null, 2, null, new DateTime(2021, 12, 21, 14, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 130, null, 2, null, new DateTime(2021, 12, 21, 14, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 126, null, 2, null, new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 476, null, 4, null, new DateTime(2021, 12, 25, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 480, null, 4, null, new DateTime(2021, 12, 25, 17, 30, 0, 0, DateTimeKind.Local), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
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
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
