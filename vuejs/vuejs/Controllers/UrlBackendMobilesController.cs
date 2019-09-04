using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vuejs.Models;

namespace vuejs.Controllers
{
    public class UrlBackendMobilesController : Controller
    {
        private _Database db = new _Database();

        // GET: UrlBackendMobiles
        public ActionResult Index()
        {
            return View(db.urlBackendMobile.ToList());
        }

        // GET: UrlBackendMobiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cod = Convert.ToInt32(id);
            UrlBackendMobile urlBackendMobile = new UrlBackendMobile().PegarPorId(db, cod);
            if (urlBackendMobile == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobile);
        }

        // GET: UrlBackendMobiles/Create
        public ActionResult Create()
        {
            UrlBackendMobile url = new UrlBackendMobile();
            return View(url);
        }

        // POST: UrlBackendMobiles/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,CNPJ,URL,PortaRetaguarda,PortaApp")] UrlBackendMobile urlBackendMobile)
        {
            if (ModelState.IsValid)
            {
                var result = new UrlBackendMobile().Inserir(db, urlBackendMobile);
                if (result)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return View(urlBackendMobile);
            }
        }

        // GET: UrlBackendMobiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cod = Convert.ToInt32(id);
            UrlBackendMobile urlBackendMobile = new UrlBackendMobile().PegarPorId(db, cod);
            if (urlBackendMobile == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobile);
        }

        // POST: UrlBackendMobiles/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,CNPJ,URL,PortaRetaguarda,PortaApp")] UrlBackendMobile urlBackendMobile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = new UrlBackendMobile().Atualizar(db, urlBackendMobile);
                    if (result)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return View(urlBackendMobile);
            }
        }

        // GET: UrlBackendMobiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cod = Convert.ToInt32(id);
            UrlBackendMobile urlBackendMobile = new UrlBackendMobile().PegarPorId(db, cod);
            if (urlBackendMobile == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobile);
        }

        // POST: UrlBackendMobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrlBackendMobile urlBackendMobile = db.urlBackendMobile.Find(id);
            db.urlBackendMobile.Remove(urlBackendMobile);
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
