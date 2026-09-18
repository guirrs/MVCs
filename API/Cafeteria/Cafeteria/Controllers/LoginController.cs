using Cafeteria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class LoginController : Controller
    {
        private readonly CafeteriaContext _context;

        public LoginController(CafeteriaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(senha))
            {
                return RedirectToAction("Index");
            }

            var senhaDigitada = System.Text.Encoding.UTF8.GetBytes(senha);

            Usuario user = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
                if (user.Senha.SequenceEqual(senhaDigitada))
                    return RedirectToAction("Index", "Home");

                else return RedirectToAction("Index");
            }
        }
    }
}
