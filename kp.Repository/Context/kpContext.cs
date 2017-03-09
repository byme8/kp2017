using System;
using System.Collections.Generic;
using System.Text;
using kp.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace kp.Repository.Context
{
    class kpContext : DbContext
    {
		DbSet<UserEntity> Users
		{
			get;
			set;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseMySql(@"Server=localhost;database=kp;uid=root;pwd=root;");
		}
	}
}
