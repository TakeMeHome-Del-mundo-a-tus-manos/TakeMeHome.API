using AutoMapper;
using TakeMeHome.API.TakeMeHome.Domain.Models;
using TakeMeHome.API.TakeMeHome.Resources;

namespace TakeMeHome.API.TakeMeHome.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
       CreateMap<User, UserResource>(); 
    }
}