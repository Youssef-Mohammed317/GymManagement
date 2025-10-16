using GymManagement.BLL.ViewModels.SessionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();
        SessionViewModel GetSessionById(int id);

        void DeleteSession(int id);

        SessionViewModel CreateSession(CreateSessionViewModel session);
        SessionViewModel UpdateSession(int id, UpdateSessionViewModel session);

    }
}
