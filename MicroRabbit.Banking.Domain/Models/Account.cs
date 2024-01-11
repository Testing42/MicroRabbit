using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.Models
{
   public class Account
    {
        [Key]
        public int Id { get; set; }
        
        public string? AccountType { get; set; }
        [Required]
        public decimal AccountBalance { get; set; }
    }
}
