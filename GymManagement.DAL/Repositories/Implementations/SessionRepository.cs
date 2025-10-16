using GymManagement.DAL.Data.Context;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Implementations
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(GymDbContext _dbContext) : base(_dbContext)
        {
        }

        public Session GetByIdWithTrainerAndCategory(int id)
        {
            return dbContext.Sessions.Include(s => s.SessionTrainer).Include(s => s.SessionCategory).FirstOrDefault(s => s.Id == id)!;
        }
    }
}
