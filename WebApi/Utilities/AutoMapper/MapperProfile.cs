using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDtoForRegistration, AppUser>();
            CreateMap<WorkoutDtoForUpdate, Workout>();
            CreateMap<WorkoutDtoForInsertion, Workout>();
            CreateMap<ExerciseDtoForUpdate, Exercise>();
            CreateMap<ExerciseDtoForInsertions, Exercise>();
            CreateMap<WorkoutHistoryDtoForInsertion, WorkoutHistory>();
            CreateMap<WorkoutHistoryDtoForUpdate, WorkoutHistory>().ReverseMap();
        }
    }
}
