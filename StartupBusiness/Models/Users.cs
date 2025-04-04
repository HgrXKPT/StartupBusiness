
using System.ComponentModel.DataAnnotations;

namespace StartupBusiness.Models
{
    public class Users
    {
        private string _name;
        private string _email;
        private string _password;

        [Required(ErrorMessage ="Name Field is requried")]
        public string Name {
            get => _name;

            set {
                _name = value.Trim();
            }
        }

        [Required(ErrorMessage ="Email Field is required")]
        [EmailAddress(ErrorMessage = "The email provided is invalid")]
        public string Email {
            get => _email;

            set {

                
                    _email = value;
                
            }

        }

        [Required(ErrorMessage ="Password Field is required")]
        public string Password {
            get => _password;
            set {

                _password = value;
            }
        }

        

    }
}
