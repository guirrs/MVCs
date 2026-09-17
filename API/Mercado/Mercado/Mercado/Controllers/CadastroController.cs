using Mercado.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Controllers
{
    public class CadastroController : Controller
    {
        private readonly MercadoContext _context;
        public CadastroController(MercadoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro(string email, string senha)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.ErrorMessage = "Email e senha são obrigatórios.";
                return View("Index");
            }

            if (_context.Usuarios.Any(u => u.Email == email))
            {
                ViewBag.ErrorMessage = "Email já cadastrado.";
                return View("Index");
            }

            Usuario user = new Usuario
            {
                Email = email,
                Senha = System.Text.Encoding.UTF8.GetBytes(senha)
            };

           _context.Usuarios.Add(user);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
