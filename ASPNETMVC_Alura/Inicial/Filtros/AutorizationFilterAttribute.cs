using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Inicial.Filtros
{
    public class AutorizationFilterAttribute : ActionFilterAttribute

    {
        //verifica o código que está aqui antes de executar o controller
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            //Se o usuario for nulo, ele será redirecionado para a tela de login
            if(usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { Controller = "Login", Action = "Index" }
                    )
               );
            }
        }
    }
}