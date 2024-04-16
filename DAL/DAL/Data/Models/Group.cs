using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class Group : ModelBase
    {
        [Required]
        public string Name { get; set; }
        public ICollection<UserGroup> Users { get; set;}
        public ICollection<GroupPermission> Permissions { get; set;}
    }
}
