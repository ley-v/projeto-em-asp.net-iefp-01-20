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
    public class RegistoPagamentoesController : Controller
    {
        private ControloAvencaContext db = new ControloAvencaContext();

        // GET: RegistoPagamentoes
        public ActionResult Index()
        {
            var tRegistoPagamento = db.TRegistoPagamento.Include(r => r.Cliente).Include(r => r.Mes);
            return View(tRegistoPagamento.ToList());
        }

        // GET: RegistoPagamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistoPagamento registoPagamento = db.TRegistoPagamento.Find(id);
            if (registoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(registoPagamento);
        }

        // GET: RegistoPagamentoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome");
            ViewBag.MesId = new SelectList(db.TMes, "Id", "MesDesginacao");
            return View();
        }

        // POST: RegistoPagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Descricao,Valor,ClienteId,MesId")] RegistoPagamento registoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.TRegistoPagamento.Add(registoPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", registoPagamento.ClienteId);
            ViewBag.MesId = new SelectList(db.TMes, "Id", "MesDesginacao", registoPagamento.MesId);
            return View(registoPagamento);
        }

        // GET: RegistoPagamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistoPagamento registoPagamento = db.TRegistoPagamento.Find(id);
            if (registoPagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", registoPagamento.ClienteId);
            ViewBag.MesId = new SelectList(db.TMes, "Id", "MesDesginacao", registoPagamento.MesId);
            return View(registoPagamento);
        }

        // POST: RegistoPagamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Descricao,Valor,ClienteId,MesId")] RegistoPagamento registoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registoPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.TCliente, "Id", "Nome", registoPagamento.ClienteId);
            ViewBag.MesId = new SelectList(db.TMes, "Id", "MesDesginacao", registoPagamento.MesId);
            return View(registoPagamento);
        }

        // GET: RegistoPagamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistoPagamento registoPagamento = db.TRegistoPagamento.Find(id);
            if (registoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(registoPagamento);
        }

        // POST: RegistoPagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistoPagamento registoPagamento = db.TRegistoPagamento.Find(id);
            db.TRegistoPagamento.Remove(registoPagamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
