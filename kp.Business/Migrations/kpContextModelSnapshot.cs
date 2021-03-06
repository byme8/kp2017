﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kp.Repositories.Context;

namespace kp.Business.Migrations
{
    [DbContext(typeof(kpContext))]
    partial class kpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kp.Business.Entities.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("kp.Business.Entities.PaymentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid>("PaymentKindId");

                    b.Property<Guid?>("PaymentRowEntityId");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid>("UserId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PaymentKindId");

                    b.HasIndex("PaymentRowEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("kp.Business.Entities.PaymentKindEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PaymentKinds");
                });

            modelBuilder.Entity("kp.Business.Entities.PaymentRowEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid>("PaymentKindId");

                    b.Property<DateTime>("StartDate");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PaymentKindId");

                    b.ToTable("PaymentRows");
                });

            modelBuilder.Entity("kp.Business.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("kp.Business.Entities.TokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("kp.Business.Entities.UserRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("kp.Entities.Data.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("kp.Business.Entities.PaymentEntity", b =>
                {
                    b.HasOne("kp.Business.Entities.PaymentKindEntity", "PaymentKind")
                        .WithMany()
                        .HasForeignKey("PaymentKindId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kp.Business.Entities.PaymentRowEntity")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentRowEntityId");

                    b.HasOne("kp.Business.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kp.Business.Entities.PaymentRowEntity", b =>
                {
                    b.HasOne("kp.Business.Entities.ClientEntity", "Client")
                        .WithMany("Payments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kp.Business.Entities.PaymentKindEntity", "PaymentKind")
                        .WithMany()
                        .HasForeignKey("PaymentKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kp.Business.Entities.TokenEntity", b =>
                {
                    b.HasOne("kp.Entities.Data.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kp.Business.Entities.UserRoleEntity", b =>
                {
                    b.HasOne("kp.Business.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kp.Entities.Data.UserEntity", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
