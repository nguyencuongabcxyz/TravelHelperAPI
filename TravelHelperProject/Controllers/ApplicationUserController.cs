using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelHelperProject.Commons;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationSetting _appSettings;
        private IBaseUrlHelper _baseUrlHelper;
        public ApplicationUserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSetting> appSettings, IBaseUrlHelper baseUrlHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _baseUrlHelper = baseUrlHelper;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<object> PostApplicationUser(UserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                AvatarLocation = _baseUrlHelper.GetBaseUrl() + "/Images/defaultAvatar.png",
            };
            var role = new IdentityRole("User");
            await _roleManager.CreateAsync(role);
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, role.Name);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                bool isActive = Boolean.Parse((user.IsActive == null ? true : user.IsActive).ToString());
                if (!isActive)
                {
                    return NotFound(new { message = "This user is blocked!" });
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim("Role",_userManager.GetRolesAsync(user).Result[0]),
                        new Claim("IsActive",(user.IsActive==null?true:user.IsActive).ToString()),
                        new Claim("IsDeleted",(user.IsDeleted==null?false:user.IsDeleted).ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10000),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token,user });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }
        }
        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return Unauthorized();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return Unauthorized();
            }
            if(!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                return BadRequest();
            }
            else
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return Unauthorized();
                }
                return Ok();
            }
        }
    }
}