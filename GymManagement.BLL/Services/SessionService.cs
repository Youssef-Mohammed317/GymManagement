using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.SessionViewModel;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SessionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {

            var sessions = unitOfWork.SessionRepository.GetAll()
                .Include(s => s.SessionTrainer)
                .Include(s => s.SessionCategory)
                .Select(s =>
                new SessionViewModel
                {
                    Id = s.Id,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Capacity = s.Capacity,
                    Description = s.Descripcion,
                    TrainerName = s.SessionTrainer.Name,
                    CategoryName = s.SessionCategory.CategoryName,
                    AvailableSlots = s.Capacity - unitOfWork.MemberSessionRepository.GetAll()
                    .Where(ms => ms.SessionId == s.Id).Count()
                }
            );

            return sessions;
        }
        public SessionViewModel GetSessionById(int id)
        {

            var s = unitOfWork.SessionRepository
                .GetByIdWithTrainerAndCategory(id);

            var session = new SessionViewModel
            {
                Id = s.Id,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Capacity = s.Capacity,
                Description = s.Descripcion,
                TrainerName = s.SessionTrainer.Name,
                CategoryName = s.SessionCategory.CategoryName,
                AvailableSlots = s.Capacity - unitOfWork.MemberSessionRepository.GetAll()
                      .Where(ms => ms.SessionId == s.Id).Count()
            };

            return session;
        }

    }

}
