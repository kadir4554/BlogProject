using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3056), "C# Programlama Dili ile ilgili bilgiler", true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3064), "C#", "C# Blog kısmı" },
                    { 2, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3073), "C++ Programlama Dili ile ilgili bilgiler", true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3074), "C++", "C++ Blog kısmı" },
                    { 3, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3078), "Java Programlama Dili ile ilgili bilgiler", true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 444, DateTimeKind.Local).AddTicks(3078), "Java", "Java Blog Kısmı" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 446, DateTimeKind.Local).AddTicks(7737), "Yönetici rolüdür,tüm haklara sahiptir", true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 446, DateTimeKind.Local).AddTicks(7744), "Admin", "Admin Rolüdür" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "UserName" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 454, DateTimeKind.Local).AddTicks(7373), "İlk admin kullanıcı", "kadir@gmail.com", "Kadir", true, false, "Eğriboyun", "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 454, DateTimeKind.Local).AddTicks(7384), "Admin Kullanıcısı", new byte[] { 102, 51, 55, 57, 101, 97, 102, 51, 99, 56, 51, 49, 98, 48, 52, 100, 101, 49, 53, 51, 52, 54, 57, 100, 49, 98, 101, 99, 51, 52, 53, 101 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "Kean" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewCount" },
                values: new object[] { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(3625), new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(3086), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(3901), ".Net 5 Yenilikleri", "Kadir Eğriboyun", ".Net 5 Yenilikleri", ":Net5,.Net Framework,.Net Core", "picture.jpg", ".Net 5 Yenilikleri", 1, 250 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewCount" },
                values: new object[] { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4498), new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4497), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4499), "C++ 11 Yenilikleri", "Kadir Eğriboyun", "C++ 11 Yenilikleri", "C++ 11 Yenilikleri", "picture.jpg", "C++ 11 Yenilikleri", 1, 200 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewCount" },
                values: new object[] { 3, 3, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4504), new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4503), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 442, DateTimeKind.Local).AddTicks(4505), "Java ES2022 yenilikleri ", "Kadir Eğriboyun", "Java ES2022 yenilikleri ", "Java ES2022 yenilikleri ", "picture.jpg", "Java ES2022 yenilikleri ", 1, 100 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6704), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6712), "C# Yorum", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. " });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6729), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6730), "C++ Yorum", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. " });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 3, 3, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6733), true, false, "InitialCreate", new DateTime(2022, 5, 12, 19, 22, 32, 445, DateTimeKind.Local).AddTicks(6734), "Java Yorum", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. " });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
