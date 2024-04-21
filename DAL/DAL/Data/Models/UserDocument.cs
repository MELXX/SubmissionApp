using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class UserDocument:ModelBase
    {
        public Guid EmployeeUserId { get; set; }
        [ForeignKey("ClientUser")]
        public Guid ClientUserId { get; set; }
        public User ClientUser { get; set; }
        public Document Document { get; set; }
    }
}
