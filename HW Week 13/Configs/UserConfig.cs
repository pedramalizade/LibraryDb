using HW_Week_13.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_13.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            //builder.HasMany(u => u.Books).WithOne(u => u.User);

            //var user1 = new User()
            //{
            //    Id = 1,
            //    Name = "Alireza",
            //    Family = "Beigi",
            //    Email = "Alireza@gmail.com",
            //    Password = "1234",
            //    UserName = "AlirezaBeigi",
            //    Role = Enum.RoleEnum.Admin
            //};
            //builder.HasData(user1);

            //var user2 = new User()
            //{
            //    Id = 2,
            //    Name = "Amir",
            //    Family = "karimi",
            //    Email = "amir@gmail.com",
            //    Password = "4321",
            //    UserName = "AmirKarimi",
            //    Role = Enum.RoleEnum.User
            //};
            //builder.HasData(user2);
        }
    }
}
