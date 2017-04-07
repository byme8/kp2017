﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=kp;Trusted_Connection=True;");
        }
	}
}
