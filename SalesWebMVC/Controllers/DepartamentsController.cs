using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>();

            list.Add(new Departament(1, "Eletronics"));
            list.Add(new Departament(2, "Fashion"));

            return View(list);
        }
    }
}
