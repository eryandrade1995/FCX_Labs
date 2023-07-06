using FCX_Labs.Helper;
using FCX_Labs.Models;
using FCX_Labs.Repository;
using Microsoft.AspNetCore.Mvc;
using System;


namespace FCX_Labs.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;


        public LoginController(IUserRepository usuarioRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;

        }

        public IActionResult Index()
        {
            if (_sessao.GetSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.ClearSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(string login, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User usuario = _usuarioRepositorio.SearchByLogin(login);

                    if (usuario != null)
                    {

                        if (usuario.password == password)
                        {
                            _sessao.CreateSession(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(ChangePassModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User usuario = _usuarioRepositorio.SearchByEmailLog(redefinirSenhaModel.email, redefinirSenhaModel.login);
                    Console.Write(usuario.email);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";
                        Console.WriteLine(mensagem);
                        bool emailEnviado = _email.Enviar(usuario.email, "Sistema de Contatos - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Update(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}