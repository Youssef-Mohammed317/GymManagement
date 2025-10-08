﻿using GymManagement.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Data.Configrations
{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {

        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200);
            builder.Property(x => x.Price)
                .HasPrecision(10, 2);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("PlanDurationInDaysCheck", "DurationInDays Between 1 and 365");
            });
        }
    }
}
