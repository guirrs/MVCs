using Mercado.Entities;
using Mercado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mercado.Controllers
{
    public class HomeController : Controller
    {
        private readonly MercadoContext _context;

        public HomeController(MercadoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> items = _context.Items.OrderByDescending(i => i.ItemId).ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult CadastrarItem(string Item, int quantidade)
        {
            if (string.IsNullOrEmpty(Item) || quantidade <= 0)
            {
                // Handle invalid input, e.g., return an error view or redirect with an error message
                return RedirectToAction("Index");
            }

            Item newItem = new Item
            {
                NomeItem = Item,
                Quantidade = quantidade
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult DeletarItem(int itemId)
        {
            var item = _context.Items.Find(itemId);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Item item)
        {
            var itemBanco = _context.Items.Find(item.ItemId);

            if (itemBanco == null)
            {
                return NotFound();
            }

            itemBanco.NomeItem = item.NomeItem;
            itemBanco.Quantidade = item.Quantidade;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
