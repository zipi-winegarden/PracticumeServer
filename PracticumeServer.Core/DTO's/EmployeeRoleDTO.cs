using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.DTO_s
{
    public class EmployeeRoleDTO
    {
        public int RoleID { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime StartDate { get; set; }
    }
}
