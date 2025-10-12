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
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(GymDbContext _dbContext) : base(_dbContext)
        {
        }

        public Member? GetByEmail(string email)
        {
            return dbContext.Members.FirstOrDefault(m => m.Email.ToUpper() == email.ToUpper());
        }
        public Member? GetByPhone(string phone)
        {
            return dbContext.Members.FirstOrDefault(m => m.Phone == phone);
        }
    }
}
