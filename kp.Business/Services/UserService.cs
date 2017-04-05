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
using AutoMapper;

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

			return Mapper.Map<User>(userEntity);
		}

		public IQueryable<User> Get()
		{
			return this.Context.Users.
				Select(o => Mapper.Map<User>(o));
		}

		public IQueryable<User> Get(int page, int size)
		{
			return this.Context.Users.Skip(size * page).Take(size).
				Select(o => Mapper.Map<User>(o));
		}

		public User Get(Guid id)
		{
			var entity = this.Context.Users.First(user => user.Id == id);
			return new User
			{
				Id = entity.Id,
				Login = entity.Login
			};
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
			var userEntity = this.Context.Users.FirstOrDefault(o => o.Id == user.Id);
			if (userEntity is null)
			{
				throw new BusinessException($"Entity with Id {user.Id} does not exist.");
			}

			userEntity.Login = user.Login;
			this.Context.SaveChanges();

			return Mapper.Map<User>(userEntity);
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
