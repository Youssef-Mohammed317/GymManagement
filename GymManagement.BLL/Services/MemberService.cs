using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.Member;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemberService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = unitOfWork.MemberRepository.GetAll().Select(m => new MemberViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Gender = m.Gender.ToString(),
                Phone = m.Phone,
                Photo = m.Photo,
            });

            return members;
        }

        public MemberViewModel CreateMember(CreateMemberViewModel createMemberViewModel)
        {
            // get check email and phone
            var isEmailOrPhoneExist =
                CheckEmailAndPhoneExist(createMemberViewModel.Email, createMemberViewModel.Phone);

            if (!isEmailOrPhoneExist)
            {
                var member = new Member
                {
                    Name = createMemberViewModel.Name,
                    Email = createMemberViewModel.Email,
                    Phone = createMemberViewModel.Phone,
                    Gender = createMemberViewModel.Gender,
                    DateOfBirth = createMemberViewModel.DateOfBirth,
                    HealthRecord = new HealthRecord
                    {
                        Height = createMemberViewModel.HealthRecord.Height,
                        Weight = createMemberViewModel.HealthRecord.Weight,
                        BloodType = createMemberViewModel.HealthRecord.BloodType,
                        Note = createMemberViewModel.HealthRecord.Note,
                        Created_at = DateTime.Now,
                    },
                    Adderss = new Adderss
                    {
                        BuildingNumber = createMemberViewModel.BuildingNumber,
                        City = createMemberViewModel.City,
                        Streat = createMemberViewModel.Streat,

                    },
                    Photo = createMemberViewModel.Photo,
                    Created_at = DateTime.Now,
                };
                member = unitOfWork.MemberRepository.Create(member);

                unitOfWork.SaveChanges();

                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            else
            {
                throw new Exception("Error");
            }
        }
        private bool CheckEmailAndPhoneExist(string email, string phone)
        {
            if (unitOfWork.MemberRepository.GetByEmail(email) != null
                && unitOfWork.MemberRepository.GetByPhone(phone) != null)
            {
                return true;
            }
            return false;
        }

        public MemberViewModel GetById(int id)
        {
            var member = unitOfWork.MemberRepository.GetById(id);

            if (member != null)
            {
                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            return null!;
        }

        public MemberViewModel GetByEmail(string email)
        {
            var member = unitOfWork.MemberRepository.GetByEmail(email);

            if (member != null)
            {
                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            return null!;
        }

        public MemberViewModel GetByPhone(string phone)
        {
            var member = unitOfWork.MemberRepository.GetByPhone(phone);

            if (member != null)
            {
                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            return null!;
        }

        public MemberViewModel UpdateMember(int id, CreateMemberViewModel createMemberViewModel)
        {
            var member = unitOfWork.MemberRepository.GetById(id);
            if (member != null)
            {

                member.Name = createMemberViewModel.Name;
                member.Email = createMemberViewModel.Email;
                member.Phone = createMemberViewModel.Phone;
                member.Gender = createMemberViewModel.Gender;
                member.DateOfBirth = createMemberViewModel.DateOfBirth;

                member.HealthRecord.Height = createMemberViewModel.HealthRecord.Height;
                member.HealthRecord.Weight = createMemberViewModel.HealthRecord.Weight;
                member.HealthRecord.BloodType = createMemberViewModel.HealthRecord.BloodType;
                member.HealthRecord.Note = createMemberViewModel.HealthRecord.Note;
                member.HealthRecord.Updated_at = DateTime.Now;

                member.Adderss.BuildingNumber = createMemberViewModel.BuildingNumber;
                member.Adderss.City = createMemberViewModel.City;
                member.Adderss.Streat = createMemberViewModel.Streat;

                member.Photo = createMemberViewModel.Photo;
                member.Updated_at = DateTime.Now;

                member = unitOfWork.MemberRepository.Update(member);
                unitOfWork.SaveChanges();
                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            return null!;
        }

        public MemberViewModel DeleteById(int id)
        {
            var member = unitOfWork.MemberRepository.GetById(id);
            if (member != null)
            {
                member = unitOfWork.MemberRepository.Delete(member);
                unitOfWork.SaveChanges();
                return new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email,
                    Gender = member.Gender.ToString(),
                    Phone = member.Phone,
                    Photo = member.Photo,
                };
            }
            return null!;
        }
    }
}
