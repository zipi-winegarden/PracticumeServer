using PracticumeServer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.DTO_s
{
    public class EmployeeDTO
    {
        public int Id {  get; set; }
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime EntryWorkDate { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsActive { get; set; }
        public List<EmployeeRoleDTO> EmployeeRoles { get; set; }
    }
}


   







