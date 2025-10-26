using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
