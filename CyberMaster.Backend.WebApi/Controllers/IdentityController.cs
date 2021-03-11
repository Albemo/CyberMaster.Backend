using CyberMaster.Backend.Core.Models;
using CyberMaster.Backend.Core.ViewModels;
using CyberMaster.Backend.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CyberMaster.Backend.WebApi.Controllers
{
    public class IdentityController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IJWTTokenGeneratorService _jWTTokenGeneratorService;

        public IdentityController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
            IJWTTokenGeneratorService jWTTokenGeneratorService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jWTTokenGeneratorService = jWTTokenGeneratorService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return BadRequest("Username not found");

            var singIn = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!singIn.Succeeded)
                return BadRequest("Password is incorrect");

            var roles = await _userManager.GetRolesAsync(user);

            IList<Claim> claims = await _userManager.GetClaimsAsync(user);

            var result = new
            {
                Result = singIn,
                user.UserName,
                user.Email,
                Token = _jWTTokenGeneratorService.GenerateToken(user, roles, claims)
            };

            return Ok(result);
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!(await _roleManager.RoleExistsAsync(model.Role)))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(model.Role));
            }

            var userToCreate = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(userToCreate, model.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                // add role to user
                await _userManager.AddToRoleAsync(user, model.Role);

                var claim = new Claim("ModuleTitle", model.ModuleTitle);

                await _userManager.AddClaimAsync(user, claim);

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
