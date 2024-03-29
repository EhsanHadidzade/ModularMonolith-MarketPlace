﻿using AccountManagement.Domain.UserDeviceAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class UserDeviceMapping : IEntityTypeConfiguration<UserDevice>
    {
        public void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            builder.ToTable("UserDevices");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Longtitude).HasMaxLength(26);
            builder.Property(x => x.Latitude).HasMaxLength(26);

            builder.Property(x => x.Address).HasMaxLength(256);
        }
    }
}
