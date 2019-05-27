using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace WebApplication4
{
    public partial class SiteIn : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        public AjaxControlToolkit.ModalPopupExtender Modal
        {
            get { return mde; }
        }
        public string MessageTitle
        {
            set { ModalTitle.InnerText = value; }
        }
        public string MessageContent
        {
            set { ModalContent.InnerText = value; }
        }
        public void MessageModal(string title,string content, string butTitle,string butUrl)
        {
            MessageTitle = title;
            MessageContent = content;
            btnOther.Text = butTitle;
            btnOther.NavigateUrl = butUrl;
            if (butTitle == null) {
                btnOther.Visible = false;
            }
            Modal.Show();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            // 以下代码可帮助防御 XSRF 攻击
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // 使用 Cookie 中的 Anti-XSRF 令牌
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // 生成新的 Anti-XSRF 令牌并保存到 Cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置 Anti-XSRF 令牌
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // 验证 Anti-XSRF 令牌
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Anti-XSRF 令牌验证失败。");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ModalTitle.InnerText = "你好么?";
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
