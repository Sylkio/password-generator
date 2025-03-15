using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Models;

namespace PasswordGeneratorApi.Interface
{
    public interface IPasswordService
    {
        List<PasswordResponse> GeneratePasswords(PasswordGenerationRequest request);
        int CalculatePasswordStrength(string password);

        string RandomPassword();

    }
}