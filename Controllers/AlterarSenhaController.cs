using FCX_Labs.Helper;
using FCX_Labs.Models;
using FCX_Labs.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FCX_Labs.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUserRepository _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUserRepository usuarioRepositorio,
                                      ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(ModifyPassModel alterarSenhaModel)
        {
            try
            {
                User usuarioLogado = _sessao.GetSession();
                alterarSenhaModel.id = usuarioLogado.id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.ModifyPass(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}