using kp.Business.Entities;
using kp.Entities.Data;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<TokenEntity> Tokens
        {
            get;
            set;
        }

        public DbSet<ClientEntity> Clients
        {
            get;
            set;
        }

        public DbSet<PaymentRowEntity> PaymentRows
        {
            get;
            set;
        }

        public DbSet<PaymentEntity> Payments
        {
            get;
            set;
        }

        public DbSet<PaymentKindEntity> PaymentKinds
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