using Castle.Core.Internal;
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
    public class ilaclar_tableController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: ilaclar_table
        public ActionResult Index()
        {
            return View(db.ilaclar_table.ToList());
        }

        [HttpGet]
        public ActionResult İlacYaz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ilacYaz(ilaclar_table ilac)
        {
            ilaclar_table giris;
            giris = ilac;
            giris.id = (db.ilaclar_table.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
            db.ilaclar_table.Add(giris);
            randevu_table randevu = db.randevu_table.FirstOrDefault(x => x.hasta_id == int.Parse(giris.ilac_id));
            db.randevu_table.Remove(randevu);
            db.SaveChanges();
            return RedirectToAction("DoktorPanel", "doktor_table");
        }

        // GET: ilaclar_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilaclar_table ilaclar_table = db.ilaclar_table.Find(id);
            if (ilaclar_table == null)
            {
                return HttpNotFound();
            }
            return View(ilaclar_table);
        }

        // GET: ilaclar_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ilaclar_table/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ilac_id,ilac")] ilaclar_table ilaclar_table)
        {
            if (ModelState.IsValid)
            {
                db.ilaclar_table.Add(ilaclar_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilaclar_table);
        }

        // GET: ilaclar_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilaclar_table ilaclar_table = db.ilaclar_table.Find(id);
            if (ilaclar_table == null)
            {
                return HttpNotFound();
            }
            return View(ilaclar_table);
        }

        // POST: ilaclar_table/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ilac_id,ilac")] ilaclar_table ilaclar_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilaclar_table).State = EntityState.Modified;
                var hastalik = db.hastalik.FirstOrDefault(x => x.ilac_id == ilaclar_table.ilac_id);
                randevu_table randevu = db.randevu_table.FirstOrDefault(x => x.hasta_id == hastalik.hasta_id);
                db.randevu_table.Remove(randevu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilaclar_table);
        }

        // GET: ilaclar_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilaclar_table ilaclar_table = db.ilaclar_table.Find(id);
            if (ilaclar_table == null)
            {
                return HttpNotFound();
            }
            return View(ilaclar_table);
        }

        // POST: ilaclar_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ilaclar_table ilaclar_table = db.ilaclar_table.Find(id);
            db.ilaclar_table.Remove(ilaclar_table);
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
