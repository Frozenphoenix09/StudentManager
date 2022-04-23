using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using StudentManager.Model.Model.UserModel;
using StudentManager.Service.Mapper;
using StudentManager.Service.Service;
using StudentManager.WebApp.Utilities;
using System.Security.Claims;

namespace StudentManager.WebApp.Controllers
{
    public class AccoutController : Controller
    {

        private IUserService _userService;
        private readonly IToastNotification _toastNotification;
        public AccoutController(IUserService userService , IToastNotification toastNotification)
        {
            _userService = userService;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            var model = new UserModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var userEntity = model.MapToEntity();

                userEntity.Salt = Utilities.Utilities.GetRandomKey();
                userEntity.PasswordHash = (model.Password + userEntity.Salt).ToMD5();
                var result = _userService.Insert(userEntity);
                if (result != null)
                {
                    
                    _toastNotification.AddSuccessToastMessage("Tạo mới thành công !");
                    return RedirectToAction("Login");
                }
            }
            _toastNotification.AddErrorToastMessage("Tạo mới thất bại !");
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            var model = new UserModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                var user = _userService.GetByUserName(model.UserName);
                if (user != null)
                {
                    model.Password = (model.Password + user.Salt).ToMD5();
                    if (_userService.Verify(model, out message))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(ClaimTypes.Email,user.Email),
                            new Claim("Role","Admin")
                        };
                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                         await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                        _toastNotification.AddSuccessToastMessage(message);
                        return RedirectToAction("Index", "Home");
                    }
                    _toastNotification.AddErrorToastMessage(message);
                    return View();
                }
                _toastNotification.AddErrorToastMessage("Đăng nhập thất bại !");
                return View();
            }
            _toastNotification.AddErrorToastMessage("Đăng nhập thất bại !");
            return View();
        }
    }
}
