using CrudCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Diagnostics;

namespace CrudCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext applicationDb)
        {
            this.db = applicationDb;
        }

        public IActionResult List()
        {
            var data = db.Studentes.ToList();
            return View(data);
        }


        public async Task<IActionResult> Details(int Id)
        {
            var data = await db.Studentes.FirstOrDefaultAsync(x => x.Id == Id);
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Add(s);
                db.SaveChanges();
                ViewBag.message = "Data Save Successfully";
                return RedirectToAction("List", "Home");
            }
            else
            {
                ViewBag.message1 = "Data not Save";
            }
            return View();
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || db.Studentes == null)
            {
                return NotFound();
            }
            var data = await db.Studentes.FindAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int? id, Student u)
        {
            if (ModelState.IsValid)
            {
                db.Update(u);
                await db.SaveChangesAsync();
                ViewBag.message = "Update Successfully";
                return RedirectToAction("List", "Home");

            }
            else
            {
                ViewBag.messag1 = "Update Unsuccessfully";
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Studentes == null)
            {
                return NotFound();
            }
            var data = await db.Studentes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var data = await db.Studentes.FindAsync(id);
            if (data != null) 
            {
                db.Studentes.Remove(data);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("List", "Home");
        }

    }
}
