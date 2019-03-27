using CrystalDecisions.CrystalReports.Engine;
using CrystalReportDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrystalReportDemo.Controllers
{
    public class HomeController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();

        public ActionResult EmployeeList()
        {
            return View(db.EmployeeInfoes.ToList());
        }

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Report"), "CrystalReport.rpt"));
            rd.SetDataSource(db.EmployeeInfoes.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Employee_list.pdf");
            }
            catch
            {
                throw;
            }
        }
    }
}