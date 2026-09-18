using Cafeteria.Entities;
using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cafeteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly CafeteriaContext _context;

        public HomeController(CafeteriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Item> itens = _context.Items.ToList();
            return View(itens);
        }

        [HttpPost]
        public IActionResult CadastrarItem(string nome, decimal preco, string descricao, IFormFile imagem)
        {
            if (string.IsNullOrEmpty(nome) || preco <= 0 || string.IsNullOrEmpty(descricao))
            {
                ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
                return View("Index");
            }

            var Item = new Item
            {
                NomeItem = nome,
                Preco = preco,
                Descricao = descricao
            };

            if(imagem != null && imagem.Length > 0)
            {
                using(var ms = new MemoryStream())
                {
                    imagem.CopyTo(ms);
                    Item.Imagem = ms.ToArray();
                }
            }

            _context.Items.Add(Item);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletarItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(int id, string nome, decimal preco, string descricao)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                item.NomeItem = nome;
                item.Preco = preco;
                item.Descricao = descricao;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
