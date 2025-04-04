using System.ComponentModel.DataAnnotations;

namespace StartupBusiness.Models
{
    public class Team
    {
        private string _teamName;
        private int _memberCount;
        private int _projectCount;

        public int Id {
            get; set;
        }

        [Required(ErrorMessage ="TeamName Field is required")]
        [MaxLength(50,ErrorMessage ="Max TeamName lenght is 50")]
        public string TeamName {
            get => _teamName;
            set {
                _teamName = value;
            }
        }

        [Required(ErrorMessage ="MemberCount Field is required")]
        [Range(0, 10, ErrorMessage = "The number of team members must be between 0 and 10.")]
        public int MemberCount {

            get => _memberCount;
            set {
                _memberCount = value;
            }
        }

        [Required(ErrorMessage ="ProjectCount Field is required")]
        [Range(0,3, ErrorMessage ="The number of projects must be between 0 and 3")]
        public int ProjectCount {
            get => _projectCount;
            set {
                _projectCount = value;
            }
        }

        public ICollection<User> Users {
            get; set;
        }
        public ICollection<Project> Project {
            get; set;
        }
    }
}
