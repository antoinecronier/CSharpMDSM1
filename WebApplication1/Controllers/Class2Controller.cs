using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Class2Controller : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: Class2
        public async Task<ActionResult> Index()
        {
            var class2 = db.Class2.Include(c => c.Class1).Include(c => c.Class1s);
            return View(await class2.ToListAsync());
        }

        // GET: Class2/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // GET: Class2/Create
        public ActionResult Create()
        {
            ViewBag.IdClass1 = new SelectList(db.Class1, "Id", "Data");
            List<SelectListItem> items = new List<SelectListItem>();
            using (WebApplication1Context db = new WebApplication1Context())
            {
                foreach (var item in db.Class1.ToList())
                {
                    items.Add(new SelectListItem() { Text=item.Data, Value=item.Id.Value.ToString()});
                }
                
                ViewBag.Class1s = items;
            }
            return View();
        }

        // POST: Class2/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Item1,Item2,Item3,Item4,Item4Bis,IdClass1,Class1sIds")] Class2 class2)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in class2.Class1sIds)
                {
                    class2.Class1s.Add(db.Class1.Find(item));
                }
                db.Class2.Add(class2);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdClass1 = new SelectList(db.Class1, "Id", "Data", class2.IdClass1);
            List<SelectListItem> items = new List<SelectListItem>();
            using (WebApplication1Context db = new WebApplication1Context())
            {
                foreach (var item in db.Class1.ToList())
                {
                    items.Add(new SelectListItem() { Text = item.Data, Value = item.Id.Value.ToString() });
                }

                ViewBag.Class1s = items;
            }
            return View(class2);
        }

        // GET: Class2/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClass1 = new SelectList(db.Class1, "Id", "Data", class2.IdClass1);
            return View(class2);
        }

        // POST: Class2/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Item1,Item2,Item3,Item4,Item4Bis,IdClass1")] Class2 class2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class2).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdClass1 = new SelectList(db.Class1, "Id", "Data", class2.IdClass1);
            return View(class2);
        }

        // GET: Class2/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // POST: Class2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Class2 class2 = await db.Class2.FindAsync(id);
            db.Class2.Remove(class2);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
