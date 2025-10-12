using GymManagement.BLL.ViewModels.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();

        TrainerViewModel CreateTrainer(CreateTrainerViewModel createTrainerViewModel);

        TrainerViewModel GetById(int id);
        TrainerViewModel GetByEmail(string email);
        TrainerViewModel GetByPhone(string phone);
        TrainerViewModel UpdateTrainer(int id, CreateTrainerViewModel createTrainerViewModel);
        TrainerViewModel DeleteById(int id);
    }
}
