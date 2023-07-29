using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Keeper_DomainModels
{
    public enum IncomeType
    {
        Income,
        Expense
    }
    public class Transaction
    {
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public IncomeType type { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }

}
