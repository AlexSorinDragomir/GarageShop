using System;
using System.Web;
using Microsoft.Owin.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;
        if (user.IsAuthenticated)
        {
            LnkLogIn.Visible = false;
            lnkRegister.Visible = false;

            litStatus.Visible = true;
            btnLogOut.Visible = true;

            litStatus.Text = Context.User.Identity.Name;
        }
        else
        {
            LnkLogIn.Visible = true;
            lnkRegister.Visible = true;

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
}
