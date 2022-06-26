using System.Collections.Generic;
using bsis3a_webapp.Data;
using bsis3a_webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace bsis3a_webapp.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<item> itemlist = _db.items;
            return View(itemlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        

        [HttpPost]
        public IActionResult Create(item item)
        {
            if(ModelState.IsValid)
            {
                _db.items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _db.items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }

         [HttpPost]
        public IActionResult Edit(item item)
        {
            if(ModelState.IsValid)
            {
                _db.items.Update(item);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _db.items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var item = _db.items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            _db.items.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");            
        }


    } 
}