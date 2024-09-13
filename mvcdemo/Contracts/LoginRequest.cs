using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcdemo.Contracts
{
    public class LoginRequest
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}