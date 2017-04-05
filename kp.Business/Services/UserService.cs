using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using kp.Entities.Exceptions;
using kp.Domain.Data;
using kp.Entities.Data;
using AutoMapper;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Repositories;

namespace kp.Entities.Services
{
	class UserService : IUserService
	{
		public UserService(IRepository<UserEntity> repository)
		{
			this.Repository = repository;
		}

		public IRepository<UserEntity> Repository
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

			if (this.Repository.Entities.Any(o => o.Login == user.Login))
			{
				throw new BusinessException("You should provide a unique login.");
			}

			var userEntity = new UserEntity
			{
				Login = user.Login,
				PasswordHash = this.GetHash(user.Password)
			};

			userEntity = this.Repository.Add(userEntity);
			this.Repository.SaveChanges();

			return Mapper.Map<User>(userEntity);
		}

		public IQueryable<User> Get()
		{
			return this.Repository.Entities.
				Select(o => Mapper.Map<User>(o));
		}

		public IQueryable<User> Get(int page, int size)
		{
			return this.Repository.Entities.Skip(size * page).Take(size).
				Select(o => Mapper.Map<User>(o));
		}

		public User Get(Guid id)
		{
			var entity = this.Repository.Entities.First(user => user.Id == id);
			return new User
			{
				Id = entity.Id,
				Login = entity.Login
			};
		}

		public void Remove(Guid id)
		{
			this.Repository.Remove(id);
			this.Repository.SaveChanges();
		}

		public User Update(User user)
		{
			var userEntity = this.Repository.Entities.FirstOrDefault(o => o.Id == user.Id);
			if (userEntity is null)
			{
				throw new BusinessException($"Entity with Id {user.Id} does not exist.");
			}

			userEntity.Login = user.Login;
			this.Repository.SaveChanges();

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
