using System;
using System.Linq;
using AutoMapper;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Entities;
using kp.Business.Helpers;
using kp.Domain.Data;
using kp.Entities.Data;
using kp.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace kp.Business.Services
{
    public class TokenService : ITokenService
    {
        public TokenService(IRepository<TokenEntity> tokens, IRepository<UserEntity> users)
        {
            this.Tokens = tokens;
            this.Users = users;
        }

        public IRepository<TokenEntity> Tokens
        {
            get;
        }

        public IRepository<UserEntity> Users
        {
            get;
        }

        public Token Get(Guid id)
        {
            return Mapper.Map<Token>(this.Tokens.Get().Include(o => o.User).First(o => o.Id == id));
        }

        public Token Get(string login, string password)
        {
            var user = this.Users.Get().FirstOrDefault(o => o.Login == login && o.PasswordHash == HashHelper.GetHash(password))
                ?? throw new BusinessException("User not found");

            var token = new TokenEntity
            {
                User = user,
                ExpireDate = DateTime.Now.AddDays(1)
            };
            token = this.Tokens.Add(token);
            this.Tokens.SaveChanges();

            return Mapper.Map<Token>(token);
        }

        public bool IsExpired(Guid id)
        {
            return this.Get(id).ExpireDate < DateTime.Now;
        }
    }
}