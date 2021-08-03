using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControloAvenca1.Models;
using ControloAvenca1.DAL;
using ControloAvenca1.ViewModel;
using System.Data.Entity;
using System.Net;

namespace ControloAvenca1.Controllers
{
    public class RegistoPorClienteController : Controller
    {
        // GET: RegistoPorCliente
        ControloAvencaContext db = new ControloAvencaContext();
        //int idA = 1;
        public ActionResult Index(int? id)
        {
            var viewModel = new ClientePagamentos();
            
            //leva equipas para a View:
            viewModel.Clientes = db.TCliente.ToList();
            viewModel.RegistoPagamentos = db.TRegistoPagamento.ToList();
            viewModel.Meses = db.TMes.ToList();

            ViewBag.CLIENTECLICADO = id;

            //if (id != null)
            //idA = (int)id;


            //ViewBag.NOMECLIENTE = "qwq";



            return View(viewModel);
        }


        // EDITAR -----------------------------------------------------------------------------------------------------------
        public ActionResult Edit(int? id)
        {
            int idCliente = db.TRegistoPagamento.Find(id).ClienteId;
            ViewBag.NOMECLIENTE = db.TCliente.Find(idCliente).Nome;

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



        // DELETE -----------------------------------------------------------------------------------------------------------
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // CREATE -----------------------------------------------------------------------------------------------------------

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
    }
}