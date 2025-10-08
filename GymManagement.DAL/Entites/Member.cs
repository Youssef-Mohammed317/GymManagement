﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Entites
{
    public class Member : GymUser
    {
        // JoinDate => Created_at
        public string? Photo { get; set; }

        #region RelationShips

        #region Member - HealthRecord
        public HealthRecord HealthRecord { get; set; } = null!;

        #endregion
        #region Member -MemberShip

        public ICollection<MemberShip> MemberShips { get; set; } = null!;
        #endregion
        #region Member MemberSession
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
        #endregion
    }
}
