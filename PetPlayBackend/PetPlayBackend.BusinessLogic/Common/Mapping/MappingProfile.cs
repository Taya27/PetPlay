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
            CreateMap<User, Models.UserModel>().ReverseMap();
            CreateMap<Pet, Models.PetModel>().ReverseMap();
            CreateMap<AddNewPetViewModel, Domain.Models.Pet>().ReverseMap();
            CreateMap<Toy, ToyModel>().ReverseMap();
            CreateMap<Toy, ToyViewModel>().ReverseMap();
            CreateMap<Access, AccessViewModel>().ReverseMap();
            CreateMap<Access, AccessModel>().ReverseMap();
        }
    }
}
