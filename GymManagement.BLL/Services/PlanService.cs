using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.Plan;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Services
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlanService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = unitOfWork.PlanRepository.GetAll()
                .ProjectTo<PlanViewModel>(mapper.ConfigurationProvider).ToList();
            return plans;
        }

        public PlanViewModel GetById(int id)
        {
            var plan = unitOfWork.PlanRepository.GetById(id);
            if (plan is not null)
            {
                return mapper.Map<PlanViewModel>(plan);
            }
            else
            {
                return null!;
            }
        }

        public PlanViewModel UpdatePlan(int id, UpdatePlanViewModel updatePlanViewModel)
        {
            var plan = unitOfWork.PlanRepository.GetById(id);


            if (plan is not null)
            {
                var IsHasActiveMemberShips = HasActiveMemberShips(plan.PlanMembers);
                if (!IsHasActiveMemberShips)
                {

                    plan = mapper.Map(updatePlanViewModel, plan);
                    unitOfWork.PlanRepository.Update(plan);
                    unitOfWork.SaveChanges();
                }
            }

            return null!;
        }

        private bool HasActiveMemberShips(ICollection<MemberShip> memberShips)
        {

            bool hasActiveMemberShips = false;

            foreach (var memberShip in memberShips)
            {
                if (memberShip.Status == "Active")
                {
                    return true;
                }
            }


            return hasActiveMemberShips;
        }

        public PlanViewModel TogglePlan(int id)
        {
            var plan = unitOfWork.PlanRepository.GetById(id);
            if (plan is not null)
            {
                plan.IsActive = !plan.IsActive;

                return mapper.Map<PlanViewModel>(plan);
            }
            else
            {
                return null!;
            }
        }

    }
}
