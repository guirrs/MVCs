using Mercado.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Mercado.Controllers
{
    public class LoginController : Controller
    {
        private readonly MercadoContext _context;
        public LoginController(MercadoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult LoginUsuario(string email, string senha)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.ErrorMessage = "Email e senha são obrigatórios.";
                return View("Index");
            }

            byte[] senhaCriptograficado = Encoding.UTF8.GetBytes(senha);

            if (_context.Usuarios.Any(u => u.Email == email && u.Senha == senhaCriptograficado))
            {
                ViewBag.SuccessMessage = "Login realizado com sucesso.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email ou senha incorretos.";
                return View("Index");
            }
        }
    }
}
