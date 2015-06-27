using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ripper.Models
{
    public class Cuts
    {
        [Required(ErrorMessage = "At least one Available Stock is required")]
        public List<int> BoardList  { get; set; }

        [Required(ErrorMessage = "At least one Lenght is required")]
        public List<int> LengthList { get; set; }

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