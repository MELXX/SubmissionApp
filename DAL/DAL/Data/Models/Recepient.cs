using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class Recepient:ModelBase
    {
        public string MyReference {  get; set; }
        public string RecepientReference {  get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string SwiftCode { get; set; }
        public string PaymentDetails { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
