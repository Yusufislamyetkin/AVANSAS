using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Avansas.EntityLayer.Models
{
    public  class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string GsmNumber { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        [NotMapped]
        public string EncrypedId { get; set; }

      
  
        public DateTime BirthDate { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
