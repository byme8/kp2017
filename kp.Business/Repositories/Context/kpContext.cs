using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kp.Business.Entities;
using kp.Entities.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using kp.Domain.Data;

namespace kp.Repositories.Context
{
    public class kpContext : DbContext
    {
        public DbSet<UserEntity> Users
        {
            get;
            set;
        }

        public DbSet<UserRoleEntity> UserRoles
        {
            get;
            set;
        }

        public DbSet<RoleEntity> Roles
        {
            get;
            set;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=kp;Trusted_Connection=True;");
        }
    }
}
