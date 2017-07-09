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
    public class ProdutosController : Controller{
        private OrdersDB db = new OrdersDB();

        // GET: Produtos
        public ActionResult Index(){
            return View(db.Produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null){
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create(){
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,Nome,Tipo,Descricao,Preco,IVA")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState["Preco"].Errors.Count == 1 && ModelState["Preco"].Errors[0].ErrorMessage.Contains("is not valid for"))
                {
                    ModelState["Preco"].Errors.Clear();
                    ModelState["Preco"].Errors.Add("Introduza um valor decimal com vírgula.");
                }

                return View(produtos);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null){
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,Nome,Tipo,Descricao,Preco,IVA")] Produtos produtos){
            if (ModelState.IsValid){
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null){
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            Produtos produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
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
