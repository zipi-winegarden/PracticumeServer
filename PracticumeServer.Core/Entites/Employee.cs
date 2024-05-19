using PracticumeServer.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Entites
{
    public enum Gender { Male = 1, Fmale }
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(9, MinimumLength = 9, ErrorMessage = "IDNumber must contain exactly 9 digits")]
        [Required(ErrorMessage = "IDNumber is required")]
        public string IDNumber { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters")]

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "LastName must contain only letters")]

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "EntryWorkDate is required")]
        public DateTime EntryWorkDate { get; set; }
        [BirthDate(ErrorMessage = "BirthDate must be before today")]
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; } = true;

        public List<EmployeeRole> EmployeeRoles { get; set; }
    }

}
