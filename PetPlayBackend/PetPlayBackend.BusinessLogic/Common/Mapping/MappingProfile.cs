using AutoMapper;
using PetPlayBackend.BusinessLogic.ViewModels;
using PetPlayBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Common.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationViewModel, User>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<User, Models.User>().ReverseMap();
            CreateMap<Pet, Models.Pet>().ReverseMap();
            CreateMap<AddNewPetViewModel, Domain.Models.Pet>().ReverseMap();
        }
    }
}
