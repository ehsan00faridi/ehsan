namespace WebMVC.Models
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public List<string> AvailableRoles { get; set; }
        public IList<string> AssignedRoles { get; set; }
        public List<string> SelectedRoles { get; set; } = new List<string>();
    }

}
