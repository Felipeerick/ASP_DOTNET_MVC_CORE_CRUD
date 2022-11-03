using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projeto_web.Data;
using Microsoft.EntityFrameworkCore;
using projeto_web.Models;

namespace projeto_web.Controllers
{
    [Route("/Produtos/[action]")]
    public class ProductController : Controller
    {
        private readonly ContextMysql _context;

        public ProductController(ContextMysql value)
        {
            _context = value;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(p => p.Category).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> create(){
            ViewData["Category_id"] = new SelectList(await _context.Categories.ToListAsync(),"Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> store(Product request){
           if(ModelState.IsValid)
           {
                await _context.Products.AddAsync(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }
            ViewData["Category_id"] = new SelectList(await _context.Categories.ToListAsync(),"Id", "Name", request.Category_id);
           return View(request);
        } 

        [HttpGet]
        public async Task<IActionResult> edit(int id){
            Product product = await _context.Products.FindAsync(id);

            ViewData["Category_id"] = new SelectList(await _context.Categories.ToListAsync(),"Id", "Name", product.Category_id);
            
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> update(Product request){
           if(ModelState.IsValid)
           {
                _context.Products.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }
            ViewData["Category_id"] = new SelectList(await _context.Categories.ToListAsync(),"Id", "Name", request.Category_id);
           return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> destroy(int id){
            
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> show (int id){
            Product product = await _context.Products.FindAsync(id);

            return View(product);
        }
    }
}