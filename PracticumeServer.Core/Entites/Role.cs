using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.Entites
{
    public class Role
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Description must contain only letters")]


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
