using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Models
{
    public class Smtp
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
