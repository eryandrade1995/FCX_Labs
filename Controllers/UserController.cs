using System.Linq;
using FCX_Labs.Models;
using FCX_Labs.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FCX_Labs.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _usuarioRepositorio;
        private readonly IPersonRepository _contatoRepositorio;

        public UserController(IUserRepository usuarioRepositorio,
                                 IPersonRepository contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<User> usuarios = _usuarioRepositorio.Load();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(long id)
        {
            User usuario = _usuarioRepositorio.SearchById(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(long id)
        {
            User usuario = _usuarioRepositorio.SearchById(id);
            return View(usuario);
        }

        public IActionResult Apagar(long id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Delete(id);

                if (apagado) TempData["MensagemSucesso"] = "Usuário apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(User usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string invalid = string.Empty;
                    invalid = FCX_Labs.Global.Utilities.Functions.checkPass(usuario.password) != string.Empty ? FCX_Labs.Global.Utilities.Functions.checkPass(usuario.password) : "";


                    if (string.IsNullOrEmpty(invalid))
                    {
                        usuario = _usuarioRepositorio.Add(usuario);
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = invalid;
                    }
                    return View(usuario);
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                User usuario = null;

                usuario = new User()
                {
                    id = usuarioSemSenhaModel.id,
                    name = usuarioSemSenhaModel.name,
                    login = usuarioSemSenhaModel.login,
                    email = usuarioSemSenhaModel.email,
                    profile = usuarioSemSenhaModel.profile
                };

                usuario = _usuarioRepositorio.Update(usuario);
                TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}