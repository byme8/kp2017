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
using kp.Business.Abstractions.Validators;

namespace kp.Entities.Services
{
	class UserService : IUserService
	{
		public UserService(IRepository<UserEntity> repository, INewEntryValidator<User> newEntryValidator)
		{
			this.Repository = repository;
			this.NewEntryValidator = newEntryValidator;
		}

		public IRepository<UserEntity> Repository
		{
			get;
		}

		public INewEntryValidator<User> NewEntryValidator
		{
			get;
		}

		public User Add(User user)
		{
			var validationResults = this.NewEntryValidator.Validate(user);
			if (!validationResults.IsValid)
			{
				throw new BusinessException(validationResults.Errors.Select(o => o.ErrorMessage).ToArray());
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
			return Mapper.Map<User>(entity);
		}

		public void Remove(Guid id)
		{
			this.Repository.Remove(id);
			this.Repository.SaveChanges();
		}

		public User Update(User user)
		{
			var userEntity = this.Repository.Entities.FirstOrDefault(o => o.Id == user.Id) ??
				throw new BusinessException($"Entity with Id {user.Id} does not exist.");

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
