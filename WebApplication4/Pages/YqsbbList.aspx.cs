﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Text;
using WebApplication4.BLL;
using OfficeOpenXml.Table;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //searchParam.Value = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RunSample1();
        }
        public void RunSample1()
        {
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventory");
                using(var data=new YqsbBL())
                {
                    worksheet.Cells["A1"].LoadFromCollection(data.GetYqsbbs(), true, TableStyles.Medium9);
                }
                //Add the headers
                //worksheet.Cells[1, 1].Value = "ID";
                //worksheet.Cells[1, 2].Value = "Product";
                //worksheet.Cells[1, 3].Value = "Quantity";
                //worksheet.Cells[1, 4].Value = "Price";
                //worksheet.Cells[1, 5].Value = "Value";

                ////Add some items...
                //worksheet.Cells["A2"].Value = 12001;
                //worksheet.Cells["B2"].Value = "Nails";
                //worksheet.Cells["C2"].Value = 37;
                //worksheet.Cells["D2"].Value = 3.99;

                //worksheet.Cells["A3"].Value = 12002;
                //worksheet.Cells["B3"].Value = "Hammer";
                //worksheet.Cells["C3"].Value = 5;
                //worksheet.Cells["D3"].Value = 12.10;

                //worksheet.Cells["A4"].Value = 12003;
                //worksheet.Cells["B4"].Value = "Saw";
                //worksheet.Cells["C4"].Value = 12;
                //worksheet.Cells["D4"].Value = 15.37;

                ////Add a formula for the value-column
                //worksheet.Cells["E2:E4"].Formula = "C2*D2";

                ////Ok now format the values;
                //using (var range = worksheet.Cells[1, 1, 1, 5])
                //{
                //    range.Style.Font.Bold = true;
                //    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                //    range.Style.Font.Color.SetColor(Color.White);
                //}

                //worksheet.Cells["A5:E5"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                //worksheet.Cells["A5:E5"].Style.Font.Bold = true;

                //worksheet.Cells[5, 3, 5, 5].Formula = string.Format("SUBTOTAL(9,{0})", new ExcelAddress(2, 3, 4, 3).Address);
                //worksheet.Cells["C2:C5"].Style.Numberformat.Format = "#,##0";
                //worksheet.Cells["D2:E5"].Style.Numberformat.Format = "#,##0.00";

                ////Create an autofilter for the range
                //worksheet.Cells["A1:E4"].AutoFilter = true;

                //worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";   //Format as text

                ////There is actually no need to calculate, Excel will do it for you, but in some cases it might be useful. 
                ////For example if you link to this workbook from another workbook or you will open the workbook in a program that hasn't a calculation engine or 
                ////you want to use the result of a formula in your program.
                //worksheet.Calculate();

                //worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

                // lets set the header text 
               // worksheet.HeaderFooter.OddHeader.CenteredText = "&24&U&\"Arial,Regular Bold\" Inventory";
                // add the page number to the footer plus the total number of pages
               // worksheet.HeaderFooter.OddFooter.RightAlignedText =
                //    string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                // add the sheet name to the footer
               // worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
                // add the file path to the footer
               // worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

               // worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"];
               // worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];

                // Change the sheet view to show it in page layout mode
                //worksheet.View.PageLayoutView = true;

                // set some document properties
                //package.Workbook.Properties.Title = "Invertory";
                //package.Workbook.Properties.Author = "Jan Källman";
                //package.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 workbook using EPPlus";

                // set some extended property values
                //package.Workbook.Properties.Company = "AdventureWorks Inc.";

                // set some custom property values
                //package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan Källman");
                //package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");

                //var xlFile = Utils.GetFileInfo("sample1.xlsx");
                // save our new workbook in the output directory and we are done!
                package.SaveAs(Response.OutputStream);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Sample1.xlsx");

                //return xlFile.FullName;
            }
        }

        private void Sample1()
        {
            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Sample1");

            ws.Cells["A1"].Value = "Sample 1";
            ws.Cells["A1"].Style.Font.Bold = true;
            var shape = ws.Drawings.AddShape("Shape1", eShapeStyle.Rect);
            shape.SetPosition(50, 200);
            shape.SetSize(200, 100);
            shape.Text = "Sample 1 saves to the Response.OutputStream";

            pck.SaveAs(Response.OutputStream);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Sample1.xlsx");
        }

        protected void btnUploadClick(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["myFile"];

            using (YqsbBL bl = new YqsbBL())
            {
                var items=bl.ImportYqsbbs(file);
                foreach (var item in items)
                {
                    bl.UpsertYqsbb(item);
                }
                this.Master.MessageModal("设备添加或修改完成", "处理设备共"+items.Count()+"项", null, null);
                
            }
            GridView1.DataBind();
            //check file was submitted
            //if (file != null && file.ContentLength > 0)
            //{
            //    using (ExcelPackage package = new ExcelPackage(file.InputStream))
            //    {
            //        ExcelWorksheet sheet = package.Workbook.Worksheets[1];
            //        var query1 = (from cell in sheet.Cells["1:1"]  select cell);
            //        foreach (var cell in query1)
            //        {
            //            //Console.WriteLine("Cell {0} has value {1:N0}", cell.Address, cell.Value);
            //            //count++;
            //            TextBox1.Text += cell.Value + ",";
            //        }
            //    }
            //        string fname = Path.GetFileName(file.FileName);
            //    file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)

        {

            GridView1.DataBind();
        }
        protected void CollectCheckedRecords()
        {
            List<string> list = new List<string>();
            if (ViewState["SelectedRecords"] != null)
            {
                list = (List<string>)ViewState["SelectedRecords"];
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                var selectedKey =
                (GridView1.DataKeys[row.RowIndex].Value.ToString());
                if (chk.Checked)
                {
                    if (!list.Contains(selectedKey))
                    {
                        list.Add(selectedKey);
                    }
                }
                else
                {
                    if (list.Contains(selectedKey))
                    {
                        list.Remove(selectedKey);
                    }
                }
            }
            ViewState["SelectedRecords"] = list;
        }
        protected void ClearCheckedRecords()
        {
            if (ViewState["SelectedRecords"] != null)
            {
                List<string> list = (List<string>)ViewState["SelectedRecords"];
                list.Clear();
            }
        }
        protected void PaginateTheData(object sender, GridViewPageEventArgs e)
        {
            CollectCheckedRecords();
            //GridView1.PageIndex = e.NewPageIndex;
            //this.GetData();
        }
        protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
        {
            List<string> list = ViewState["SelectedRecords"] as List<string>;
            if (e.Row.RowType == DataControlRowType.DataRow && list != null)
            {
                var autoId = (GridView1.DataKeys[e.Row.RowIndex].Value.ToString());
                if (list.Contains(autoId))
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkSelect");
                    chk.Checked = true;
                }
            }
        }
        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CollectCheckedRecords();
            List<string> list = ViewState["SelectedRecords"] as List<string>;
            foreach(string s in list)
            {
                
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CollectCheckedRecords();
            List<string> list = ViewState["SelectedRecords"] as List<string>;
            using(YqsbBL bl=new YqsbBL())
            {
                try
                {
                    foreach (string s in list)
                    {
                        bl.DeleteYqsbb(s);
                    }
                    this.Master.MessageModal("删除完成", "成功删除" + list.Count() + "条记录", null, null);
                }
                catch (Exception ex)
                {

                    this.Master.MessageModal("操作出错", ex.Message, null, null);
                }
            }
            ClearCheckedRecords();
            GridView1.DataBind();
            
        }
    }
}