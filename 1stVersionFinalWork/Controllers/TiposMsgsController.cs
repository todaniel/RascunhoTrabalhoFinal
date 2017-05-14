using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1stVersionFinalWork.Models;

namespace _1stVersionFinalWork.Controllers{
    public class TiposMsgsController : Controller{
        private OrdersDB db = new OrdersDB();

        // GET: TiposMsgs
        public ActionResult Index(){
            return View(db.TiposMsg.ToList());
        }

        // GET: TiposMsgs/Details/5
        public ActionResult Details(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMsg tiposMsg = db.TiposMsg.Find(id);
            if (tiposMsg == null){
                return HttpNotFound();
            }
            return View(tiposMsg);
        }

        // GET: TiposMsgs/Create
        public ActionResult Create(){
            return View();
        }

        // POST: TiposMsgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoID,Descricao")] TiposMsg tiposMsg){
            if (ModelState.IsValid){
                db.TiposMsg.Add(tiposMsg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposMsg);
        }

        // GET: TiposMsgs/Edit/5
        public ActionResult Edit(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMsg tiposMsg = db.TiposMsg.Find(id);
            if (tiposMsg == null){
                return HttpNotFound();
            }
            return View(tiposMsg);
        }

        // POST: TiposMsgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoID,Descricao")] TiposMsg tiposMsg){
            if (ModelState.IsValid){
                db.Entry(tiposMsg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposMsg);
        }

        // GET: TiposMsgs/Delete/5
        public ActionResult Delete(int? id){
            if (id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposMsg tiposMsg = db.TiposMsg.Find(id);
            if (tiposMsg == null){
                return HttpNotFound();
            }
            return View(tiposMsg);
        }

        // POST: TiposMsgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id){
            TiposMsg tiposMsg = db.TiposMsg.Find(id);
            db.TiposMsg.Remove(tiposMsg);
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
