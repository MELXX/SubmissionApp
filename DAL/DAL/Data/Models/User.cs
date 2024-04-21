using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class User:ModelBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<UserGroup> Groups { get; set; }
        public ICollection<UserDocument> UserDocuments { get; set; }


    }
}
