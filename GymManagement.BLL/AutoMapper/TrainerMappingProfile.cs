using AutoMapper;
using GymManagement.BLL.ViewModels.Trainer;
using GymManagement.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.AutoMapper
{
    public class TrainerMappingProfile : Profile
    {
        public TrainerMappingProfile()
        {
            CreateMap<Trainer, TrainerViewModel>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.Specialties.ToString()))
                 .ReverseMap();

            CreateMap<CreateTrainerViewModel, Trainer>()
                 .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.Specialties))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                 .ForMember(dest => dest.Adderss.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                 .ForMember(dest => dest.Adderss.City, opt => opt.MapFrom(src => src.City))
                 .ForMember(dest => dest.Adderss.Streat, opt => opt.MapFrom(src => src.Streat))
                 .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();

            CreateMap<UpdateTrainerViewModel, Trainer>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.Specialties))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                 .ForMember(dest => dest.Adderss.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                 .ForMember(dest => dest.Adderss.City, opt => opt.MapFrom(src => src.City))
                 .ForMember(dest => dest.Adderss.Streat, opt => opt.MapFrom(src => src.Streat))
                 .ForMember(dest => dest.Updated_at, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();
        }
    }
}
