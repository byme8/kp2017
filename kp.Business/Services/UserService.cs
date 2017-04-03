using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using kp.Entities.Abstractions;
using kp.Entities.Exceptions;
using kp.Domain.Data;
using kp.Entities.Context;
using kp.Entities.Data;
using kp.Business.Entities;

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

		public void Remove(Guid id)
		{
			var userEntity = new UserEntity
			{
				Id = id
			};

			this.Context.Users.Remove(userEntity);
			this.Context.SaveChanges();
		}

		public User Update(User user)
		{
			var entity = this.Context.Users.FirstOrDefault(o => o.Id == user.Id);
			if (entity is null)
			{
				throw new BusinessException($"Entity with Id {user.Id} does not exist.");
			}

			entity.Login = user.Login;
			this.Context.SaveChanges();

			//TODO: Add mapper
			return new User
			{
				Id = entity.Id,
				Login = entity.Login
			};
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
