using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWork.Models;

namespace FinalWork.Controllers{
    public class MensagensController : Controller{
        private OrdersDB db = new OrdersDB();

        // GET: Mensagens
        public ActionResult Index(){
            var mensagens = db.Mensagens.Include(m => m.DonoDaMensagem).Include(m => m.Tipo);
            return View(mensagens.ToList());
        }

        // GET: Mensagens/Details/5
        public ActionResult Details(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagens mensagens = db.Mensagens.Find(id);
            if (mensagens == null){
                return HttpNotFound();
            }
            return View(mensagens);
        }

        // GET: Mensagens/Create
        public ActionResult Create(){
            ViewBag.DonoDaMensagemFK = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.TipoFK = new SelectList(db.TiposMsg, "TipoID", "Descricao");
            return View();
        }

        // POST: Mensagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensagemID,Texto,Data,Respondida,DataResposta,TextoResposta,DonoDaMensagemFK,TipoFK")] Mensagens mensagens){
            if (ModelState.IsValid){
                db.Mensagens.Add(mensagens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonoDaMensagemFK = new SelectList(db.Clientes, "ClienteID", "Nome", mensagens.DonoDaMensagemFK);
            ViewBag.TipoFK = new SelectList(db.TiposMsg, "TipoID", "Descricao", mensagens.TipoFK);
            return View(mensagens);
        }

        // GET: Mensagens/Edit/5
        public ActionResult Edit(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagens mensagens = db.Mensagens.Find(id);
            if (mensagens == null){
                return HttpNotFound();
            }
            ViewBag.DonoDaMensagemFK = new SelectList(db.Clientes, "ClienteID", "Nome", mensagens.DonoDaMensagemFK);
            ViewBag.TipoFK = new SelectList(db.TiposMsg, "TipoID", "Descricao", mensagens.TipoFK);
            return View(mensagens);
        }

        // POST: Mensagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensagemID,Texto,Data,Respondida,DataResposta,TextoResposta,DonoDaMensagemFK,TipoFK")] Mensagens mensagens){
            if (ModelState.IsValid){
                db.Entry(mensagens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonoDaMensagemFK = new SelectList(db.Clientes, "ClienteID", "Nome", mensagens.DonoDaMensagemFK);
            ViewBag.TipoFK = new SelectList(db.TiposMsg, "TipoID", "Descricao", mensagens.TipoFK);
            return View(mensagens);
        }

        // GET: Mensagens/Delete/5
        public ActionResult Delete(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagens mensagens = db.Mensagens.Find(id);
            if (mensagens == null){
                return HttpNotFound();
            }
            return View(mensagens);
        }

        // POST: Mensagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Mensagens mensagens = db.Mensagens.Find(id);
            db.Mensagens.Remove(mensagens);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing){
            if (disposing){
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
