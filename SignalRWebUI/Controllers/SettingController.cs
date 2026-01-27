using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Surname = value.Surname;
            userEditDto.Username = value.UserName;
            userEditDto.Name = value.Name;
            userEditDto.Mail = value.Email;
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto dto)
        {
            if (dto.Password == dto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.Email = dto.Mail;
                user.UserName = dto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);
                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


    }
}
