using AutoMapper;
using EmployeesSystemERPTaskAPI.Model.DTO;
using EmployeeSystemERPTaskAPI.Model;
using EmployeeSystemERPTaskAPI.Model.DTO;

namespace EmployeeSystemERPTaskAPI
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Language,LanguageDTO>().ReverseMap();
            CreateMap<Language,CreateLanguageDTO>().ReverseMap();

            CreateMap<LanguageLevel, LanguageLevelDTO>().ReverseMap();
            CreateMap<LanguageLevel, CreateLanguageLevelDTO>().ReverseMap();

            CreateMap<LineOfBusiness, LineOfBusinessDTO>().ReverseMap();
            CreateMap<LineOfBusiness, LineOfBusinessCreateDTO>().ReverseMap();

            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, CreateAccountDTO>().ReverseMap();


            CreateMap<Account_LineOfBusiness, Account_LineOfBusinessDTO>().ReverseMap();
            CreateMap<Account_LineOfBusiness, CreateAccount_LineOfBusinessDTO>().ReverseMap();
            CreateMap<Account_LineOfBusiness, UpdateAccount_LineOfBusinessDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<EmployeeLangLevel, EmployeeLangLevelDTO>().ReverseMap();
            CreateMap<EmployeeLangLevel, CreateEmployeeLangLevelDTO>().ReverseMap();
            CreateMap<EmployeeLangLevel, UpdateEmployeeLangLevelDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();

        }
    }
}
