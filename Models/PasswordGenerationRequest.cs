using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGeneratorApi.Models
{
    public class PasswordGenerationRequest
    {
        public int Length { get; set; } = 12;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSpecialCharacters { get; set; } = true;
        public int Count { get; set; } = 1;
    }
}