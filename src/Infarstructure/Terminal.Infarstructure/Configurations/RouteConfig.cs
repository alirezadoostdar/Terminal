using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Infarstructure.Configurations;

public class RouteConfig : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Origin)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Destination)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BasePrice)
            .IsRequired();
    }
}
