using System.ComponentModel.DataAnnotations;

namespace StartupBusiness.Models
{
    public class Project
    {
        private string _projectName;
        private DateTime _createdAt;

        public int Id {
            get; set;
        }

        [Required(ErrorMessage ="ProjectName Field is required")]
        [MaxLength(40, ErrorMessage ="Max lenght of ProjectName is 40 letters")]
        public string ProjectName {
            get => _projectName;
            set {

                _projectName = value;
            }
        }

        [Required(ErrorMessage ="CreatedAt Field is required")]
        public DateTime CreatedAt {
            get => _createdAt;
            set {
                _createdAt = value;
            }
        }

        public int TeamsId {
            get; set;
        }

        public Team Teams {
            get;
            set;
        }
    }
}
