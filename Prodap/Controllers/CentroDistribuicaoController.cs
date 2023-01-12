using Prodap.Models;
using Prodap.Repositorio;
using System;
using System.Web.Mvc;

namespace Prodap.Controllers
{
    public class CentroDistribuicaoController : Controller
    {
        private CentroDistribuicaoRepositorio _repositorio;
        
        // GET: CentroDistribuicao
        public ActionResult ObterListaCentroDistribuicao()
        {
            _repositorio = new CentroDistribuicaoRepositorio();
            ModelState.Clear();
            return View(_repositorio.ListarCentroDistribuicao());
        }

        [HttpGet]
        public ActionResult IncluirCentroDistribuicao()
        {
  
                return View(); 
        }

        [HttpPost]
        public ActionResult IncluirCentroDistribuicao(CentroDistribuicao _CdObj) 
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new CentroDistribuicaoRepositorio();

                    if (_repositorio.AddCentroDistribuicao(_CdObj)) 
                    {
                        ViewBag.Mensagem = "Centro de Distribuição Cadastrado com sucesso.";
                    }                  

                }
                return View();
            }
            catch(Exception)
            {
                return View();
                
            }        
        
        }

        [HttpGet]
        public ActionResult AlterarCentroDistribuicao( int ID)
        {
            _repositorio = new CentroDistribuicaoRepositorio();

            return View( _repositorio.ListarCentroDistribuicao().Find(T => T.ID  == ID) );
        }

        [HttpPost]
        public ActionResult AlterarCentroDistribuicao(int ID,CentroDistribuicao _CdObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new CentroDistribuicaoRepositorio();

                    if (_repositorio.UpdCentroDistribuicao(_CdObj))
                    {
                        ViewBag.Mensagem = "Centro de Distribuição alterado com sucesso.";
                    }

                }
                return View();
            }
            catch (Exception)
            {
                return View();

            }

        }

        [HttpPost]
        public ActionResult DeletarCentroDistribuicao(int ID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new CentroDistribuicaoRepositorio();

                    if (_repositorio.DeleteCentroDistribuicao(ID))
                    {
                        ViewBag.Mensagem = "Centro de Distribuição deletado  com sucesso.";
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