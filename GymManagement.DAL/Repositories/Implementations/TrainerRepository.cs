using GymManagement.DAL.Context;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Implementations
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(GymDbContext _dbContext) : base(_dbContext)
        {
        }

        public Trainer GetByEmail(string email)
        {
            return dbContext.Trainers.FirstOrDefault(t => t.Email.ToUpper() == email.ToUpper())!;
        }

        public Trainer GetByPhone(string phone)
        {
            return dbContext.Trainers.FirstOrDefault(t => t.Phone == phone)!;
        }
    }
}
