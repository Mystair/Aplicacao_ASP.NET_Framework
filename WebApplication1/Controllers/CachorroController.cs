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
    public class CachorroController : Controller
    {
        private Etecpf2023DanielPedroEntities db = new Etecpf2023DanielPedroEntities();

        // GET: Cachorro
        public ActionResult Index()
        {
            var tb_cachorro = db.tb_cachorro.Include(t => t.tb_dono);
            return View(tb_cachorro.ToList());
        }

        // GET: Cachorro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cachorro tb_cachorro = db.tb_cachorro.Find(id);
            if (tb_cachorro == null)
            {
                return HttpNotFound();
            }
            return View(tb_cachorro);
        }

        // GET: Cachorro/Create
        public ActionResult Create()
        {
            ViewBag.DonoId = new SelectList(db.tb_dono, "Id", "Nome");
            return View();
        }

        // POST: Cachorro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Idade,Raca,DonoId")] tb_cachorro tb_cachorro)
        {
            if (ModelState.IsValid)
            {
                db.tb_cachorro.Add(tb_cachorro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonoId = new SelectList(db.tb_dono, "Id", "Nome", tb_cachorro.DonoId);
            return View(tb_cachorro);
        }

        // GET: Cachorro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cachorro tb_cachorro = db.tb_cachorro.Find(id);
            if (tb_cachorro == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonoId = new SelectList(db.tb_dono, "Id", "Nome", tb_cachorro.DonoId);
            return View(tb_cachorro);
        }

        // POST: Cachorro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Idade,Raca,DonoId")] tb_cachorro tb_cachorro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_cachorro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonoId = new SelectList(db.tb_dono, "Id", "Nome", tb_cachorro.DonoId);
            return View(tb_cachorro);
        }

        // GET: Cachorro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cachorro tb_cachorro = db.tb_cachorro.Find(id);
            if (tb_cachorro == null)
            {
                return HttpNotFound();
            }
            return View(tb_cachorro);
        }

        // POST: Cachorro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_cachorro tb_cachorro = db.tb_cachorro.Find(id);
            db.tb_cachorro.Remove(tb_cachorro);
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
