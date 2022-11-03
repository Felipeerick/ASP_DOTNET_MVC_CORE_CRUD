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
            return View(await _context.Categories.ToListAsync());
        }

        [HttpGet]
        public IActionResult create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> store(Category data){
           if(ModelState.IsValid)
           {
                await _context.Categories.AddAsync(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }

           return View(data);
        }
    }
}