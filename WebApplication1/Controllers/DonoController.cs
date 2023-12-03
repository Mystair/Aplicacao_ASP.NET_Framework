using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DonoController : Controller
    {
        private Etecpf2023DanielPedroEntities db = new Etecpf2023DanielPedroEntities();

        // GET: Dono
        public ActionResult Index()
        {
            return View(db.tb_dono.ToList());
        }

        // GET: Dono/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_dono tb_dono = db.tb_dono.Find(id);
            if (tb_dono == null)
            {
                return HttpNotFound();
            }
            return View(tb_dono);
        }

        // GET: Dono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dono/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Idade,Profissao")] tb_dono tb_dono)
        {
            if (ModelState.IsValid)
            {
                db.tb_dono.Add(tb_dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_dono);
        }

        // GET: Dono/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_dono tb_dono = db.tb_dono.Find(id);
            if (tb_dono == null)
            {
                return HttpNotFound();
            }
            return View(tb_dono);
        }

        // POST: Dono/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Idade,Profissao")] tb_dono tb_dono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_dono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_dono);
        }

        // GET: Dono/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_dono tb_dono = db.tb_dono.Find(id);
            if (tb_dono == null)
            {
                return HttpNotFound();
            }
            return View(tb_dono);
        }

        // POST: Dono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_dono tb_dono = db.tb_dono.Find(id);
            db.tb_dono.Remove(tb_dono);
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
