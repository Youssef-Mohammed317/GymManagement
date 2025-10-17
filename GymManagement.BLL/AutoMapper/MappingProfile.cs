using AutoMapper;
using GymManagement.BLL.ViewModels.SessionViewModel;
using GymManagement.BLL.ViewModels.Trainer;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Implementations;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile(IUnitOfWork unitOfWork)
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SessionCategory.CategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.SessionTrainer.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.AvailableSlots, opt => opt.MapFrom(src => src.Capacity - unitOfWork.MemberSessionRepository.GetAll()
                       .Where(ms => ms.SessionId == src.Id).Count()))
                .ReverseMap();


            CreateMap<CreateSessionViewModel, Session>()
                 .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                 .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TrainerId))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => DateTime.Now))
                 .ReverseMap();

            CreateMap<UpdateSessionViewModel, Session>()
                 .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                 .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TrainerId))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.Updated_at, opt => opt.MapFrom(src => DateTime.Now))
                 .ReverseMap();


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
