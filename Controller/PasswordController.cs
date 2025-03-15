using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Interface;
using PasswordGeneratorApi.Models;
using PasswordGeneratorApi.Services;

namespace PasswordGeneratorApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController(IPasswordService passwordService) : ControllerBase
    {
        [HttpPost("GetPassword")]
        public ActionResult<List<PasswordResponse>> GeneratePasswords(PasswordGenerationRequest request)
        {
            if (request.Length < 4)
            {
                return BadRequest("Password length must be at least 4 characters");
            }

            var passwords = passwordService.GeneratePasswords(request);
            return Ok(passwords);
        }

        [HttpGet("RandomPassword")]
        public IActionResult GetPassword()
        {
            string generatedPassword = passwordService.RandomPassword();
            return Ok(new { password = generatedPassword });
        }
    }
}