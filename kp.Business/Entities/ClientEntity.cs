using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kp.Domain.Data;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public class ClientEntity : Entity
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public List<PaymentRowEntity> Payments
        {
            get;
            set;
        } = new List<PaymentRowEntity>();
    }

    internal static class ClientMapper
    {
        internal static void MapClient(this IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<ClientEntity, Client>();
            mapper.CreateMap<Client, ClientEntity>();
        }
    }
}
