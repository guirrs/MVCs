
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly BibliotecaContext _context;

        public HomeController(BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var livros = _context.Livros.ToList();
            return View(livros);
        }

        [HttpPost]
        public IActionResult CadastrarLivro(string nomeLivro, string descricao)
        {

            if(string.IsNullOrEmpty(nomeLivro) || string.IsNullOrEmpty(descricao))
            {
                ModelState.AddModelError(string.Empty, "Todos os campos são obrigatórios.");
                return View("Index");
            }

            if(_context.Livros.Any(l => l.NomeLivro == nomeLivro))
            {
                ModelState.AddModelError(string.Empty, "Já existe um livro com esse nome.");
                return View("Index");
            }


            _context.Livros.Add(new Livro
            {
                NomeLivro = nomeLivro,
                Descricao = descricao,
            });

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPut]
        public IActionResult AtualizarLivro(Guid livroId, string nomeLivro, string descricao)
        {
            if (string.IsNullOrEmpty(nomeLivro) || string.IsNullOrEmpty(descricao))
            {
                ModelState.AddModelError(string.Empty, "Todos os campos são obrigatórios.");
                return View("Index");
            }

            if (_context.Livros.Any(l => l.NomeLivro == nomeLivro))
            {
                ModelState.AddModelError(string.Empty, "Já existe um livro com esse nome.");
                return View("Index");
            }

            var livro = _context.Livros.FirstOrDefault(l => l.LivroId == livroId);
            if (livro == null)
            {
                return NotFound();
            }
            livro.NomeLivro = nomeLivro;
            livro.Descricao = descricao;
            _context.SaveChanges();

            return View();
        }

        [HttpPost]
        public IActionResult ExcluirLivro(Guid livroId)
        {
            var livro = _context.Livros.FirstOrDefault(l => l.LivroId == livroId);
            if (livro == null)
            {
                return NotFound();
            }
            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
