using Homework2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}