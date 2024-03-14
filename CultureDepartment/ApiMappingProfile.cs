using AutoMapper;
using CultureDepartment.API.Models.post;
using CultureDepartment.API.Models.put;
using CultureDepartment.Core.Entities;

namespace CultureDepartment.API
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Resident, ResidentPutModel>().ReverseMap();
            CreateMap<Resident, ResidentPostModel>().ReverseMap();
            CreateMap<Event, EventPostModel>().ReverseMap();
            CreateMap<Worker, WorkerPostModel>().ReverseMap();
        }
    }
}
