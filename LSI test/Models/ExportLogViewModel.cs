using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LSI_test.Models
{
    public class ExportLogItemViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Raport")]
        public string ExportName { get; set; }
        [Display(Name = "Data")]
        public DateTime ExportDateTime { get; set; }
        [Display(Name = "Użytkownik")]
        public string Username { get; set; }
        [Display(Name = "Lokal")]
        public string Local { get; set; }
    }

    public class ExportLogViewModel
    {
        public IEnumerable<ExportLogItemViewModel> ExportLogItems { get; set; }
        public IEnumerable<SelectListItem> LocalsPossibleFilter { get; set; }
        public DateTime? EndPossibleDate { get; set; }
        public DateTime? StartPossibleDate { get; set; }

        [Display(Name = "Lokal")]
        public string LocalsFilter { get; set; }
        [Display(Name = "Data do")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateToFilter { get; set; }
        [Display(Name = "Data od")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFromFilter { get; set; }
    }
}