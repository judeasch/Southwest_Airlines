﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Southwest_Airlines.Data.Models;

public partial class FastpassContext : IdentityDbContext<IdentityUser>
{
    public FastpassContext()
    {
    }

    public FastpassContext(DbContextOptions<FastpassContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("CUSTOMERS");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Login).WithMany(p => p.Customers).HasForeignKey(d => d.LoginId);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.ToTable("FLIGHTS");

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Destination).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("LOGINS");

            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.ToTable("SEATS");

            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.SeatNumber).HasMaxLength(50);

            entity.HasOne(d => d.Flight).WithMany(p => p.Seats)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("TICKETS");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.PricePaid).HasColumnType("money");
            entity.Property(e => e.SeatId).HasColumnName("SeatID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Flight).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
