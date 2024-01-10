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
    public class hastaliksController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: hastaliks
        public ActionResult Index()
        {
            var hastalik = db.hastalik.Include(h => h.hasta_table);
            return View(hastalik.ToList());
        }

        // GET: hastaliks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastalik hastalik = db.hastalik.Find(id);
            if (hastalik == null)
            {
                return HttpNotFound();
            }
            return View(hastalik);
        }

        // GET: hastaliks/Create
        public ActionResult Create()
        {
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim");
            return View();
        }

        public ActionResult Teshis()
        {
            return View();
        }

        public ActionResult Teshis(hastalik hastalik)
        {
            hastalik hs = hastalik;
            hs.id = (db.hastalik.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
            randevu_table randevu = db.randevu_table.FirstOrDefault(x => x.hasta_id == hs.hasta_id);
            db.randevu_table.Remove(randevu);
            return Create(hs);
        }
        // POST: hastaliks/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,hasta_id,hastalık,detay,ilac_id")] hastalik hastalik)
        {
            if (ModelState.IsValid)
            {
                hastalik.id = (db.hastalik.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
                db.hastalik.Add(hastalik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", hastalik.hasta_id);
            hastalik.id = (db.hastalik.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
            return View(hastalik);
        }

        // GET: hastaliks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastalik hastalik = db.hastalik.Find(id);
            if (hastalik == null)
            {
                return HttpNotFound();
            }
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", hastalik.hasta_id);
            return View(hastalik);
        }

        // POST: hastaliks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hasta_id,hastalık,detay,ilac_id")] hastalik hastalik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastalik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hasta_id = new SelectList(db.hasta_table, "id", "isim", hastalik.hasta_id);
            return View(hastalik);
        }

        // GET: hastaliks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastalik hastalik = db.hastalik.Find(id);
            if (hastalik == null)
            {
                return HttpNotFound();
            }
            return View(hastalik);
        }

        // POST: hastaliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hastalik hastalik = db.hastalik.Find(id);
            db.hastalik.Remove(hastalik);
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
