using Microsoft.AspNetCore.Mvc;
using projeto_web.Data;
using Microsoft.EntityFrameworkCore;
using projeto_web.Models;

namespace projeto_web.Controllers
{
    [Route("/Categorias/[action]")]
    public class CategoryController : Controller
    {
        private readonly ContextMysql _context;

        public CategoryController(ContextMysql value)
        {
            _context = value;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> store(Category data)
        {
           if(ModelState.IsValid)
           {
                await _context.Categories.AddAsync(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }

           return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> edit(int? id)
        {
            if(id == null){
                return NotFound();
            }

            return View(await _context.Categories.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> update(Category data)
        {
           if(ModelState.IsValid)
           {
                _context.Categories.Update(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }

           return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> destroy(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            
            if(category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }  
    }
}