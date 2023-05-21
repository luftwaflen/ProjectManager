using AutoMapper;
using ProjectManagerCore.Models;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Mappers;

public class WorkTimeModelToView : Profile
{
    public WorkTimeModelToView()
    {
        CreateMap<WorkTimeModel, WorkTimeViewModel>().ReverseMap();
    }
}