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

        public TrainerService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public TrainerViewModel CreateTrainer(CreateTrainerViewModel createTrainerViewModel)
        {

            bool isEmailOrPhoneExist = CheckEmailAndPhoneExist(createTrainerViewModel.Email, createTrainerViewModel.Phone);

            var values = Enum.GetValues(typeof(Specialties));

            if (!isEmailOrPhoneExist && !(values.Length > 1))
            {
                var trainer = new Trainer
                {
                    Name = createTrainerViewModel.Name,
                    Email = createTrainerViewModel.Email,
                    Phone = createTrainerViewModel.Phone,
                    DateOfBirth = createTrainerViewModel.DateOfBirth,
                    Gender = createTrainerViewModel.Gender,
                    Adderss = new Adderss
                    {
                        BuildingNumber = createTrainerViewModel.BuildingNumber,
                        City = createTrainerViewModel.City,
                        Streat = createTrainerViewModel.Streat,
                    },
                    Specialties = createTrainerViewModel.Specialties,
                    Created_at = DateTime.Now,
                };
                unitOfWork.TrainerRepository.Create(trainer);

                unitOfWork.SaveChanges();

                return new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    Specialties = trainer.Specialties.ToString()
                };
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

                    return new TrainerViewModel
                    {
                        Id = trainer.Id,
                        Name = trainer.Name,
                        Email = trainer.Email,
                        Phone = trainer.Phone,
                        Specialties = trainer.Specialties.ToString()
                    };
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
            var trainers = unitOfWork.TrainerRepository.GetAll().Select(trainer => new TrainerViewModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialties = trainer.Specialties.ToString()
            });
            return trainers;
        }

        public TrainerViewModel GetByEmail(string email)
        {
            var trainer = unitOfWork.TrainerRepository.GetByEmail(email);

            if (trainer != null)
            {

                return new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    Specialties = trainer.Specialties.ToString()
                };
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
                return new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    Specialties = trainer.Specialties.ToString()
                };
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
                return new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    Email = trainer.Email,
                    Phone = trainer.Phone,
                    Specialties = trainer.Specialties.ToString(),
                };
            }
            else
            {
                return null!;
            }
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
        public TrainerViewModel UpdateTrainer(int id, CreateTrainerViewModel createTrainerViewModel)
        {
            var trainer = unitOfWork.TrainerRepository.GetByEmail(createTrainerViewModel.Email);
            if (trainer != null)
            {
                if (trainer.Id == id)
                {
                    trainer = unitOfWork.TrainerRepository.GetByPhone(createTrainerViewModel.Phone);
                    if (trainer is not null)
                    {
                        if (trainer.Id == id)
                        {
                            var values = Enum.GetValues(typeof(Specialties));

                            if (!(values.Length > 1))
                            {
                                trainer.Email = createTrainerViewModel.Email;
                                trainer.Phone = createTrainerViewModel.Phone;
                                trainer.DateOfBirth = createTrainerViewModel.DateOfBirth;
                                trainer.Gender = createTrainerViewModel.Gender;

                                trainer.Adderss.BuildingNumber = createTrainerViewModel.BuildingNumber;
                                trainer.Adderss.City = createTrainerViewModel.City;
                                trainer.Adderss.Streat = createTrainerViewModel.Streat;
                                trainer.Specialties = createTrainerViewModel.Specialties;
                                trainer.Updated_at = DateTime.Now;

                                unitOfWork.TrainerRepository.Update(trainer);

                                unitOfWork.SaveChanges();

                                return new TrainerViewModel
                                {
                                    Id = trainer.Id,
                                    Name = trainer.Name,
                                    Email = trainer.Email,
                                    Phone = trainer.Phone,
                                    Specialties = trainer.Specialties.ToString()
                                };
                            }
                        }
                    }
                }
            }
            return null!;
        }
    }
}
