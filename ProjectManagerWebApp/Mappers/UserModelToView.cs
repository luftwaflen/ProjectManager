using AutoMapper;
using ProjectManagerCore.Models;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Mappers;

public class UserModelToView : Profile
{
    public UserModelToView()
    {
        CreateMap<UserModel, UserViewModel>().ReverseMap();
    }
}