using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLibrary;
using myLibrary.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace mySystem.Controllers
{

    public class UsersController : Controller
    {
        private readonly postgresContext _context;

        public UsersController(postgresContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,surName,email,password,IsValid")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        
        [HttpGet]
        public IActionResult Login()
        {
            User user = new User();
            return View(user);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {


            if (ModelState.IsValid)
            {
                
                var checkUser = _context.User.Where(m => m.name == user.name && m.password == user.password).FirstOrDefault();
                user.IsValid = false;

                if (checkUser != null)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.name)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Vehicles");
                }else
                {
                    ModelState.AddModelError(string.Empty, "Bilgilerinizi Kontrol Edin.");

                }

            }
 
                return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Users");
        }


    }
}
