using AutoMapper;
using CultureDepartment.Core.DTOs;
using CultureDepartment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager, ManagerDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Resident, ResidentDto>().ReverseMap();
            CreateMap<Worker, WorkerDto>().ReverseMap();
        }
    }
}
