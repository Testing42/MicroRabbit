using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.Models
{
   public class TransferLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FromAccount { get; set; }
        [Required]
        public decimal ToAccount { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
