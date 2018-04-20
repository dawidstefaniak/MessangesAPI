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
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            
            modelBuilder.Entity<Message>()
                .HasOne(p => p.Receiver)
                .WithMany(t => t.MessagesReceived)
                .HasForeignKey(m => m.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Message>()
                .HasOne(p => p.Sender)
                .WithMany(t => t.MessagesSent)
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Case>()
                .HasOne(p => p.TypeOfCrime)
                .WithMany(p => p.Cases)
                .HasForeignKey(m => m.TypeOfCrimeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasAlternateKey(c => c.UserName)
                .HasName("AlternateKey_Username");

            modelBuilder.Entity<Case>()
                .HasAlternateKey(c => c.RefNumber)
                .HasName("AlternateKey_RefNumber");

            

        }
        public DbSet<Case> Cases {get;set;}
        public DbSet<TypeOfCrime> TypesOfCrime {get;set;}
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
