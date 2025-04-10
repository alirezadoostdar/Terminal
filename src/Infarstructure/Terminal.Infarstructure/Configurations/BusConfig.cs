﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Infarstructure.Configurations;

public class BusConfig : IEntityTypeConfiguration<Bus>
{
    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Title).IsRequired().HasMaxLength(200);

        builder.Property(m => m.Capacity)
            .IsRequired();

        builder.Property(m => m.Model)
            .IsRequired();

        builder.Property(m => m.Rate)
            .IsRequired();

    }
}
