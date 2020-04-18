using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Inicial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Código da regra de negocio da aplicação
            return View(); //responsavel de mandar as informaççoes para o usuario
        }

       
    }
}