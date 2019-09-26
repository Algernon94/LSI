using LSI_test.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LSI_test.Models
{
    public class ExportLogManager
    {
        internal IEnumerable<ExportLogItemViewModel> GetExports(string local = null, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            try
            {
                using (var exportLogDBContext = new LSIDBEntities())
                {
                    var queryResult = exportLogDBContext.ExportLog.AsQueryable();

                    if (local != null)
                        queryResult = queryResult.Where(x => x.ExportLocalName == local);
                    if (dateFrom != null)
                        queryResult = queryResult.Where(x => DbFunctions.TruncateTime(x.ExportDateTime) >= DbFunctions.TruncateTime(dateFrom.Value));
                    if (dateTo != null)
                        queryResult = queryResult.Where(x => DbFunctions.TruncateTime(x.ExportDateTime) <= DbFunctions.TruncateTime(dateTo.Value));

                    return queryResult.Select(x => new ExportLogItemViewModel
                    {
                        ID = x.ExportId,
                        ExportDateTime = x.ExportDateTime,
                        ExportName = x.ExportName,
                        Local = x.ExportLocalName,
                        Username = x.ExportUserName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message + Environment.NewLine;
                System.IO.File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~/errors.txt"), exceptionMessage);

                throw new Exception("Error during getting data");
            }
        }
    }
}