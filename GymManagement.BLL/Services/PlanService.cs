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

        public PlanService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = unitOfWork.PlanRepository.GetAll().Select(plan => new PlanViewModel
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationInDays = plan.DurationInDays,
                IsActive = plan.IsActive,
                Price = plan.Price,
            });
            return plans;
        }

        public PlanViewModel GetById(int id)
        {
            var plan = unitOfWork.PlanRepository.GetById(id);
            if (plan is not null)
            {

                return new PlanViewModel
                {
                    Id = plan.Id,
                    Name = plan.Name,
                    Description = plan.Description,
                    DurationInDays = plan.DurationInDays,
                    IsActive = plan.IsActive,
                    Price = plan.Price,
                };
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

                    plan.Updated_at = DateTime.Now;
                    plan.Name = updatePlanViewModel.Name;
                    plan.Description = updatePlanViewModel.Description;
                    plan.DurationInDays = updatePlanViewModel.DurationInDays;

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

                return new PlanViewModel
                {
                    Id = plan.Id,
                    Name = plan.Name,
                    Description = plan.Description,
                    DurationInDays = plan.DurationInDays,
                    IsActive = !plan.IsActive,
                    Price = plan.Price,
                };
            }
            else
            {
                return null!;
            }
        }

    }
}
