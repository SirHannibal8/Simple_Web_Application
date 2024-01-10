    
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Security;
using Web_Odev6.Models.Entity;

namespace Web_Odev6.Controllers
{
    
    public class doktor_tableController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: doktor_table
        
        public ActionResult Index()
        {
            return View(db.doktor_table.ToList());
        }

        // GET: doktor_table/Details/5
        [HttpGet]
        public ActionResult Doktor()
        {
            return View();
        }

   
        [HttpPost]
        public ActionResult Doktor(doktor_table doktor)
        {
            var giris = db.doktor_table.FirstOrDefault(x=>x.kullaniciadi == doktor.kullaniciadi);
            if(giris.parola == doktor.parola)
            {
                FormsAuthentication.SetAuthCookie(doktor.kullaniciadi,false);
                return RedirectToAction("DoktorPanel","doktor_table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doktor_table doktor_table = db.doktor_table.Find(id);
            if (doktor_table == null)
            {
                return HttpNotFound();
            }
            return View(doktor_table);
        }

        // GET: doktor_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: doktor_table/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,isim,soyisim,bolum,seviye,tecrube,kullaniciadi,parola")] doktor_table doktor_table)
        {
            if (ModelState.IsValid)
            {
                db.doktor_table.Add(doktor_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doktor_table);
        }

        // GET: doktor_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doktor_table doktor_table = db.doktor_table.Find(id);
            if (doktor_table == null)
            {
                return HttpNotFound();
            }
            return View(doktor_table);
        }

        // POST: doktor_table/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,isim,soyisim,bolum,seviye,tecrube,kullaniciadi,parola")] doktor_table doktor_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doktor_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doktor_table);
        }

        // GET: doktor_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doktor_table doktor_table = db.doktor_table.Find(id);
            if (doktor_table == null)
            {
                return HttpNotFound();
            }
            return View(doktor_table);
        }

        // POST: doktor_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doktor_table doktor_table = db.doktor_table.Find(id);
            db.doktor_table.Remove(doktor_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DoktorPanel()
        {
            return View();
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
