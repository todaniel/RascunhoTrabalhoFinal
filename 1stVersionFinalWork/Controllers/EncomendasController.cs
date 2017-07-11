using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FinalWork.Models;

namespace FinalWork.Controllers
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
        public ActionResult Details(int? id){
            if (id == null){
                //colocar o utilizador na listagem de encomendas se não fornecer id
                return RedirectToAction("Index");
            }

            // *************************************************************
            // código inicial
            // *************************************************************
            // Encomendas encomenda = db.Encomendas
            //                           .Include(e => e.Dono)
            //                           .Include(e => e.Jornada)
            //                           .Where(e => e.EncomendaID == id)
            //                           .FirstOrDefault();
            // *************************************************************


            /* *************************************************************
			  Nova forma de obter os dados das encomendas.
			  obtém-se uma Lista de Itens da Encomenda, que estão relacionados
			  com a Encomenda identificada através do  parâmetro de entrada 'id'
			  São efetados relacionamentos diretos com os ItensEncomenda
			   - é feita a inclusão com a 'tabela' dos Produtos
				- é feita a inclusão com a 'tabela' das Encomendas
			  São efetuados relacionamentos indiretos com os ItensEncomenda
			   - inclusão dos dados do Dono
				- inclusão dos dados da Jornada
			 *************************************************************** */
            var descricaoEncomenda = db.ItensEncomenda
                                     .Include(ie => ie.Produto)
                                     .Include(ie => ie.Encomenda)
                                     .Include(e => e.Encomenda.Dono)
                                     .Include(e => e.Encomenda.Jornada)
                                     .Where(ie => ie.EncomendaFK == id);


            if (descricaoEncomenda == null){
                //colocar o utilizador na listagem de encomendas se não existir dados (Encomendas)
                return RedirectToAction("Index");
            }

            //Averigua se o id introduzido é válido, isto é, se o id é maior que o número de encomendas existentes
            if (id > db.Encomendas.Count())
            {
                //colocar o utilizador na listagem de encomendas se fornecer id inválido
                return RedirectToAction("Index");
            }

            return View(descricaoEncomenda); // envio da Lista de ItensEncomenda => alteração nos dados da View
        }


        // GET: Encomendas/Create
        public ActionResult Create(){
            ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao");
            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocalExpedicao,DataExpedicao,DonoFK,JornadaFK")] Encomendas encomendas){

            //determinar que ID atribuir-se-á a uma encomenda nova a ser criada
            int nextID = 0;

            try{
                nextID = db.Encomendas.Max(e => e.EncomendaID) + 1;
            }
            catch (Exception){
                //caso ainda não haja encomendas criadas então o nextID é zero por isso o próximo será um
                nextID = 1;
            }
            //associar o nextID à idetificação das Encomendas (EncomendaID)
            encomendas.EncomendaID = nextID;

            try
            {
                if (ModelState.IsValid) //confirma se dados estão conformes
                {
                    db.Encomendas.Add(encomendas); //adicionar nova encomenda
                    db.SaveChanges(); //guardar as alterações efetuadas

                    //return RedirectToAction("Edit");//coloca utilizador no inicio
                    return RedirectToAction("Edit", new { id = nextID });
                }

                //ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
                //ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
                //return View(encomendas); 
            }
            catch (Exception ex){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a operação!"));
            }
            return View(encomendas);//coloca utilizador na View Create, caso haja problemass 
        }



        // GET: Encomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null){
                //colocar o utilizador na listagem de encomendas se não fornecer id
                return RedirectToAction("Index");
            }

            if(id > db.Encomendas.Count()){
                //colocar o utilizador na listagem de encomendas se fornecer id inválido
                return RedirectToAction("Index");
            }

            Encomendas encomendas = db.Encomendas.Find(id);
            if (encomendas == null){
                ModelState.AddModelError("", string.Format("Impossível efetuar qualquer edição!! Não existem encomendas registadas."));
            }

            try{
                ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
                ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
            }
            catch (Exception){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a operação!"));
                //return RedirectToAction("Index");
            }

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

            try{

                ViewBag.DonoFK = new SelectList(db.Clientes, "ClienteID", "Nome", encomendas.DonoFK);
                ViewBag.JornadaFK = new SelectList(db.Jornadas, "JornadaID", "Descricao", encomendas.JornadaFK);
            }
            catch (Exception){
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a operação!"));
            }
            
            return View(encomendas);
        }

        // GET: Encomendas/Delete/5
        public ActionResult Delete(int? id){
            if (id == null){
                //colocar o utilizador na listagem de encomendas se não fornecer id
                return RedirectToAction("Index");
            }


            // *************************************************************
            // código inicial #*#
            // *************************************************************
            Encomendas encomenda = db.Encomendas
                                      .Include(e => e.Dono)
                                      .Include(e => e.Jornada)
                                      .Where(e => e.EncomendaID == id)
                                      .FirstOrDefault();
            // *************************************************************

            Encomendas encomendas = db.Encomendas.Find(id);
            if (encomendas == null){
                return RedirectToAction("Index");
            }
            return View(encomendas);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomendas encomendas = db.Encomendas.Find(id);

            try
            {
                //especificar (argumento do remove) que encomenda será eliminada
                db.Encomendas.Remove(encomendas);
                //efetivar a eliminação
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", string.Format("Um erro ocorrido impediu a eliminação da Encomenda!"));
                //retorna a view com os dados da encomenda
                return View(encomendas);
            }

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
