using Prodap.Models;
using Prodap.Repositorio;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Prodap.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio _repositorio;
        private CentroDistribuicaoRepositorio _repositorioCD;

        // GET: Produtos
        public ActionResult ObterListaProdutos()
        {
            _repositorio = new ProdutosRepositorio();
            ModelState.Clear();
            return View(_repositorio.ListarProdutos());
        }

        [HttpGet]
        public ActionResult IncluirProdutos()
        {
  
                return View(); 
        }

        [HttpPost]
        public ActionResult IncluirProdutos(Produtos _Prodobj) 
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ProdutosRepositorio();
                    _repositorioCD = new CentroDistribuicaoRepositorio();

                   var CENTRODISTRIBUICAO = _repositorioCD.ListarCentroDistribuicao().FirstOrDefault(T => T.NOME.ToUpper() == _Prodobj.CENTRODISTRIBUICAO.ToUpper());
                       
                   if (_repositorio.AddProdutos(_Prodobj,CENTRODISTRIBUICAO.ID)) 
                   {
                       ViewBag.Mensagem = "Produto Cadastrado com sucesso.";                            
                   }                  
                   else
                    {
                        ViewBag.Mensagem = "Centro de Distribuição ja existe.";                    

                    }
            }
                return RedirectToAction("ObterListaProdutos");
            }
            catch(Exception)
            {
                return RedirectToAction("ObterListaProdutos");
            }        
        
        }

        [HttpGet]
        public ActionResult AlterarProdutos()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AlterarProdutos( string ID)
        {
            _repositorio = new ProdutosRepositorio();

            return View( _repositorio.ListarProdutos().Find(T => T.ID_PRODUTO  == ID) );
        }

        [HttpPost]
        public ActionResult AlterarProdutos(int ID,Produtos _Prod0bj)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    _repositorio = new ProdutosRepositorio();
                    _repositorioCD = new CentroDistribuicaoRepositorio();

                    var CENTRODISTRIBUICAO = _repositorioCD.ListarCentroDistribuicao().FirstOrDefault(T => T.NOME.ToUpper() == _Prodobj.CENTRODISTRIBUICAO.ToUpper());


                    if (_repositorio.UpdProdutos(_Prod0bj, CENTRODISTRIBUICAO.ID))
                    {
                        ViewBag.Mensagem = "Produto alterado com sucesso.";                
                    }
                    else
                    {
                        ViewBag.Mensagem = "Erro ao alterar Produto.";           
                    }
                  
                }

            return RedirectToAction("ObterListaProdutos");
            }
            catch (Exception)
            {
                return RedirectToAction("ObterListaProdutos");
            }

        }

        [HttpPost]
        public ActionResult DeletarProdutos(string ID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ProdutosRepositorio();

                    if (_repositorio.DeleteProdutos(ID))
                    {
                        ViewBag.Mensagem = "Produto deletado  com sucesso.";
                    }

                }
                return View();
            }
            catch (Exception)
            {
                return View();

            }

        }

    }
}