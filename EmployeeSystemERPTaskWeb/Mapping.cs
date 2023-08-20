using AutoMapper;
using EmployeeSystemERPTaskWeb.Model.DTO;

namespace EmployeeSystemERPTaskWeb
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<EmployeeDTO, CreateEmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDTO, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<LanguageDTO, CreateLanguageDTO>().ReverseMap();

            CreateMap<LanguageLevelDTO, CreateLanguageLevelDTO>().ReverseMap();

            CreateMap<AccountDTO, CreateAccountDTO>().ReverseMap();

            CreateMap<LineOfBusinessDTO, LineOfBusinessCreateDTO>().ReverseMap();

            CreateMap<Account_LineOfBusinessDTO, CreateAccount_LineOfBusinessDTO>().ReverseMap();
            CreateMap<Account_LineOfBusinessDTO, UpdateAccount_LineOfBusinessDTO>().ReverseMap();

        }
    }
}
