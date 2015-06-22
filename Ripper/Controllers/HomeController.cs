using System.Collections.Generic;
using System.Web.Mvc;
using Ripper.Models;

namespace Ripper.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Cuts/

        public ActionResult Cuts(List<string> Boards, List<string> Lengs)
        {
            var bc = new BoardCutter(Boards, Lengs);
            return View(bc);
        }

    }
}
