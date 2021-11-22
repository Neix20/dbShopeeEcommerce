using IronXL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbShopeeEcommerce.Controllers
{
    public class ReadFileController : Controller
    {
        // GET: ReadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportExcel()
        {
            if(Request.Files["fileUpload"].ContentLength > 0)
            {
                // Path Name
                string path1 = $"{Server.MapPath("~/Content/Uploads")}\\{Request.Files["fileUpload"].FileName}";
                if (!Directory.Exists(path1)) Directory.CreateDirectory(Server.MapPath("~/Content/Uploads"));

                // Save File
                Request.Files["fileUpload"].SaveAs(path1);

                return Content(table_str(path1));
            }
            return Content("Nothing");
        }

        public static string table_str(String filename)
        {
            WorkBook wb = WorkBook.Load(filename);
            WorkSheet ws = wb.GetWorkSheet("Shopee Report");

            string header_row = "<tr>";
            ws.Rows[0].ToList().ForEach(col =>
            {
                string val = col.Value.ToString();
                header_row += $"<th>{val}</th>";
            });
            header_row += "</tr>";

            string body_row = "";
            ws.Rows.ToList().GetRange(1, ws.RowCount - 1).ForEach(row =>
            {
                string tmp_row = "<tr>";
                row.ToList().ForEach(col =>
                {
                    string val = col.Value.ToString();
                    tmp_row += $"<td>{val}</td>";
                });
                tmp_row += "</tr>";
                body_row += tmp_row;
            });

            return "<table class='table'>"
                +$"<thead>{header_row}</thead>"
                +$"<tbody>{body_row}</tbody>"
                +"</table>";
        }

    }
}