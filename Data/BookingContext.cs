﻿using BookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Models;

namespace BookingSystem.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<IntegrationType> IntegrationTypes { get; set; }
        public DbSet<BookingIntegration> BookingIntegrations { get; set; }
        public DbSet<BookingSystem.Models.BookingModel> BookingModel { get; set; } = default!;
    }
}
