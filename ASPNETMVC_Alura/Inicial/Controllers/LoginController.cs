﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(String login, String senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario usuario = dao.Busca(login, senha);
            if(usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}