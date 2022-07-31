using Avansas.EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansas.DataAccessLayer.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.HasData(
                new User { UserId = 1, BirthDate = DateTime.Now, GsmNumber = "5367854878", Mail = "admin@hotmail.com", Name = "Admin", SurName = "Count", Password = "1234" },
                new User { UserId = 2, BirthDate = DateTime.Now, GsmNumber = "5389351289", Mail = "user@hotmail.com", Name = "User", SurName = "Count", Password = "1234" }
                );


        }
    }
}
