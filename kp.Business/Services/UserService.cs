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
