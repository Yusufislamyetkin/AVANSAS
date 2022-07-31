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
    internal class RoleSeed: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {


            builder.HasData(
                new Role {  RoleId = 1, Name = "User" },
                new Role {  RoleId = 2, Name = "Admin" }
       
                );


        }
    }
}
