using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.SessionViewModel;
using GymManagement.DAL.Entites;
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

        public SessionViewModel CreateSession(CreateSessionViewModel session)
        {
            var cat = unitOfWork.CategoryRepository.GetById(session.CategoryId);
            var trainer = unitOfWork.TrainerRepository.GetById(session.TrainerId);

            if (trainer != null && cat is not null)
            {

                var sessionModel = new Session
                {
                    Capacity = session.Capacity,
                    CategoryId = session.CategoryId,
                    Descripcion = session.Description,
                    TrainerId = session.TrainerId,
                    StartDate = session.StartDate,
                    EndDate = session.EndDate,
                    Created_at = DateTime.Now,
                };

                unitOfWork.SessionRepository.Create(sessionModel);
                unitOfWork.SaveChanges();

                var sessionViewModel = new SessionViewModel
                {
                    Id = sessionModel.Id,
                    StartDate = sessionModel.StartDate,
                    EndDate = sessionModel.EndDate,
                    Capacity = sessionModel.Capacity,
                    Description = sessionModel.Descripcion,
                    TrainerName = sessionModel.SessionTrainer.Name,
                    CategoryName = sessionModel.SessionCategory.CategoryName,
                    AvailableSlots = sessionModel.Capacity - unitOfWork.MemberSessionRepository.GetAll()
                    .Where(ms => ms.SessionId == sessionModel.Id).Count()
                };
                return sessionViewModel;
            }
            throw new Exception("Not Found Exception");
        }

        public void DeleteSession(int id)
        {
            var session = unitOfWork.SessionRepository.GetById(id);
            if (session != null)
            {
                unitOfWork.SessionRepository.Delete(session);
                unitOfWork.SaveChanges();
            }

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

        public SessionViewModel UpdateSession(int id, UpdateSessionViewModel session)
        {
            var sessionModel = unitOfWork.SessionRepository.GetById(id);
            var cat = unitOfWork.CategoryRepository.GetById(session.CategoryId);
            var trainer = unitOfWork.TrainerRepository.GetById(session.TrainerId);

            if (sessionModel == null || trainer == null || cat == null)
            {
                throw new Exception("Not Found");
            }
            sessionModel.CategoryId = cat.Id;
            sessionModel.TrainerId = trainer.Id;
            sessionModel.Capacity = session.Capacity;
            sessionModel.Updated_at = DateTime.Now;
            sessionModel.Descripcion = session.Description;
            sessionModel.StartDate = session.StartDate;
            sessionModel.EndDate = session.EndDate;

            unitOfWork.SessionRepository.Update(sessionModel);
            unitOfWork.SaveChanges();

            var sessionViewModel = new SessionViewModel
            {
                Id = sessionModel.Id,
                StartDate = sessionModel.StartDate,
                EndDate = sessionModel.EndDate,
                Capacity = sessionModel.Capacity,
                Description = sessionModel.Descripcion,
                TrainerName = sessionModel.SessionTrainer.Name,
                CategoryName = sessionModel.SessionCategory.CategoryName,
                AvailableSlots = sessionModel.Capacity - unitOfWork.MemberSessionRepository.GetAll()
                .Where(ms => ms.SessionId == sessionModel.Id).Count()
            };
            return sessionViewModel;
        }
    }

}
