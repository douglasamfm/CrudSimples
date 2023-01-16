using Prodap.Models;
using Prodap.Repositorio;
using System;
using System.Linq;
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


                    bool mExists = (_repositorio.ListarCentroDistribuicao().Any(T => T.NOME.ToUpper() == _CdObj.NOME.ToUpper()));

                    if (!mExists)               
                    {
                        if (_repositorio.AddCentroDistribuicao(_CdObj))
                        {
                            ViewBag.Mensagem = "Centro de Distribuição Cadastrado com sucesso.";
                        }
                    }
                    else
                    {
                        ViewBag.Mensagem = "Centro de Distribuição ja existe.";

                    }

                }
                return RedirectToAction("ObterListaCentroDistribuicao");
            }
            catch(Exception)
            {
                ViewBag.Mensagem = "Não foi possivel salvar.";
                return RedirectToAction("ObterListaCentroDistribuicao");

            }        
        
        }

        [HttpGet]
        public ActionResult AlterarCentroDistribuicao()
        {
            return View();
        }


        [HttpPost]
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
                return RedirectToAction("ObterListaCentroDistribuicao");
            }
            catch (Exception)
            {
                ViewBag.Mensagem = "Não foi possivel alterar.";
                return RedirectToAction("ObterListaCentroDistribuicao");

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