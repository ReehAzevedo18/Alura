﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            //Dicionario do C#
            object valorNaSession = Session["contador"];
            int contador = Convert.ToInt32(valorNaSession);
            contador++;
            Session["contador"] = contador;
            return View(contador);
        }
    }
}