using LSI_test.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LSI_test.Controllers
{
    public class HomeController : Controller
    {
        private ExportLogManager logManager = new ExportLogManager();
        #region Actions

        public ActionResult Index()
        {
            ExportLogViewModel model = new ExportLogViewModel();

            try
            {
                model.ExportLogItems = logManager.GetExports();
                ApplyFilters(model);
            }
            catch
            {
                return View("Error");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult GetExportLogs(ExportLogViewModel model)
        {
            try
            {
                return PartialView("_logsTable", logManager.GetExports(model.LocalsFilter, model.DateFromFilter, model.DateToFilter));
            }
            catch
            {
                return View("Error");
            }
        }

        #endregion

        #region Helpers

        private ExportLogViewModel ApplyFilters(ExportLogViewModel model)
        {
            model.LocalsPossibleFilter = new SelectList(model.ExportLogItems.Select(x => x.Local).Distinct()).ToList();
            model.EndPossibleDate = model.ExportLogItems.Any() ? model.ExportLogItems?.OrderByDescending(x => x.ExportDateTime).First().ExportDateTime : null;
            model.StartPossibleDate = model.ExportLogItems.Any() ? model.ExportLogItems?.OrderBy(x => x.ExportDateTime).First().ExportDateTime : null;

            return model;
        }

        #endregion
    }
}