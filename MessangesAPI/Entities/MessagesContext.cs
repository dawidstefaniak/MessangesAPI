using Microsoft.EntityFrameworkCore;
using MessangesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Entities
{
    public sealed class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Case>()
                .HasOne(p => p.Officer)
                .WithMany(t => t.Cases)
                .HasForeignKey(m=> m.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Message>()
                .HasOne(p => p.Case)
                .WithMany(t => t.Messages)
                .HasForeignKey(m=> m.CaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasAlternateKey(c => c.UserName)
                .HasName("AlternateKey_Username");

            modelBuilder.Entity<Case>()
                .HasAlternateKey(c => c.RefNumber)
                .HasName("AlternateKey_RefNumber");

            

        }
        public DbSet<Case> Cases {get;set;}
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
