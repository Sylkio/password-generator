using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGeneratorApi.Models
{
    public class PasswordResponse
    {
        public string? Password { get; set; }
        public int Strength { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}