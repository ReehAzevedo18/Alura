using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        [Route("produtos", Name = ListaProdutos)] //utilizando a rota para o link
        [AuthorizationFilterAttribute] //coloco para validar os controllers / criar a classe chamada FilterConfig dentro da pasta App_Start
        public ActionResult Index()
        {
                ProdutosDAO dao = new ProdutosDAO();
                IList<Produto> produtos = dao.lista();
                return View(produtos);
            
        }

        public ActionResult Form()
        {
            int idDaInformatica = 1;
            if(produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido", "Informática abaixo de 100 reais");
            }
            if (ModelState.IsValid) //se as validações colocadas na model forem verdadeiras entra no processo abaixo
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                IList<Categoria> categorias = categoriasDAO.lista();
                ViewBag.categorias = categorias;
                return View();
            }
            else
            {
                CategoriaDAO categoriaDAO = new CategoriaDAO();
                ViewBag.Categorias = categoriaDAO.listar();
                ViewBag.Produto = new Produto();
                return View("Form");

            }
           
        }

        [HttpPost] //Escondendo os valores que foram preenchidos pelo usúario.
        [ValidateAntiForgeryToken] //validando se o token do usuário logado é valido para adicionar um produto.
        public ActionResult Adiciona(Produtos produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);

            //return View();
            return RedirectToAction("Index", "Produto"); //retornando para o usuario uma action especifica

        }

        [Route("produtos/Visualiza/{produtoId}")] //configurando rotas para chamar as paginas
        public ActionResult Visualiza(int produtoId)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscarPorId(produtoId);
            ViewBag.Produto = produto;
            return View();
        }

        public ActionResult DecrementaQtde(int idProduto)
        {
            produtosDAO produtosDAO = new produtosDAO();
            Produto produto = produtosDAO.buscarPorId(id);
            produto.Quantidade--;
            produtosDAO.atualiza(produto);
            //return RedirectToAction("Index");
            return Json(produto); //retoranando para o JS
        }
    }
}