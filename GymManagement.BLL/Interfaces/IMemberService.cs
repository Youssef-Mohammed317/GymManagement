using GymManagement.BLL.ViewModels.Member;
using GymManagement.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();

        MemberViewModel CreateMember(CreateMemberViewModel createMemberViewModel);

        MemberViewModel GetById(int id);
        MemberViewModel GetByEmail(string email);
        MemberViewModel GetByPhone(string phone);
        MemberViewModel UpdateMember(int id, CreateMemberViewModel createMemberViewModel);
        MemberViewModel DeleteById(int id);
    }
}
