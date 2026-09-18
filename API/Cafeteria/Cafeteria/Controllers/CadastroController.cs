using Cafeteria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cafeteria.Controllers
{
    public class CadastroController : Controller
    {

        private readonly CafeteriaContext _context;

        public CadastroController(CafeteriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
                return View("Index");
            }
            var usuario = new Usuario
            {
                Email = email,
                Senha = System.Text.Encoding.UTF8.GetBytes(senha)
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}
