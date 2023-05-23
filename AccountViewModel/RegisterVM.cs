using System.ComponentModel.DataAnnotations;

namespace LumiaMvc.AccountViewModel
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPasword { get; set; }  
    }
}
