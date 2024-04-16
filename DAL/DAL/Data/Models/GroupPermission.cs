using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class GroupPermission
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid GroupId { get; set; }
        [Required]
        public Permission Permission { get; set; }
        [Required]
        public Group Group { get; set; }
    }
}
