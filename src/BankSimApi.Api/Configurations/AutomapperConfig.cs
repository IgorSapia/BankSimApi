using AutoMapper;
using BankSimApi.Api.ViewModels;
using BankSimApi.Business.Models;

namespace BankSimApi.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
