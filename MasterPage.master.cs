using System;
using System.Web;
using Microsoft.Owin.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetCurrentPage();

        var user = Context.User.Identity;
        if (user.IsAuthenticated)
        {
            if (user.Name == "admin")
                lnkManagement.Visible = true;
            else
                lnkManagement.Visible = false;
            LnkLogIn.Visible = false;
            lnkRegister.Visible = false;

            //lnkFeedback.Visible = true;
            litStatus.Visible = true;
            btnLogOut.Visible = true;

            litStatus.Text = "Hello " + Context.User.Identity.Name;
        }
        else
        {
            LnkLogIn.Visible = true;
            lnkRegister.Visible = true;

            //lnkFeedback.Visible = false;
            lnkManagement.Visible = false;
            litStatus.Visible = false;
            btnLogOut.Visible = false;
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Pages/Account/Login.aspx");
    }

    private void SetCurrentPage()
    {
        var pageName = GetPageName();

        //switch (pageName)
        //{
        //    case "Index.aspx":
        //        lnkIndexLi.Attributes["class"] = "active";

        //        lnkAboutLi.Attributes["class"] = "";
        //        lnkFeedbackLi.Attributes["class"] = "";
        //        lnkManagementLi.Attributes["class"] = "";
        //        lnkLoginLi.Attributes["class"] = "";
        //        lnkRegisterLi.Attributes["class"] = "";
        //        break;
        //    case "About.aspx":
        //        lnkAboutLi.Attributes["class"] = "active";

        //        lnkIndexLi.Attributes["class"] = "";
        //        lnkFeedbackLi.Attributes["class"] = "";
        //        lnkManagementLi.Attributes["class"] = "";
        //        lnkLoginLi.Attributes["class"] = "";
        //        lnkRegisterLi.Attributes["class"] = "";
        //        break;
        //    case "Feedback.aspx":
        //        lnkFeedbackLi.Attributes["class"] = "active";

        //        lnkIndexLi.Attributes["class"] = "";
        //        lnkAboutLi.Attributes["class"] = "";
        //        lnkManagementLi.Attributes["class"] = "";
        //        lnkLoginLi.Attributes["class"] = "";
        //        lnkRegisterLi.Attributes["class"] = "";
        //        break;
        //    case "Management.aspx":
        //        lnkManagementLi.Attributes["class"] = "active";

        //        lnkIndexLi.Attributes["class"] = "";
        //        lnkAboutLi.Attributes["class"] = "";
        //        lnkFeedbackLi.Attributes["class"] = "";
        //        lnkLoginLi.Attributes["class"] = "";
        //        lnkRegisterLi.Attributes["class"] = "";
        //        break;
        //    case "Login.aspx":
        //    case "Login.aspx?ReturnUrl=%2FPages%2FFeedback.aspx":
        //        lnkLoginLi.Attributes["class"] = "active";

        //        lnkIndexLi.Attributes["class"] = "";
        //        lnkAboutLi.Attributes["class"] = "";
        //        lnkFeedbackLi.Attributes["class"] = "";
        //        lnkManagementLi.Attributes["class"] = "";
        //        lnkRegisterLi.Attributes["class"] = "";
        //        break;
        //    case "Register.aspx":
        //    case "ShoppingCart.aspx":
        //        lnkRegisterLi.Attributes["class"] = "active";

        //        lnkIndexLi.Attributes["class"] = "";
        //        lnkAboutLi.Attributes["class"] = "";
        //        lnkFeedbackLi.Attributes["class"] = "";
        //        lnkManagementLi.Attributes["class"] = "";
        //        lnkLoginLi.Attributes["class"] = "";
        //        break;
        //}
    }

    private string GetPageName()
    {
        int index = Request.Url.ToString().LastIndexOf('/');
        return Request.Url.ToString().Substring(index + 1);
    }
}
