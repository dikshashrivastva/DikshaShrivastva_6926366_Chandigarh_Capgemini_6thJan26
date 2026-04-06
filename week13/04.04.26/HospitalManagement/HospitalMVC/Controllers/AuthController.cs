using System.Security.Claims;
using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _clientFactory.CreateClient("HospitalAPI");
            var response = await client.PostAsync("api/auth/login",
                ApiHelper.ToJsonContent(new { model.Email, model.Password }));

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            var auth = await ApiHelper.DeserializeAsync<AuthResponse>(response);
            if (auth == null) { ModelState.AddModelError("", "Login failed."); return View(model); }

            // Store JWT in session
            HttpContext.Session.SetString("JwtToken", auth.Token);
            HttpContext.Session.SetInt32("UserId", auth.UserId);
            HttpContext.Session.SetString("UserRole", auth.Role);
            HttpContext.Session.SetString("UserName", auth.FullName);

            // Cookie auth for MVC
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, auth.FullName),
                new(ClaimTypes.Email, model.Email),
                new(ClaimTypes.Role, auth.Role),
                new("UserId", auth.UserId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            TempData["Success"] = $"Welcome back, {auth.FullName}!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _clientFactory.CreateClient("HospitalAPI");
            var response = await client.PostAsync("api/auth/register",
                ApiHelper.ToJsonContent(new
                {
                    model.FullName,
                    model.Email,
                    model.Password,
                    model.Role
                }));

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "Registration failed. Email may already be in use.");
                return View(model);
            }

            TempData["Success"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => View();

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var client = _clientFactory.CreateClient("HospitalAPI");
            ApiHelper.SetAuthToken(client, token!);

            var response = await client.GetAsync("api/auth/users");
            var users = new List<UserViewModel>();
            if (response.IsSuccessStatusCode)
                users = await ApiHelper.DeserializeAsync<List<UserViewModel>>(response) ?? new();

            return View(users);
        }
    }
}