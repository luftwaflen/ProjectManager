using AutoMapper;
using ProjectManagerCore.Models;
using ProjectManagerWebApp.Models;

namespace ProjectManagerWebApp.Mappers;

public class TaskModelToView : Profile
{
    public TaskModelToView()
    {
        CreateMap<TaskModel, TaskViewModel>().ReverseMap();
    }
}