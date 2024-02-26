using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.Models
{
   public class Transferlog
    {
        [Key]
        public int Id { get; set; }
        
        public int FromAccount { get; set; }
        [Required]
        public int ToAccount { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
