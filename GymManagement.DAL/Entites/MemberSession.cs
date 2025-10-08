﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Entites
{
    public class MemberSession : BaseEntity
    {
        // booking date => created_at
        public bool IsAttended { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public Session Session { get; set; }
        public int SessionId { get; set; }
    }
}
