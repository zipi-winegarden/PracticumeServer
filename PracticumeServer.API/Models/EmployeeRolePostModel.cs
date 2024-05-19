namespace PracticumeServer.API.Models
{
    public class EmployeeRolePostModel
    {
        public int RoleId { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime StartDate { get; set; }
    }
}
