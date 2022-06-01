using CPTralix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPTralix.Controllers
{
    public class FacCpController : Controller
    {
        public ModelFact modelFact = new ModelFact();
        public DataTable detalleFacturas(string fact)
        {
            return this.modelFact.getDatosFacturas(fact);//this.modelFact.getDatosFacturas(fact);
        }
        public DataTable getDatosCPAGDOC(string identificador)
        {
            return this.modelFact.getDatosCPAGDOC(identificador);
        }
        public DataTable getDatosCPAGDOCTR(string identificador)
        {
            return this.modelFact.getDatosCPAGDOCTR(identificador);
        }
        public DataTable getDatosCPAGDOCTRL(string identificador, string foliocpag)
        {
            return this.modelFact.getDatosCPAGDOCTRL(identificador, foliocpag);
        }
        public DataTable getDatosMaster(string identificador)
        {
            return this.modelFact.getDatosMaster(identificador);
        }
        // GET: FacCp
        public ActionResult Index()
        {
            return View();
        }
    }
}