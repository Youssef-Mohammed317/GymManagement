﻿using AutoMapper;
using GymManagement.BLL.ViewModels.Member;
using GymManagement.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.AutoMapper
{
    public class MemberMappingProfile : Profile
    {
        public MemberMappingProfile()
        {
            CreateMap<Member, MemberViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ReverseMap();


            CreateMap<CreateMemberViewModel, Member>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.HealthRecord, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Adderss, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<CreateMemberViewModel, Address>()
                .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Streat, opt => opt.MapFrom(src => src.Streat))
                .ReverseMap();

            CreateMap<CreateMemberViewModel, HealthRecord>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.HealthRecord.Weight))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.HealthRecord.Height))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.HealthRecord.Note))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.HealthRecord.BloodType))
                .ForMember(dest => dest.Created_at, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();


            CreateMap<UpdateMemberViewModel, Member>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
               .ForMember(dest => dest.Updated_at, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.HealthRecord, opt => opt.MapFrom(src => src))
               .ForMember(dest => dest.Adderss, opt => opt.MapFrom(src => src))
               .ReverseMap();

            CreateMap<UpdateMemberViewModel, Address>()
            .ForMember(dest => dest.BuildingNumber, opt => opt.MapFrom(src => src.BuildingNumber))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Streat, opt => opt.MapFrom(src => src.Streat))
            .ReverseMap();

            CreateMap<UpdateMemberViewModel, HealthRecord>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.HealthRecord.Weight))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.HealthRecord.Height))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.HealthRecord.Note))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.HealthRecord.BloodType))
                .ForMember(dest => dest.Updated_at, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();
        }
    }
}
