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
    public class GymUserConfigrations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("GymUserVaildEmailCheck", "Email Like '_%@_%._%'");
                tb.HasCheckConstraint("GymUserVaildPhoneCheck", "Phone Like '01%' and Phone Not Like '%[^0-9]%'");



            });

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.OwnsOne(x => x.Adderss, addressBuilder =>
            {
                addressBuilder.Property(x => x.Streat)
                            .HasColumnName("Streat")
                            .HasColumnType("varchar")
                            .HasMaxLength(30);

                addressBuilder.Property(x => x.City)
                            .HasColumnName("City")
                            .HasColumnType("varchar")
                            .HasMaxLength(30);

                addressBuilder.Property(x => x.BuildingNumber)
                            .HasColumnName("BuildingNumber");
            });
        }
    }
}
