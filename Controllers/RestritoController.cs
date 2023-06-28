using FCX_Labs.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FCX_Labs.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}