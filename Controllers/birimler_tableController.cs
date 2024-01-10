using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Odev6.Models.Entity;

namespace Web_Odev6.Controllers
{
    public class birimler_tableController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: birimler_table
        public ActionResult Index()
        {
            return View(db.birimler_table.ToList());
        }

        // GET: birimler_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            birimler_table birimler_table = db.birimler_table.Find(id);
            if (birimler_table == null)
            {
                return HttpNotFound();
            }
            return View(birimler_table);
        }

        // GET: birimler_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: birimler_table/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bolum")] birimler_table birimler_table)
        {
            if (ModelState.IsValid)
            {
                db.birimler_table.Add(birimler_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birimler_table);
        }

        // GET: birimler_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            birimler_table birimler_table = db.birimler_table.Find(id);
            if (birimler_table == null)
            {
                return HttpNotFound();
            }
            return View(birimler_table);
        }

        // POST: birimler_table/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bolum")] birimler_table birimler_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birimler_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birimler_table);
        }

        // GET: birimler_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            birimler_table birimler_table = db.birimler_table.Find(id);
            if (birimler_table == null)
            {
                return HttpNotFound();
            }
            return View(birimler_table);
        }

        // POST: birimler_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            birimler_table birimler_table = db.birimler_table.Find(id);
            db.birimler_table.Remove(birimler_table);
            db.SaveChanges();
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
