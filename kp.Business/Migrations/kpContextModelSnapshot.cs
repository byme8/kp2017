using System;
using kp.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kp.Business.Migrations
{
    [DbContext(typeof(kpContext))]
    partial class kpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
