using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models
{
    public class UserDAL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Relation { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public User ToModel()
        {
            return new User()
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
