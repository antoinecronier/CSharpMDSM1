﻿using System;
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
    public class Class1Controller : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: Class1
        public async Task<ActionResult> Index()
        {
            return View(await db.Class1.ToListAsync());
        }

        // GET: Class1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class1 class1 = await db.Class1.FindAsync(id);
            if (class1 == null)
            {
                return HttpNotFound();
            }
            return View(class1);
        }

        // GET: Class1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Data")] Class1 class1)
        {
            if (ModelState.IsValid)
            {
                db.Class1.Add(class1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(class1);
        }

        // GET: Class1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class1 class1 = await db.Class1.FindAsync(id);
            if (class1 == null)
            {
                return HttpNotFound();
            }
            return View(class1);
        }

        // POST: Class1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Data")] Class1 class1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(class1);
        }

        // GET: Class1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class1 class1 = await db.Class1.FindAsync(id);
            if (class1 == null)
            {
                return HttpNotFound();
            }
            return View(class1);
        }

        // POST: Class1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Class1 class1 = await db.Class1.FindAsync(id);
            db.Class1.Remove(class1);
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
