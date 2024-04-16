using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public abstract class ModelBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
