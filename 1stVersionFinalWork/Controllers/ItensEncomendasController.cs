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
    public class ItensEncomendasController : Controller{
        private OrdersDB db = new OrdersDB();

        // GET: ItensEncomendas
        public ActionResult Index(){
            var itensEncomenda = db.ItensEncomenda.Include(i => i.Encomenda).Include(i => i.Produto);
            return View(itensEncomenda.ToList());
        }

        // GET: ItensEncomendas/Details/5
        public ActionResult Details(int? id){
            if (id == null){
                return RedirectToAction("Index");
            }

            //Averigua se o id introduzido é válido, isto é, se o id é maior que o número de ItensEncomenda existentes
            if (id > db.ItensEncomenda.Count())
            {
                //colocar o utilizador na listagem de encomendas se fornecer id inválido
                return RedirectToAction("Index");
            }


            ItensEncomenda itensEncomenda = db.ItensEncomenda.Find(id);
            if (itensEncomenda == null){
                return HttpNotFound();
            }
            return View(itensEncomenda);
        }

        // GET: ItensEncomendas/Create
        public ActionResult Create(){
            ViewBag.EncomendaFK = new SelectList(db.Encomendas, "EncomendaID", "LocalExpedicao");
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View();
        }

        // POST: ItensEncomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Quantidade,Preco,IVA,ProdutoFK,EncomendaFK")] ItensEncomenda itensEncomenda){
            if (ModelState.IsValid){
                db.ItensEncomenda.Add(itensEncomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EncomendaFK = new SelectList(db.Encomendas, "EncomendaID", "LocalExpedicao", itensEncomenda.EncomendaFK);
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", itensEncomenda.ProdutoFK);
            return View(itensEncomenda);
        }

        // GET: ItensEncomendas/Edit/5
        public ActionResult Edit(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensEncomenda itensEncomenda = db.ItensEncomenda.Find(id);
            if (itensEncomenda == null){
                return HttpNotFound();
            }
            ViewBag.EncomendaFK = new SelectList(db.Encomendas, "EncomendaID", "LocalExpedicao", itensEncomenda.EncomendaFK);
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", itensEncomenda.ProdutoFK);
            return View(itensEncomenda);
        }

        // POST: ItensEncomendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Quantidade,Preco,IVA,ProdutoFK,EncomendaFK")] ItensEncomenda itensEncomenda){
            if (ModelState.IsValid){
                db.Entry(itensEncomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EncomendaFK = new SelectList(db.Encomendas, "EncomendaID", "LocalExpedicao", itensEncomenda.EncomendaFK);
            ViewBag.ProdutoFK = new SelectList(db.Produtos, "ProdutoID", "Nome", itensEncomenda.ProdutoFK);
            return View(itensEncomenda);
        }

        // GET: ItensEncomendas/Delete/5
        public ActionResult Delete(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensEncomenda itensEncomenda = db.ItensEncomenda.Find(id);
            if (itensEncomenda == null){
                return HttpNotFound();
            }
            return View(itensEncomenda);
        }

        // POST: ItensEncomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            ItensEncomenda itensEncomenda = db.ItensEncomenda.Find(id);
            db.ItensEncomenda.Remove(itensEncomenda);
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
