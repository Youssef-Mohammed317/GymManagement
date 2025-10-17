using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public SessionService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public SessionViewModel CreateSession(CreateSessionViewModel session)
        {
            var cat = unitOfWork.CategoryRepository.GetById(session.CategoryId);
            var trainer = unitOfWork.TrainerRepository.GetById(session.TrainerId);

            if (trainer != null && cat is not null)
            {

                var sessionModel = mapper.Map<Session>(session);

                unitOfWork.SessionRepository.Create(sessionModel);
                unitOfWork.SaveChanges();

                return mapper.Map<SessionViewModel>(sessionModel);
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
            var sessions = unitOfWork.SessionRepository
                .GetAll()
                .Include(s => s.SessionTrainer)
                .Include(s => s.SessionCategory)
                .ProjectTo<SessionViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return sessions;
        }
        public SessionViewModel GetSessionById(int id)
        {

            var session = unitOfWork.SessionRepository
                .GetByIdWithTrainerAndCategory(id);

            return mapper.Map<SessionViewModel>(session);
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

            sessionModel = mapper.Map(session, sessionModel);

            unitOfWork.SessionRepository.Update(sessionModel);
            unitOfWork.SaveChanges();

            return mapper.Map<SessionViewModel>(sessionModel);
        }
    }

}
