using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using kp.Domain.Data;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class TokenEntity : Entity
    {
        public Guid UserId
        {
            get;
            set;
        }

        [ForeignKey(nameof(UserId))]
        public UserEntity User
        {
            get;
            set;
        }

        public DateTime ExpireDate
        {
            get;
            set;
        }
    }

    internal static class TokenMapper
    {
        internal static void MapToken(this IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<TokenEntity, Token>();
            mapper.CreateMap<Token, TokenEntity>();
        }
    }
}