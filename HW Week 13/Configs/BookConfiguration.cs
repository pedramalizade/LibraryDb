using HW_Week_13.Entitis;
using HW_Week_13.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_Week_13.Configs
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {



            builder.HasOne(a => a.User).WithMany(x => x.Books).HasForeignKey(x => x.UserId);

            //builder.HasData(new Book()
            //{
            //    Id = 1,
            //    Title = "Math",
            //    Price = 200,
            //    Writer = "Hasan",
            //    UserId = 1,
            //    Borrowdate = DateTime.Now,
            //    Genre = GenreEnum.Scientific,
            //    IsBorrowed = true,

            //}

            //    );


            //var book2 = new Book()
            //{
            //    Id = 2,
            //    Title = "Basketball",
            //    Price = 150,
            //    Writer = "mmd",
            //    UserId = 2,
            //    Borrowdate = DateTime.Now,
            //    Genre = GenreEnum.Sports,
            //    IsBorrowed = true

            //};
            //builder.HasData(book2);

        }
    }
}