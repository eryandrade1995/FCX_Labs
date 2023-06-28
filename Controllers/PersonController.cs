using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FCX_Labs.Models;
using FCX_Labs.Repository;


namespace FCX_Labs.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            var persons = _personRepository.LoadGrid();
            return View(persons);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(long id)
        {
            var person = _personRepository.LoadById(id);
            return View(person);
        }

        public IActionResult DeleteFn(long id)
        {
            var person = _personRepository.LoadById(id);

            return View(person);
        }

        public IActionResult Delete(long id)
        {
            _personRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            try
            {
                
                    _personRepository.Add(person);
                    return RedirectToAction("Index");
                
                   
                    return View(person);
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar realizar o cadastro. {err.Message}";
                return RedirectToAction("Index");               
            }
            
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personRepository.Update(person);
                    return RedirectToAction("Index");               
                }
                return View("Edit", person);
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar realizar a alteração. {err.Message}";
                return RedirectToAction("Index");               
            }
            
        }
    }
}