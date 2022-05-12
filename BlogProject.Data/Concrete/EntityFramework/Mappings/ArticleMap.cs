using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.Property(a=>a.Id).ValueGeneratedOnAdd();
            builder.Property(a=>a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a=>a.Content).IsRequired();
            builder.Property(a=>a.Content).HasColumnType("text");
            builder.Property(a=>a.Date).IsRequired();
            builder.Property(a=>a.SeoAuthor).IsRequired();
            builder.Property(a=>a.SeoAuthor).HasMaxLength(50);
            builder.Property(a =>a.SeoDescription).HasMaxLength(150);
            builder.Property(a=>a.SeoDescription).IsRequired();
            builder.Property(a =>a.SeoTags).IsRequired();
            builder.Property(a=>a.SeoTags).HasMaxLength(70);
            builder.Property(a=>a.ViewCount).IsRequired();
            builder.Property(a =>a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a=>a.Thumbnail).HasMaxLength(50);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(50);

            builder.HasOne<Category>(a => a.Category).WithMany(c=>c.Articles).
                HasForeignKey(a=>a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).
                HasForeignKey(u => u.UserId);
            builder.ToTable("Articles");

            builder.HasData(new Article
            {
                Id = 1,
                CategoryId = 1,
                Title =".Net 5 Yenilikleri",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir." +
                " Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak" +
                " üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır." +
                " Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır." +
                " 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda" +
                " Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Thumbnail="picture.jpg",
                SeoDescription= ".Net 5 Yenilikleri",
                SeoTags=":Net5,.Net Framework,.Net Core",
                SeoAuthor="Kadir Eğriboyun",
                Date=DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = ".Net 5 Yenilikleri",
                UserId = 1,
                ViewCount = 250,
                CommentCount = 1,
            },
            new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ 11 Yenilikleri",
                Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir." +
                " Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır." +
                " Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır." +
                " Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir." +
                " Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                Thumbnail = "picture.jpg",
                SeoDescription = "C++ 11 Yenilikleri",
                SeoTags = "C++ 11 Yenilikleri",
                SeoAuthor = "Kadir Eğriboyun",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ 11 Yenilikleri",
                UserId = 1,
                ViewCount = 200,
                CommentCount = 1,
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "Java ES2022 yenilikleri ",
                Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir." +
                " Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır." +
                " Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır." +
                " Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir." +
                " Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                Thumbnail = "picture.jpg",
                SeoDescription = "Java ES2022 yenilikleri ",
                SeoTags = "Java ES2022 yenilikleri ",
                SeoAuthor = "Kadir Eğriboyun",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Java ES2022 yenilikleri ",
                UserId = 1,
                ViewCount = 100,
                CommentCount = 1,
            }
            );
        }
    }
}
