using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kp.WebApi.Models.Requests
{
    public class TokenRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
