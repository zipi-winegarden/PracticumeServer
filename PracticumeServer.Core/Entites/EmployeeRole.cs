using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Entites
{
    public class EmployeeRole
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "EmployeeId is required")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
        [Required(ErrorMessage = "IsAdministrative is required")]
        public bool IsAdministrative { get; set; }
        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }
    }
}
