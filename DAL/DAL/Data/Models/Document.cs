using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class Document:ModelBase
    {
        public string Name { get; set; }
        public SignOffState SignOffState { get; set; }
        public ICollection<UserDocument> UserDocuments { get; set; }
    }
}
