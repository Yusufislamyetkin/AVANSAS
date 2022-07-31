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
    internal class UserRoleSeed:IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {


            builder.HasData(
                new UserRole {  RoleId = 2 , UserId = 1 },
                new UserRole {  RoleId = 1 , UserId = 2 }
             
                );


        }
    }
}
