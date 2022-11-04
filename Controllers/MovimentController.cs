using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projeto_web.Data;
using Microsoft.EntityFrameworkCore;
using projeto_web.Models;
using projeto_web.Helpers;

namespace projeto_web.Controllers
{
    [Route("/Movimentações/[action]")]
    
    public class MovimentController : Controller
    {
        private readonly ContextMysql _context;

        public MovimentController(ContextMysql context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moviments.Include(p => p.Product).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> create()
        {
            ViewData["Product_id"] = new SelectList(await _context.Products.ToListAsync(), "Id", "Name");
            
            return View();
        }

        public async Task<IActionResult> store(Moviment data)
        {
            data.DateMoviment = DateTime.Now.ToString();

            ViewData["Product_id"] = new SelectList(await _context.Products.ToListAsync(), "Id", "Name", data.Product_id);

            if(ModelState.IsValid)
            {   
                var product = await _context.Products.FindAsync(data.Product_id);

                if(data.NameMoviment == "ENTRADA")
                {
                    product.Quantity = product.Quantity + data.Quantity;
                    
                    _context.Products.Update(product);
                }
                else if(data.NameMoviment == "SAIDA")
                {
                    product.Quantity = product.Quantity - data.Quantity;
                    
                    _context.Products.Update(product);
                }

                await _context.Moviments.AddAsync(data);
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        public async Task<IActionResult> edit(int id)
        {
            Moviment moviment = await _context.Moviments.FindAsync(id);

            if(moviment != null)
            {
                ViewData["Product_id"] = new SelectList(await _context.Products.ToListAsync(), "Id", "Name", moviment.Product_id);

                return View(moviment);
            }

           return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> update(Moviment data)
        {
            data.DateMoviment = DateTime.Now.ToString();

            if(ModelState.IsValid)
            {
                _context.Moviments.Update(data);
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Product_id"] = new SelectList(await _context.Products.ToListAsync(), "Id", "Name", data.Product_id);
            
            return View(data);
        }

        public async Task<IActionResult> destroy(int id)
        {
            Moviment moviment = await _context.Moviments.FindAsync(id);

            if(moviment != null)
            {
                _context.Remove(moviment);
                
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}