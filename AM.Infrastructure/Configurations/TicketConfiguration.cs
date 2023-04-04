﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new {
                t.FlightFk, 
                t.PassengerFk });
            //association de ticket avec flight et passenger onetomany
            builder.HasOne(t => t.Flight).WithMany(f => f.Tickets).HasForeignKey(f=>f.FlightFk);
            builder.HasOne(t => t.Passenger).WithMany(f => f.Tickets).HasForeignKey(f=>f.PassengerFk);
        }
    }
}
