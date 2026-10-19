using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagerWeb.Models.Dto;
using TaskManagerWeb.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;

namespace TaskManagerWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly TaskApiClient _client;

        public AccountController(TaskApiClient client)
        {
            _client = client;
        }
        private bool IsLoggedIn =>
         !string.IsNullOrEmpty(HttpContext.Session.GetString("JwtToken"));
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var user = await _client.RegisterAsync(dto);
            if (!user)
            {
                ModelState.AddModelError("", "Could not create User");
                return View(dto);
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var token = await _client.LoginAsync(dto);
            if (token == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(dto);

            }
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userName = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            HttpContext.Session.SetString("JwtToken", token);
            HttpContext.Session.SetString("UserName", userName ?? "");
            return RedirectToAction("Index", "Tasks");
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Login");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Login");
            var (ok, message) = await _client.ChangePasswordAsync(dto);
            if (!ok)
            {
                ModelState.AddModelError("", string.IsNullOrWhiteSpace(message)
                    ? "Could not change the password"
                    : message);
                return View(dto);
            }
            
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Login");

            var isDelete =await _client.DeleteAccountAsync();
            if (!isDelete)
            {
                TempData["Error"] = "Could not delete the account.";
                return RedirectToAction("Index", "Tasks");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Register");
                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }

}
