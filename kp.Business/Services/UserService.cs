using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using kp.Entities.Abstractions;
using kp.Entities.Exceptions;
using kp.Domain.Data;
using kp.Entities.Context;
using kp.Entities.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Remotion.Linq.Parsing.Structure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace kp.Entities.Services
{
	class UserService : IUserService
	{
		public UserService(kpContext context)
		{
			this.Context = context;
		}

		public kpContext Context
		{
			get;
		}

		public User Add(User user)
		{
			//TODO: Add validators
			if (user.Password is null)
			{
				throw new BusinessException("You should provide a password.");
			}

			if (string.IsNullOrWhiteSpace(user.Login))
			{
				throw new BusinessException("You should provide a correct login.");
			}

			if (this.Context.Users.Any(o => o.Login == user.Login))
			{
				throw new BusinessException("You should provide a unique login.");
			}

			var userEntity = new UserEntity
			{
				Login = user.Login,
				PasswordHash = this.GetHash(user.Password)
			};

			userEntity = this.Context.Users.Add(userEntity).Entity;
			this.Context.SaveChanges();

			//TODO: Add mapper
			return new User
			{
				Id = userEntity.Id,
				Login = user.Login
			};
		}

		public IQueryable<User> Get()
		{
			return this.Context.Users.
				Select(o => new User
				{
					Id = o.Id,
					Login = o.Login
				});
		}

		public IQueryable<User> Get(int page, int size)
		{
			return this.Context.Users.Skip(size * page).Take(size).
				Select(o => new User
				{
					Id = o.Id,
					Login = o.Login
				});
		}

		public void Remove(User entity)
		{
			//TODO: Add mapper
			var userEntity = new UserEntity
			{
				Id = entity.Id
			};

			this.Context.Users.Remove(userEntity);
			this.Context.SaveChanges();
		}

		public IEnumerable<User> SaveChanges(IEnumerable<User> users)
		{
			var results = new List<User>();
			foreach (var user in users)
			{
				if (user.Id == Guid.Empty)
				{
					results.Add(this.Add(user));
				}
				else
				{
					//TODO: Add mapper
					var userEntity = this.Context.Users.Update(new UserEntity
					{
						Id = user.Id,
						Login = user.Login
					});

					results.Add(new User
					{
						Id = userEntity.Entity.Id,
						Login = userEntity.Entity.Login
					});
				}
			}

			this.Context.SaveChanges();

			return results;
		}

		private string GetHash(string password)
		{
			using (var sha = SHA256.Create())
			{
				var passwordTextBytes = Encoding.UTF8.GetBytes(password);
				var hash = sha.ComputeHash(passwordTextBytes);
				var hashString = Encoding.ASCII.GetString(hash);
				return hashString;
			}
		}
	}
}
