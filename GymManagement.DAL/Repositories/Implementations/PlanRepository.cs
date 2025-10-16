﻿using GymManagement.DAL.Data.Context;
using GymManagement.DAL.Entites;
using GymManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Implementations
{
    public class PlanRepository : GenericRepository<Plan>, IPlanRepository
    {
        public PlanRepository(GymDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
