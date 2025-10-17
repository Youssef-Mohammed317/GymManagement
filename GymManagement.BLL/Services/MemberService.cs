using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public MemberService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = unitOfWork.MemberRepository.GetAll()
                .ProjectTo<MemberViewModel>(mapper.ConfigurationProvider);

            return members;
        }

        public MemberViewModel CreateMember(CreateMemberViewModel createMemberViewModel)
        {
            // get check email and phone
            var isEmailOrPhoneExist =
                CheckEmailAndPhoneExist(createMemberViewModel.Email, createMemberViewModel.Phone);

            if (!isEmailOrPhoneExist)
            {

                var member = mapper.Map<CreateMemberViewModel, Member>(createMemberViewModel);

                member = unitOfWork.MemberRepository.Create(member);

                unitOfWork.SaveChanges();

                return mapper.Map<MemberViewModel>(member);
            }
            else
            {
                throw new Exception("Error");
            }
        }


        public MemberViewModel GetById(int id)
        {
            var member = unitOfWork.MemberRepository.GetById(id);

            if (member != null)
            {
                return mapper.Map<MemberViewModel>(member);
            }
            return null!;
        }

        public MemberViewModel GetByEmail(string email)
        {
            var member = unitOfWork.MemberRepository.GetByEmail(email);

            if (member != null)
            {
                return mapper.Map<MemberViewModel>(member);
            }
            return null!;
        }

        public MemberViewModel GetByPhone(string phone)
        {
            var member = unitOfWork.MemberRepository.GetByPhone(phone);

            if (member != null)
            {
                return mapper.Map<MemberViewModel>(member);
            }
            return null!;
        }

        public MemberViewModel UpdateMember(int id, UpdateMemberViewModel updateMemberViewModel)
        {
            var member = unitOfWork.MemberRepository.GetById(id);
            if (member != null)
            {
                member = mapper.Map(updateMemberViewModel, member);

                member = unitOfWork.MemberRepository.Update(member);
                unitOfWork.SaveChanges();

                return mapper.Map<MemberViewModel>(member);
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

                return mapper.Map<MemberViewModel>(member);
            }
            return null!;
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
    }
}
