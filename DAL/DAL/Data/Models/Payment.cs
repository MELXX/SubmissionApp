using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class Payment:ModelBase
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
        public Recepient Recepient { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentRequestDate { get; set; }
        public Guid ManagerUserId { get; set; }
        public string PaymentDetails { get; set; }
        public string Description { get; set; }
        public ICollection<Document>? Documents { get; set; }
    }
}
