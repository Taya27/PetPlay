using AutoMapper;
using PetPlayBackend.BusinessLogic.ViewModels;
using PetPlayBackend.Domain.Models;
using PetPlayBackend.BusinessLogic.Models;

namespace PetPlayBackend.BusinessLogic.Common.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationViewModel, User>().ReverseMap();

            CreateMap<UserViewModel, User>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<Pet, PetModel>().ReverseMap();

            CreateMap<AddNewPetViewModel, Pet>().ReverseMap();

            CreateMap<Toy, ToyModel>().ReverseMap();

            CreateMap<Toy, ToyViewModel>().ReverseMap();

            CreateMap<Access, AccessViewModel>().ReverseMap();

            CreateMap<Access, AccessModel>().ReverseMap();

            CreateMap<Connection, ConnectionModel>().ReverseMap();
        }
    }
}
