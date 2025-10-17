using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymManagement.BLL.Interfaces;
using GymManagement.BLL.ViewModels.Trainer;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Entites.Enums;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TrainerService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public TrainerViewModel CreateTrainer(CreateTrainerViewModel createTrainerViewModel)
        {

            bool isEmailOrPhoneExist = CheckEmailAndPhoneExist(createTrainerViewModel.Email, createTrainerViewModel.Phone);

            var values = Enum.GetValues(typeof(Specialties));

            if (!isEmailOrPhoneExist && !(values.Length > 1))
            {
                var trainer = mapper.Map<Trainer>(createTrainerViewModel);

                unitOfWork.TrainerRepository.Create(trainer);

                unitOfWork.SaveChanges();

                return mapper.Map<TrainerViewModel>(trainer);
            }
            return null!;
        }

        public TrainerViewModel DeleteById(int id)
        {
            var trainer = unitOfWork.TrainerRepository.GetById(id);

            if (trainer is not null)
            {
                if (!HasFutureSession(trainer))
                {
                    unitOfWork.TrainerRepository.Delete(trainer);
                    unitOfWork.SaveChanges();

                    return mapper.Map<TrainerViewModel>(trainer);
                }
            }
            return null!;
        }
        private bool HasFutureSession(Trainer trainer)
        {

            foreach (var session in trainer.TrainerSessions)
            {
                if (session.StartDate > DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers = unitOfWork.TrainerRepository.GetAll()
                .ProjectTo<TrainerViewModel>(mapper.ConfigurationProvider);

            return trainers;
        }

        public TrainerViewModel GetByEmail(string email)
        {
            var trainer = unitOfWork.TrainerRepository.GetByEmail(email);

            if (trainer != null)
            {

                return mapper.Map<TrainerViewModel>(trainer);
            }
            else
            {
                return null!;
            }
        }

        public TrainerViewModel GetById(int id)
        {
            var trainer = unitOfWork.TrainerRepository.GetById(id);
            if (trainer is not null)
            {
                return mapper.Map<TrainerViewModel>(trainer);
            }
            else
            {
                return null!;
            }
        }

        public TrainerViewModel GetByPhone(string phone)
        {
            var trainer = unitOfWork.TrainerRepository.GetByPhone(phone);
            if (trainer is not null)
            {
                return mapper.Map<TrainerViewModel>(trainer);
            }
            else
            {
                return null!;
            }
        }
        public TrainerViewModel UpdateTrainer(int id, CreateTrainerViewModel updateTrainerViewModel)
        {
            var trainer = unitOfWork.TrainerRepository.GetByEmail(updateTrainerViewModel.Email);
            if (trainer != null)
            {
                if (trainer.Id == id)
                {
                    trainer = unitOfWork.TrainerRepository.GetByPhone(updateTrainerViewModel.Phone);
                    if (trainer is not null)
                    {
                        if (trainer.Id == id)
                        {
                            var values = Enum.GetValues(typeof(Specialties));

                            if (!(values.Length > 1))
                            {
                                trainer = mapper.Map(updateTrainerViewModel, trainer);

                                unitOfWork.TrainerRepository.Update(trainer);

                                unitOfWork.SaveChanges();

                                return mapper.Map<TrainerViewModel>(trainer);
                            }
                        }
                    }
                }
            }
            return null!;
        }
        private bool CheckEmailAndPhoneExist(string email, string phone)
        {
            if (unitOfWork.TrainerRepository.GetByEmail(email) != null
                && unitOfWork.TrainerRepository.GetByPhone(phone) != null)
            {
                return true;
            }
            return false;
        }
    }
}
