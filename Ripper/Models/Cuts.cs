using System.Collections.Generic;
using System.Web.Mvc;

namespace Ripper.Models
{
    public class Cuts
    {
        public List<int> BoardList;
        public List<int> LengthList;

        public List<SelectListItem> StdBoards = new List<SelectListItem>
        {
            new SelectListItem {Text = "2.4m", Value = "2400"},
            new SelectListItem {Text = "2.7m", Value = "2700"},
            new SelectListItem {Text = "3.2m", Value = "3200"},
            new SelectListItem {Text = "5.7m", Value = "5700"},
            new SelectListItem {Text = "6m", Value = "6000"},
        };


    }
}