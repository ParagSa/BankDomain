using System.ComponentModel.DataAnnotations;

namespace Book_keeper.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]

        public string ConfrimPassword { get; set; }



        [Required(ErrorMessage = "please enter email address @example.com")]

        public string Email { get; set; }
    }
}
