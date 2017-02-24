using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StableLawFirm
{
    public partial class _404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = Request.RawUrl.ToString();

            //if (url == "/index.asp")
            //{
            //    Response.Redirect("index.aspx");
            //}
            //if (url == "/about-us.asp")
            //{
            //    Response.Redirect("about-us.aspx");
            //}

            //if (url == "/why-us.asp")
            //{
            //    Response.Redirect("why-us.aspx");
            //}

            //if (url == "/legal-services.asp")
            //{
            //    Response.Redirect("legal-services.aspx");
            //}

            //if (url == "/office-locations.asp")
            //{
            //    Response.Redirect("office-locations.aspx"); 
            //}

            //if (url == "/contact.asp")
            //{
            //    Response.Redirect("contact.aspx");
            //}
            //else
            //{
            //    Response.Redirect("index.aspx");
            //}


            switch (url)
            {
                case "/index.asp":
               Response.Redirect("index.aspx");
                    return;

                case "/about-us.asp":
                    Response.Redirect("about-us.aspx");
                    return;

                case "/why-us.asp":
                    Response.Redirect("why-us.aspx");
                    return;

                case "/legal-services.asp":
                    Response.Redirect("legal-services.aspx");
                    return;

                case "/office-locations.asp":
                    Response.Redirect("office-locations.aspx");
                    return;

                case "/contact.asp":
                    Response.Redirect("contact.aspx");
                    return;

                case "/admin":
                    Response.Redirect("Login.aspx");
                    return;

                default:
                    Response.Redirect("index.aspx");
                    return;
            }



        }
    }
}