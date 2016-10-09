using backendAPISQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendAPISQL.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var contactModel = modelBuilder.Entity<Contact>();
            contactModel.HasKey(p => p.Id);
            contactModel.Property(p => p.FirstName).IsRequired().HasMaxLength(40);
            contactModel.Property(p => p.LastName).IsRequired().HasMaxLength(40);
            contactModel.Property(p => p.Email).IsRequired().HasMaxLength(40);
        }
    }
}