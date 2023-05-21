using AutoMapper;
using ProjectManagerCore.Models;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Mappers;

public class ProjectModelToView : Profile
{
    public ProjectModelToView()
    {
        CreateMap<ProjectModel, ProjectViewModel>().ReverseMap();
    }
}