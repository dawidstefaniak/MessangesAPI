﻿// <auto-generated />
using MessangesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MessangesAPI.Migrations
{
    [DbContext(typeof(MessagesContext))]
    [Migration("20180408135513_AddedCaseAndTypeOfCrime")]
    partial class AddedCaseAndTypeOfCrime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("MessangesAPI.Entities.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OfficerId");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("RefNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ReportDate");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TypeOfCrimeId");

                    b.HasKey("CaseId");

                    b.HasAlternateKey("RefNumber")
                        .HasName("AlternateKey_RefNumber");

                    b.HasIndex("OfficerId");

                    b.HasIndex("TypeOfCrimeId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("MessangesAPI.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MessageText")
                        .HasMaxLength(500);

                    b.Property<int>("ReceiverUserId");

                    b.Property<int>("SenderUserId");

                    b.Property<DateTime>("SentDate");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessangesAPI.Entities.TypeOfCrime", b =>
                {
                    b.Property<int>("TypeOfCrimeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CrimeDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TypeOfCrimeId");

                    b.ToTable("TypesOfCrime");
                });

            modelBuilder.Entity("MessangesAPI.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<char>("UserType");

                    b.HasKey("UserId");

                    b.HasAlternateKey("UserName")
                        .HasName("AlternateKey_Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessangesAPI.Entities.Case", b =>
                {
                    b.HasOne("MessangesAPI.Entities.User", "Officer")
                        .WithMany("Cases")
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MessangesAPI.Entities.TypeOfCrime", "TypeOfCrime")
                        .WithMany("Cases")
                        .HasForeignKey("TypeOfCrimeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MessangesAPI.Entities.Message", b =>
                {
                    b.HasOne("MessangesAPI.Entities.User", "Receiver")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ReceiverUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MessangesAPI.Entities.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
