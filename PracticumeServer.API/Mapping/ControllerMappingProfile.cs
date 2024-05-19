using AutoMapper;
using PracticumeServer.API.Models;
using PracticumeServer.Core.Entites;

namespace PracticumeServer.API.Mapping
{
    public class ControllerMappingProfile:Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<EmployeeRolePostModel, EmployeeRole>().ReverseMap();
            CreateMap<RolePostModel, Role>().ReverseMap();
        }
    }
}
