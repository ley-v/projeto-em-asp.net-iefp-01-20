using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControloAvenca1.DAL;
using ControloAvenca1.Models;

namespace ControloAvenca1.Controllers
{
    public class AvencasController : Controller
    {
        private ControloAvencaContext db = new ControloAvencaContext();

        // GET: Avencas
        public ActionResult Index()
        {
            var tAvenca = db.TAvenca.Include(a => a.Cliente);
            return View(tAvenca.ToList());
        }

        // GET: Avencas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avenca avenca = db.TAvenca.Find(id);
            if (avenca == null)
            {
                return HttpNotFound();
            }
            return View(avenca);
        }

        // GET: Avencas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome");
            return View();
        }

        // POST: Avencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,ClienteId,Data")] Avenca avenca)
        {
            if (ModelState.IsValid)
            {
                db.TAvenca.Add(avenca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", avenca.ClienteId);
            return View(avenca);
        }

        // GET: Avencas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avenca avenca = db.TAvenca.Find(id);
            if (avenca == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", avenca.ClienteId);
            return View(avenca);
        }

        // POST: Avencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,ClienteId,Data")] Avenca avenca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avenca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", avenca.ClienteId);
            return View(avenca);
        }

        // GET: Avencas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avenca avenca = db.TAvenca.Find(id);
            if (avenca == null)
            {
                return HttpNotFound();
            }
            return View(avenca);
        }

        // POST: Avencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avenca avenca = db.TAvenca.Find(id);
            db.TAvenca.Remove(avenca);
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
