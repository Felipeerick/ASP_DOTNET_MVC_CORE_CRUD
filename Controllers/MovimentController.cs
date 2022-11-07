using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projeto_web.Data;
using Microsoft.EntityFrameworkCore;
using projeto_web.Models;


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
        public async Task<IActionResult> Index(string search)
        {
            ViewData["CurrentFilter"] = search;

            var moviments = from m in _context.Moviments select m;

            if(!String.IsNullOrEmpty(search)){
                moviments = moviments.Where(s => s.NameMoviment.Contains(search) || s.Description.Contains(search));
            }

            return View(await moviments.Include(p => p.Product).AsNoTracking().Take(7).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> create()
        {
            ViewData["Product_id"] = new SelectList(await _context.Products.AsNoTracking().ToListAsync(), "Id", "Name");
            
            return View();
        }

        public async Task<IActionResult> store(Moviment data)
        {
            data.DateMoviment = DateTime.Now;

            ViewData["Product_id"] = new SelectList(await _context.Products.AsNoTracking().ToListAsync(), "Id", "Name", data.Product_id);

            if(ModelState.IsValid)
            {   
                var product = await _context.Products.FindAsync(data.Product_id);

                switch(data.NameMoviment)
                {
                    case "ENTRADA":
                    product.Quantity = product.Quantity + data.Quantity;
                    _context.Products.Update(product);
                    break;
                
                    case "SAIDA":
                    product.Quantity = product.Quantity - data.Quantity;
                    _context.Products.Update(product);
                    break;
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
                ViewData["Product_id"] = new SelectList(await _context.Products.AsNoTracking().ToListAsync(), "Id", "Name", moviment.Product_id);

                return View(moviment);
            }

           return NotFound();
        }

        public async Task<IActionResult> update(Moviment data)
        {
            data.DateMoviment = DateTime.Now;

            if(ModelState.IsValid)
            {
                _context.Moviments.Update(data);
                
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Product_id"] = new SelectList(await _context.Products.AsNoTracking().ToListAsync(), "Id", "Name", data.Product_id);
            
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