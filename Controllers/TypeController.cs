using bsis3a_webapp.Data;
using bsis3a_webapp.Models;
using bsis3a_webapp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bsis3a_webapp.Controllers
{
    public class TypeController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public TypeViewModel TypeVM {get; set;}


        public TypeController(ApplicationDbContext db)
        {
            _db = db;
            TypeVM = new TypeViewModel()
            {
                items = _db.items.ToList(),
                type = new Models.type()
            };
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var type = _db.types.Include(m=>m.item);
            return View(type);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(TypeVM);
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost()
        {
            if(ModelState.IsValid)
            {
                _db.types.Add(TypeVM.type);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TypeVM);            
        }

        

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost(int Id)
        {
            if(ModelState.IsValid)
            {
                _db.types.Update(TypeVM.type);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TypeVM);            
        }

          [HttpGet]
        public IActionResult Delete(int Id)
        {
            TypeVM.type = _db.types.Include(m=>m.item).SingleOrDefault(m=>m.Id == Id);
            if(TypeVM.type == null)
            {
                return NotFound();
            }
            return View(TypeVM);
        }

         [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var type = _db.types.Find(id);
            if(type == null)
            {
                 return NotFound();
            }
              _db.types.Remove(type);
             _db.SaveChanges();
                return RedirectToAction("Index");        
        }

    }
}