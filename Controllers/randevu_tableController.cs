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
    public class randevu_tableController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: randevu_table
        public ActionResult Index()
        {
            var randevu_table = db.randevu_table.Include(r => r.hasta_table);
            return View(randevu_table.ToList());
        }

        // GET: randevu_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            randevu_table randevu_table = db.randevu_table.Find(id);
            if (randevu_table == null)
            {
                return HttpNotFound();
            }
            return View(randevu_table);
        }

        // GET: randevu_table/Create
        public ActionResult Create()
        {
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim");
            return View();
        }

        // POST: randevu_table/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hasta_id,saat")] randevu_table randevu_table)
        {
            if (ModelState.IsValid)
            {
                randevu_table.id = (db.randevu_table.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
                var aktif_hasta = Session["aktif_hasta"] as hasta_table;
                randevu_table.hasta_id = aktif_hasta.id;
                db.randevu_table.Add(randevu_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", randevu_table.hasta_id);
            return View(randevu_table);
        }

        // GET: randevu_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            randevu_table randevu_table = db.randevu_table.Find(id);
            if (randevu_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", randevu_table.hasta_id);
            return View(randevu_table);
        }

        // POST: randevu_table/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hasta_id,saat")] randevu_table randevu_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(randevu_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", randevu_table.hasta_id);
            return View(randevu_table);
        }

        // GET: randevu_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            randevu_table randevu_table = db.randevu_table.Find(id);
            if (randevu_table == null)
            {
                return HttpNotFound();
            }
            return View(randevu_table);
        }

        // POST: randevu_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            randevu_table randevu_table = db.randevu_table.Find(id);
            db.randevu_table.Remove(randevu_table);
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
