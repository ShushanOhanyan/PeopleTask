using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Relation { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

      
        public UserDAL ToDALModel()
        {
            return new UserDAL()
            {
                Id = Id,
                Email = Email,
                Name = Name,
                PhoneNumber = PhoneNumber,
                Relation = PhoneNumber,
                Surname = Surname,
            };
        }
    }
}
