using AutoMapper;
using Page_DAL.Models;
using Page_Pl.ModelsView;

namespace Page_Pl.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModelView,Employee>().ReverseMap();
        }
    }
}
