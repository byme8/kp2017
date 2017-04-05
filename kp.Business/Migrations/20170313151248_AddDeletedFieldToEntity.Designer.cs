using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kp.Repositories.Context;

namespace kp.Business.Migrations
{
    [DbContext(typeof(kpContext))]
    [Migration("20170313151248_AddDeletedFieldToEntity")]
    partial class AddDeletedFieldToEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

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
        }
    }
}
