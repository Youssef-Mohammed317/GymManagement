using GymManagement.BLL.ViewModels.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Interfaces
{
    public interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAllPlans();
        PlanViewModel GetById(int id);
        PlanViewModel UpdatePlan(int id,UpdatePlanViewModel updatePlanViewModel);
        PlanViewModel TogglePlan(int id);
    }
}
