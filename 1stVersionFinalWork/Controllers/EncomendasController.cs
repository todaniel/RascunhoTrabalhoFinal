using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1stVersionFinalWork.Models;

namespace _1stVersionFinalWork.Controllers
{
    public class EncomendasController : Controller
    {
        private OrdersDB db = new OrdersDB();

        // GET: Encomendas
        public ActionResult Index()
        {
            var encomendas = db.Encomendas.Include(e => e.Dono).Include(e => e.Jornada);
            return View(encomendas.ToList());
        }

        // GET: Encomendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomendas encomendas = db.Encomendas.Find(id);
            if (encomendas == null)
            {
                return HttpNotFound();
            }
            return View(encomendas);
        }

        // GET: Encomendas/Create
        public ActionResult Create()
        {
            ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EncomendaID,LocalExpedicao,DataExpedicao,DonoFK,JornadaFK")] Encomendas encomendas)
        {
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomendas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
            ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
            return View(encomendas);
        }

        // GET: Encomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomendas encomendas = db.Encomendas.Find(id);
            if (encomendas == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
            ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
            return View(encomendas);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EncomendaID,LocalExpedicao,DataExpedicao,DonoFK,JornadaFK")] Encomendas encomendas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomendas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
            ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
            return View(encomendas);
        }

        // GET: Encomendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomendas encomendas = db.Encomendas.Find(id);
            if (encomendas == null)
            {
                return HttpNotFound();
            }
            return View(encomendas);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomendas encomendas = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomendas);
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
