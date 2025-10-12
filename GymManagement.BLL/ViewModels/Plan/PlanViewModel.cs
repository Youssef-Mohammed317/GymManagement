﻿using GymManagement.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.BLL.ViewModels.Plan
{
    public class PlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DurationInDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

    }
}
