using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Book_Keeper_DomainModels
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }



        [Required(ErrorMessage = "please enter email address @example.com")]

        public string Email { get; set; }



        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}