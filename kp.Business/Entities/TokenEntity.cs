using AutoMapper;
using kp.Domain.Data;
using kp.Entities.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
