using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Pages
{
    public partial class YqsbbUpsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                FormView1.DefaultMode = FormViewMode.Insert;
            }
            else if (string.IsNullOrEmpty(Request.QueryString["op"]))
            {
                FormView1.DefaultMode = FormViewMode.ReadOnly;
            }
            else if (Request.QueryString["op"] == "edit")
            {
                FormView1.DefaultMode = FormViewMode.Edit;
            }
            
        }

        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //this.Master.MessageTitle = "操作完成";
            //this.Master.MessageContent = e.AffectedRows + "条记录修改成功";
            //this.Master.Modal.Show();
            if (e.Exception != null)
            {
                this.Master.MessageModal("操作出错", e.Exception.Message, null, null);
                e.ExceptionHandled = true;
            }
            else
            {
                this.Master.MessageModal("操作完成", "记录修改完成", "返回设备列表", "/pages/yqsbblist.aspx");
            }
        }

        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                this.Master.MessageModal("操作出错", e.Exception.Message, null, null);
                e.ExceptionHandled = true;
            }
            else
            {
                this.Master.MessageModal("操作完成", "记录创建完成", "返回设备列表", "/pages/yqsbblist.aspx");
            }
        }
    }
}