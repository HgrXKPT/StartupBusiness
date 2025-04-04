using System.ComponentModel.DataAnnotations;

namespace StartupBusiness.Models
{
    public class Teams
    {
        private string _teamName;
        private int _memberCount;
        private int _projectCount;

        [Required(ErrorMessage ="Team name Field is required")]
        public string TeamName {
            get => _teamName;
            set;
        }
    }
}
