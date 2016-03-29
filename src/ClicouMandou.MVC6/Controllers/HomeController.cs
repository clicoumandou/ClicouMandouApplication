using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ClicouMandou.Infrastructure.Data.Domain.ProjetoArg;
using ClicouMandou.Infrastructure.Data.Context;

namespace ClicouMandou.MVC6.Controllers
{
    public class HomeController : Controller
    {
        private ClicouMandouDbContext _DbContext;

        public HomeController(ClicouMandouDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            var projeto = _DbContext.Projetos.FirstOrDefault(x => x.Id == 1);

            projeto.Name = "Clicou Mandou";

            _DbContext.Entry(projeto);

            _DbContext.SaveChanges();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
