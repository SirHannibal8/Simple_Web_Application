using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_Odev6.Models.Entity;

namespace Web_Odev6.Controllers
{
    public class hasta_tableController : Controller
    {
        private Web_OdevEntities3 db = new Web_OdevEntities3();

        // GET: hasta_table
        public ActionResult Index()
        {
            return View(db.hasta_table.ToList());
        }

        [HttpGet]
        public ActionResult Hasta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hasta(hasta_table hasta)
        {
            var giris = db.hasta_table.FirstOrDefault(x => x.TC_No == hasta.TC_No);
            if (giris.paroa == hasta.paroa && giris != null)
            {
                Session["aktif_hasta"] = giris;
                FormsAuthentication.SetAuthCookie(hasta.TC_No, false);
                return RedirectToAction("HastaPanel", "hasta_table");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult HastaPanel()
        {
            var aktif_hasta = Session["aktif_hasta"] as hasta_table;
            return View(aktif_hasta);
        }

        // GET: hasta_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hasta_table hasta_table = db.hasta_table.Find(id);
            if (hasta_table == null)
            {
                return HttpNotFound();
            }
            return View(hasta_table);
        }

        // GET: hasta_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hasta_table/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,isim,soyisim,TC_No,cinsiyet,yas,paroa")] hasta_table hasta_table)
        {
            if (ModelState.IsValid)
            {
                hasta_table.id = (db.hasta_table.OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0) + 1;
                db.hasta_table.Add(hasta_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hasta_table);
        }

        // GET: hasta_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hasta_table hasta_table = db.hasta_table.Find(id);
            if (hasta_table == null)
            {
                return HttpNotFound();
            }
            return View(hasta_table);
        }

        // POST: hasta_table/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,isim,soyisim,TC_No,cinsiyet,yas,paroa")] hasta_table hasta_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hasta_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hasta_table);
        }

        // GET: hasta_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hasta_table hasta_table = db.hasta_table.Find(id);
            if (hasta_table == null)
            {
                return HttpNotFound();
            }
            return View(hasta_table);
        }

        // POST: hasta_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hasta_table hasta_table = db.hasta_table.Find(id);
            db.hasta_table.Remove(hasta_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HastaRandevu()
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
