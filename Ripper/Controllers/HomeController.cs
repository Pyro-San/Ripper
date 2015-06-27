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
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true; 

            var cut = new Cuts();
            return View(cut);
        }

        //
        // POST: /Home/
        [HttpPost]
        public ActionResult Index(Cuts cuts)
        {
            if (!ModelState.IsValid) return View(cuts);
            TempData["Cuts"] = cuts;
            return RedirectToAction("Cuts");
        }

        //
        // GET: /Cuts/
        public ActionResult Cuts()
        {
            var cuts = TempData["Cuts"] as Cuts;
            if (cuts == null || cuts.BoardList == null || cuts.LengthList == null)
                return RedirectToAction("Cuts");

            var bc = new BoardCutter(cuts.BoardList, cuts.LengthList);
            return View(bc);
        }
    }
}
