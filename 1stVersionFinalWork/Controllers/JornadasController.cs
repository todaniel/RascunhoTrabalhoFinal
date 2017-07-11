using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWork.Models;
using FinalWork.Models;

namespace FinalWork.Controllers
{
    public class JornadasController : Controller
    {
        private FinalWork.Models.OrdersDB db = new FinalWork.Models.OrdersDB();

        // GET: Jornadas
        public ActionResult Index()
        {
            return View(db.Jornadas.ToList());
        }

        // GET: Jornadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null){
                //colocar o utilizador na listagem de Jornadas se não fornecer id
                return RedirectToAction("Index");
            }

            Jornadas jornadas = db.Jornadas.Find(id);
            if (jornadas == null){
                //colocar o utilizador na listagem de Jornadas se a jornada não existir
                return RedirectToAction("Index");
            }
            return View(jornadas);
        }


        // GET: Jornadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jornadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JornadaID,DataInicio,DataFinal,Descricao")] Jornadas jornadas)
        {

            try{
                if (ModelState.IsValid){
                    db.Jornadas.Add(jornadas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a criação da jornada!"));
            }
            

            return View(jornadas);
        }


        // GET: Jornadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null){
                //colocar o utilizador na listagem de Jornadas se não fornecer id para edição
                return RedirectToAction("Index");
            }

            Jornadas jornadas = db.Jornadas.Find(id);
            if (jornadas == null){
                //colocar o utilizador na listagem de Jornadas se a jornada não existir
                return RedirectToAction("Index");
            }
            return View(jornadas);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JornadaID,DataInicio,DataFinal,Descricao")] Jornadas jornadas)
        {

            try{
                if (ModelState.IsValid){
                    db.Entry(jornadas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a edição da jornada!"));
            }

            return View(jornadas);
        }



        // GET: Jornadas/Delete/5
        public ActionResult Delete(int? id){

            if (id == null){
                //colocar o utilizador na listagem de Jornadas se não fornecer id para eliminação
                return RedirectToAction("Index");
            }

            Jornadas jornadas = db.Jornadas.Find(id);
            if (jornadas == null){
                //colocar o utilizador na listagem de Jornadas se a jornada não existir
                return RedirectToAction("Index");
            }
            return View(jornadas);
        }

        // POST: Jornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try{
                Jornadas jornadas = db.Jornadas.Find(id);
                db.Jornadas.Remove(jornadas);
                db.SaveChanges();
            }
            catch (Exception ex){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a eliminação da jornada!"));
            }
            
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
