using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using kp.Business.Abstractions;
using kp.Business.Exceptions;
using kp.Domain.Data;
using kp.Repository.Abstractions;
using kp.Repository.Data;

namespace kp.Business.Services
{
	class UserService : IUserService
	{
		public UserService(IRepository<UserEntity> users)
		{
			this.Users = users;
		}

		public IRepository<UserEntity> Users
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

			if (this.Users.GetAll().Any(o => o.Login == user.Login))
			{
				throw new BusinessException("You should provide a unique login.");
			}

			var userEntity = new UserEntity
			{
				Login = user.Login,
				PasswordHash = this.GetHash(user.Password)
			};

			userEntity = this.Users.Add(userEntity);
			this.Users.SaveChanges();

			//TODO: Add mapper
			return new User
			{
				Id = userEntity.Id,
				Login = user.Login
			};
		}

		private string GetHash(string password)
		{
			using (var sha = SHA256.Create())
			{
				var passwordTextBytes = Encoding.UTF8.GetBytes(password);
				var hash = sha.ComputeHash(passwordTextBytes);
				var hashString = Encoding.UTF8.GetString(hash);
				return hashString;
			}
		}
	}
}
