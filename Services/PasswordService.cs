using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Interface;
using PasswordGeneratorApi.Models;
using System.Security.Cryptography;

namespace PasswordGeneratorApi.Services
{
    public class PasswordService : IPasswordService
    {


        public PasswordService()
        {
        }

        public List<PasswordResponse> GeneratePasswords(PasswordGenerationRequest request)
        {
            var passwordList = new List<PasswordResponse>();

            for (int i = 0; i < request.Count; i++)
            {
                string newPassword = CreateSinglePassword(request);

                int strength = CalculatePasswordStrength(newPassword);

                var passwordResponse = new PasswordResponse
                {
                    Password = newPassword,
                    Strength = strength,
                    GeneratedAt = DateTime.UtcNow
                };
                passwordList.Add(passwordResponse);
            }
            return passwordList;
        }

        public string RandomPassword()
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/";

            int length = 12;


            char[] passwordChars = new char[length];
            Random random = new Random();

            int currentPosition = 0;

            passwordChars[currentPosition] = uppercaseChars[random.Next(uppercaseChars.Length)];
            currentPosition++;
            passwordChars[currentPosition] = lowercaseChars[random.Next(lowercaseChars.Length)];
            currentPosition++;
            passwordChars[currentPosition] = numberChars[random.Next(numberChars.Length)];
            currentPosition++;
            passwordChars[currentPosition] = specialChars[random.Next(specialChars.Length)];
            currentPosition++;

            StringBuilder allowedChars = new StringBuilder();
            allowedChars.Append(uppercaseChars);
            allowedChars.Append(lowercaseChars);
            allowedChars.Append(numberChars);
            allowedChars.Append(specialChars);
            string charPool = allowedChars.ToString();

            for (int i = currentPosition; i < length; i++)
            {
                passwordChars[i] = charPool[random.Next(charPool.Length)];
            }

            for (int i = 0; i < passwordChars.Length; i++)
            {
                int randomPosition = random.Next(passwordChars.Length);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[randomPosition];
                passwordChars[randomPosition] = temp;
            }
            return new string(passwordChars);
        }


        public int CalculatePasswordStrength(string password)
        {
            int score = 0;

            if (password.Length >= 8) score += 1;
            if (password.Length >= 12) score += 1;
            if (password.Length >= 16) score += 1;
            if (password.Length >= 20) score += 1;

            if (password.Any(char.IsUpper)) score += 1;
            if (password.Any(char.IsLower)) score += 1;
            if (password.Any(char.IsDigit)) score += 1;
            if (password.Any(char.IsLetterOrDigit)) score += 1;

            return score;
        }
        private string CreateSinglePassword(PasswordGenerationRequest request)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/";


            StringBuilder allowedChars = new StringBuilder();
            if (request.IncludeUppercase)
                allowedChars.Append(uppercaseChars);
            if (request.IncludeLowercase)
                allowedChars.Append(lowercaseChars);
            if (request.IncludeNumbers)
                allowedChars.Append(numberChars);
            if (request.IncludeSpecialCharacters)
                allowedChars.Append(specialChars);


            char[] passwordChars = new char[request.Length];
            Random random = new Random();

            int currentPosition = 0;

            if (request.IncludeUppercase && currentPosition < request.Length)
            {
                passwordChars[currentPosition] = uppercaseChars[random.Next(uppercaseChars.Length)];
                currentPosition++;
            }
            if (request.IncludeLowercase && currentPosition < request.Length)
            {
                passwordChars[currentPosition] = lowercaseChars[random.Next(lowercaseChars.Length)];
                currentPosition++;
            }
            if (request.IncludeNumbers && currentPosition < request.Length)
            {
                passwordChars[currentPosition] = numberChars[random.Next(numberChars.Length)];
                currentPosition++;
            }

            if (request.IncludeSpecialCharacters && currentPosition < request.Length)
            {
                passwordChars[currentPosition] = specialChars[random.Next(specialChars.Length)];
                currentPosition++;
            }

            string charPool = allowedChars.ToString();

            for (int i = currentPosition; i < request.Length; i++)
            {
                passwordChars[i] = charPool[random.Next(charPool.Length)];
            }

            for (int i = 0; i < passwordChars.Length; i++)
            {
                int randomPosition = random.Next(passwordChars.Length);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[randomPosition];
                passwordChars[randomPosition] = temp;
            }

            return new string(passwordChars);
        }
    }
}