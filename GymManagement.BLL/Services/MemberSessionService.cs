using GymManagement.BLL.Interfaces;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Services
{
    public class MemberSessionService : IMemberSessionService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemberSessionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
