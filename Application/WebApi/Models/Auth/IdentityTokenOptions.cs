using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Auth
{
    public class IdentityTokenOptions
    {
        public string aud { get; set; }

        public string iss { get; set; }

        public string iat { get; set; }

        public string nbf { get; set; }

        public string exp { get; set; }

        public string auth_time { get; set; }

        public string nonce { get; set; }

        public string sub { get; set; }

        public string upn { get; set; }

        public string unique_name { get; set; }

        public string pwd_url { get; set; }

        public string pwd_exp { get; set; }

        public string sid { get; set; }
    }
}
