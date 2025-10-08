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
    public class MemberSessionRepository : GenericRepository<MemberSession>, IMemberSessionRepository
    {
        public MemberSessionRepository(GymDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
