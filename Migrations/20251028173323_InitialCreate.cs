using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OfferDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "قسم الملابس", "/images/categories/clothes.jpg", "الملابس" },
                    { 2, "قسم الإكسسوارات", "/images/categories/accessories.jpg", "الإكسسوارات" },
                    { 3, "قسم الأحذية", "/images/categories/high-heels.jpg", "الأحذية" },
                    { 4, "قسم الملابس الكاجوال", "/images/categories/casual.jpg", "كاجوال" },
                    { 5, "قسم الملابس الشتوية", "/images/categories/winter.jpg", "الملابس الشتوية" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "OfferDate", "OfferPrice", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "فستان خفيف وأنيق للصيف", "/images/products/comfortable-summer-dress.jpg", "فستان صيفي مريح", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 120m, 25 },
                    { 2, 1, "فستان أبيض أنيق للمناسبات", "/images/products/short-white-dress.jpg", "فستان أبيض قصير", null, null, 150m, 18 },
                    { 3, 1, "قميص حريري أنيق للنساء", "/images/products/silk-blouse.jpg", "قميص حريري", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 135m, 180m, 12 },
                    { 4, 1, "تنورة ميدي أنيقة ومريحة", "/images/products/midi-skirt.jpg", "تنورة ميدي", null, null, 100m, 30 },
                    { 5, 1, "قميص قطني مخطط بألوان جميلة", "/images/products/striped-tshirt.jpg", "قميص مخطط", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 80m, 45 },
                    { 6, 2, "سوار ذهبي أنيق للنساء", "/images/products/gold-bangle-bracelet.jpg", "سوار ذهبي", new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 250m, 8 },
                    { 7, 2, "قلادة لؤلؤ فاخرة وأنيقة", "/images/products/pearl-necklace.jpg", "قلادة لؤلؤ", null, null, 300m, 5 },
                    { 8, 2, "حقيبة كتف أنيقة وعملية", "/images/products/shoulder-bag.jpg", "حقيبة كتف", new DateTime(2025, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 160m, 200m, 15 },
                    { 9, 2, "نظارات شمسية دائرية أنيقة", "/images/products/round-sunglasses.jpg", "نظارات شمسية دائرية", null, null, 120m, 22 },
                    { 10, 2, "قبعة واسعة الحواف أنيقة للصيف", "/images/products/wide-brim-hat.jpg", "قبعة واسعة الحواف", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 90m, 35 },
                    { 11, 3, "كعب عالي ملون أنيق ومريح", "/images/products/colorful-thick-heeled-shoes.jpg", "كعب عالي ملون", new DateTime(2025, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 140m, 180m, 20 },
                    { 12, 3, "صندل بكعب متوسط مريح للصيف", "/images/products/medium-heeled-sandals.jpg", "صندل بكعب متوسط", null, null, 150m, 15 },
                    { 13, 3, "حذاء مسطح أنيق ومريح", "/images/products/elegant-flat-shoes.jpg", "حذاء مسطح أنيق", null, null, 120m, 25 },
                    { 14, 3, "حذاء منصة عصري ومريح", "/images/products/platform-shoes.jpg", "حذاء منصة", null, null, 160m, 18 },
                    { 15, 3, "كعب عالي كلاسيكي أنيق", "/images/products/high-heels.jpg", "كعب عالي كلاسيكي", null, null, 200m, 12 },
                    { 16, 4, "قميص قطني ملون مريح للكاجوال", "/images/products/colored-cotton-t-shirts.jpg", "قميص قطني ملون", new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, 70m, 50 },
                    { 17, 4, "شورت جينز مريح للصيف", "/images/products/denim-shorts.jpg", "شورت جينز", null, null, 90m, 30 },
                    { 18, 4, "جينز ضيق أنيق ومريح", "/images/products/skinny-jeans.jpg", "جينز ضيق", null, null, 110m, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
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
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
