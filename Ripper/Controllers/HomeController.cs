using System.Collections.Generic;
using System.Linq;
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
            var cut = new Cuts();
            if (TempData["Cuts"] != null)
                cut = TempData["Cuts"] as Cuts;
            return View(cut);
        }

        //
        // POST: /Home/
        [HttpPost]
        public ActionResult Index(Cuts cuts)
        {
            if (!ModelState.IsValid) return View(cuts);
            TempData["Cuts"] = cuts;
            return RedirectToAction("Cuts", "Home");
        }

        //
        // GET: /Cuts/
        public ActionResult Cuts()
        {
            var cuts = TempData["Cuts"] as Cuts ?? TestCuts();

            if (cuts == null || cuts.BoardList == null || cuts.LengthList == null)
                return RedirectToAction("Index", "Home");

            var stock = cuts.BoardList.Select(s => new Stock(s, 8.6f, 0)).ToList();
            var lengths = cuts.LengthList.Select(l => new Length(l)).ToList();


            var bc = new Models.Ripper(stock, lengths, lengths.Count);
            bc.Solve();
            return View(bc.Solution);
        }

        private static Cuts TestCuts()
        {
            var cut = new Cuts
            {
                BoardList = new List<float> { 2720, 2720 },
                LengthList = new List<float> {800, 800, 700, 700, 700, 700, 500, 500},
            };

            return cut;
        }
    }
}
