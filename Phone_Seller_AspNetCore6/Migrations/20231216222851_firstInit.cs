using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phone_Seller_AspNetCore6.Migrations
{
    public partial class firstInit : Migration
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
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneRatings",
                columns: table => new
                {
                    PhoneRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    IsRated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneRatings", x => x.PhoneRatingId);
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiftWrap = table.Column<bool>(type: "bit", nullable: false),
                    Shipped = table.Column<bool>(type: "bit", nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    PhoneName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneSlug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhonePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneStock = table.Column<int>(type: "int", nullable: false),
                    PhonePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneOldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhoneRating = table.Column<double>(type: "float", nullable: false),
                    PhoneRatingCountUser = table.Column<int>(type: "int", nullable: false),
                    PhoneStar = table.Column<int>(type: "int", nullable: false),
                    PhoneOnSale = table.Column<bool>(type: "bit", nullable: false),
                    PhoneIsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneID);
                    table.ForeignKey(
                        name: "FK_Phones_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_CartLine_Phones_PhoneID",
                        column: x => x.PhoneID,
                        principalTable: "Phones",
                        principalColumn: "PhoneID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1be1f3dd-6ea1-4786-9431-cb0b2638aab8", "3ff1dc11-fb39-4c6b-9e20-96e8b8ee494a", "User", "USER" },
                    { "56eb506e-3e10-4c6f-859a-7a0c10cc30cb", "7ab6d9a0-a1d7-4c71-bf9a-d4bcfcf94cda", "Editor", "EDITOR" },
                    { "9995ac20-50e7-41f5-bbf5-d6091df1a235", "2500a750-e3fb-4e59-b528-84cc8e4352c4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "BrandCode", "BrandName" },
                values: new object[,]
                {
                    { 1, "APL", "Apple" },
                    { 2, "SMG", "Samsung" },
                    { 3, "HUA", "Huawei" },
                    { 4, "XOI", "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "PhoneID", "BrandID", "PhoneCode", "PhoneDetail", "PhoneIsActive", "PhoneName", "PhoneOldPrice", "PhoneOnSale", "PhonePhotoUrl", "PhonePrice", "PhoneRating", "PhoneRatingCountUser", "PhoneSlug", "PhoneStar", "PhoneStock" },
                values: new object[,]
                {
                    { 1, 1, "APL-I15", "DYNAMIC ISLAND COMES TO IPHONE 15 ...", true, "iPhone 15", 0m, true, "/img/iphone-15.png", 799m, 0.0, 0, "iphone-15", 0, 100 },
                    { 2, 1, "APL-15P", "FORGED IN TITANIUM — iPhone 15 Pro Max has a strong and light aerospace-grade titanium design...", true, "iPhone 15 Pro", 0m, true, "/img/iphone-15-pro.png", 999m, 0.0, 0, "iphone-15-pro", 0, 50 },
                    { 3, 1, "APL-I14", "6.1-inch Super Retina XDR display2  • Advanced camera system for better photos in any light ...", true, "iPhone 14", 899m, true, "/img/iphone-14.png", 699m, 0.0, 0, "iphone-14", 0, 80 },
                    { 4, 1, "APL-14P", "6.7-inch Super Retina XDR display1  • Advanced camera system for better photos in any light ...", true, "iPhone 14 Plus", 999m, true, "/img/iphone-14-plus.png", 799m, 0.0, 0, "iphone-14-plus", 0, 200 },
                    { 5, 1, "APL-ISE", "4.7-inch Retina HD display1  • Advanced single-camera system with 12MP Wide camera; Smart HDR 4, Photographic Styles, Portrait mode and 4K video up to 60 fps ...", true, "iPhone SE", 669m, true, "/img/iphone-se.png", 579m, 0.0, 0, "iphone-se", 0, 99 },
                    { 6, 1, "APL-I13", "6.1-inch Super Retina XDR display2  • Cinematic mode adds shallow depth of field and shifts focus automatically in your videos ...", true, "iPhone 13", 0m, true, "/img/iphone-13.png", 899m, 0.0, 0, "iphone-13", 0, 10 },
                    { 7, 2, "SMG-S23", "Android 13  6.4\" Full HD+ Super AMOLED touchscreen  Triple 50 MP / 12 MP / 8 MP main cameras ...", true, "SAMSUNG Galaxy S23 FE 5G - 128 GB, Purple", 0m, true, "/img/samsung-galaxy-s23-fe-5g---128-gb-purple.webp", 599m, 0.0, 0, "samsung-galaxy-s23-fe-5g---128-gb-purple", 0, 10 },
                    { 8, 2, "SMG-A14", "Android 13  6.6\" Full HD+ LCD touchscreen  Triple 50 MP / 5 MP / 2 MP main cameras ...", true, "SAMSUNG Galaxy A14 - 64 GB, Black", 0m, true, "/img/samsung-galaxy-a14---64-gb-black.webp", 149m, 0.0, 0, "samsung-galaxy-a14---64-gb-black", 0, 20 },
                    { 9, 2, "SMG-A34", "Android 13  6.6\" Full HD+ Super AMOLED touchscreen  Triple 48 MP / 8 MP / 5 MP main cameras ...", true, "SAMSUNG Galaxy A34 5G - 128 GB, Awesome Black", 0m, true, "/img/samsung-galaxy-a34-5g---128-gb-awesome-black.webp", 349m, 0.0, 0, "samsung-galaxy-a34-5g---128-gb-awesome-black", 0, 40 },
                    { 10, 3, "HUA-20P", "About this item Huawei 51092NWK Color: twilight", true, "HUAWEI P20 Pro 128 GB/6 GB Single SIM Smartphone - Twilight (United Kingdom Version)", 359m, true, "/img/huawei-p20-pro-128-gb6-gb-single-sim-smartphone---twilight-united-kingdom-version.jpg", 149m, 0.0, 0, "huawei-p20-pro-128-gb6-gb-single-sim-smartphone---twilight-united-kingdom-version", 0, 5 },
                    { 11, 4, "XOI-N12", "About this item High resolution display: perfect readability in the sun, smooth scrolling, smooth videos and animations thanks to 120Hz refresh rate and 2400 x 1080 pixels Reliable performance: short response times even with complex applications, fast charging times and smooth gaming - possible with the built-in Snapdragon 685 High-resolution camera system: whether selfies with 13MP or with 50MP colourful photos and videos, the 50MP camera system allows high-resolution shots in any situation Long battery life: the 5000 mAh strong battery lasts all day and longer - the 33 W fast charging system allows for rapid charging of the Redmi mobile phone Handy design: the Redmi mobile phone combines high performance with a modern and slim design - height: 165.66 mm, width: 75.96 mm, depth: 7.85 mm, weight: 183.5 g", true, "Xiaomi Redmi Note 12 Smartphone, 4+128GB, 6.67 Inch FHD+ AMOLED DotDisplay, 5,000 mAh, 50MP Camera", 259m, true, "/img/xiaomi-redmi-note-12-smartphone-4128gb-667-inch-fhd-amoled-dotdisplay-5000-mah-50mp-camera.jpg", 149m, 0.0, 0, "xiaomi-redmi-note-12-smartphone-4128gb-667-inch-fhd-amoled-dotdisplay-5000-mah-50mp-camera", 0, 25 }
                });

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
                name: "IX_CartLine_OrderId",
                table: "CartLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_PhoneID",
                table: "CartLine",
                column: "PhoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomUserId",
                table: "Orders",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandID",
                table: "Phones",
                column: "BrandID");
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
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "PhoneRatings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
