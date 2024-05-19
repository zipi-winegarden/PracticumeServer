using AutoMapper;
using PracticumeServer.Core.DTO_s;
using PracticumeServer.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumeServer.Core.mapping
{
    public class CoreMappingProfile: Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<EmployeeRoleDTO, EmployeeRole>().ReverseMap();
            CreateMap<RoleDTO, Role>().ReverseMap();

        }
    }
}
