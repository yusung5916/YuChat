using System.Text;
using BLL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace YuChat.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            var result = new Dictionary<string, string>();
            var user = _userService.Get(loginModel.Email);
            if (user == null) return NotFound("查無該帳號");

            var basePass = Convert.ToBase64String(Encoding.UTF8.GetBytes(loginModel.Pass));
            if (user.BasePass != basePass) return NotFound("密碼錯誤");

            HttpContext.Session.SetString("UserID", user.UserId.ToString());
            return Ok("登入成功");
        }

        [HttpPost]
        public IActionResult Register([FromBody] LoginModel registerUser)
        {
            var result = new Dictionary<string, string>();
            var user = _userService.Get(registerUser.Email);
            if (user != null) return BadRequest("該帳號已被註冊");

            var basePass = Convert.ToBase64String(Encoding.UTF8.GetBytes(registerUser.Pass));
            user = new User()
            {
                UserName = registerUser.Name,
                BasePass = basePass,
                Email = registerUser.Email,
                RegisterDate = DateTime.Now
            };
            _userService.Create(user);
            HttpContext.Session.SetString("UserID", user.UserId.ToString());

            return Ok("註冊成功");
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
    }
}
