using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using FraxControl.Models;
using PruebaEntityFrameworkCore.Services;

namespace FraxControl.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context, 
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            this._logger = logger;
        }
        

        [AllowAnonymous]
        public IActionResult Registry()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registry(RegistryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("El modelo es invalido");
                return View(model);
            }

            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            this._logger.LogInformation("Se guarda a la base de datos");
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string message = null)
        {
            if (message is not null)
            {
                ViewData["message"] = message;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

        // Verificar si el usuario existe
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "El usuario no existe. Por favor, registre una nueva cuenta.");
                return View(model);
            }
            
        // Intentar iniciar sesión
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.Remember.Value, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Nombre de usuario o password incorrecto");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult List()
        {
            var userList = _context.Users.Select(x => new UserViewModel
            {
                Username = x.UserName,
                Email = x.Email,
                Confirmed = x.EmailConfirmed
            }).ToList();

            var userListViewModel = new UserListViewModel
            {
                UserList = userList
            };

            return View(userListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> HacerAdmin(string email)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario is null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(usuario, MyConstants.RolAdmin);
            return RedirectToAction("List", new { Message = "Rol asignado correctamente a " + email });
        }

        [HttpPost]
        public async Task<IActionResult> RemoverAdmin(string email)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario is null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(usuario, MyConstants.RolAdmin);
            return RedirectToAction("List", new { Message = "Rol removido correctamente a " + email });
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}
