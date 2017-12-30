using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ssdFeedback.SelectCommand = "SELECT [Email], [Raiting], [Text], [SubmissionDate] FROM [Feedback] WHERE [UserGUID]='" + User.Identity.GetUserId() + "' ORDER BY [SubmissionDate]";
    }
    protected void btnSubmitFeedback_Click(object sender, EventArgs e)
    {
        if (validateFormInputs())
        {
            string userGUID = User.Identity.GetUserId();
            if (userGUID != null)
            {
                Feedback feedback = new Feedback
                {
                    Email = txtEmail.Text.ToString(),
                    Raiting = int.Parse(txtRaiting.Text.ToString()),
                    Text = txtFeedback.Text.ToString(),
                    UserGUID = userGUID,
                    SubmissionDate = DateTime.Now
                };

                FeedbackModel model = new FeedbackModel();
                litFeedbackMessage.Text = model.InsertFeedback(feedback);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                litFeedbackMessage.Text = "<span style='color:red;'>Please log in to order to submit feedback!</span>";
            }
        }
    }

    private bool validateFormInputs()
    {
        int value;
        if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
        {
            litFeedbackMessage.Text = "<span style='color:red;'>Please insert a valid email!</span>";
        }
        else
        {
            if (int.TryParse(txtRaiting.Text, out value))
            {
                if (value < 1 || value > 10)
                    litFeedbackMessage.Text = "<span style='color:red;'>Only Numbers between 1 and 10 are allowed for Raiting!</span>";
                else
                    litFeedbackMessage.Text = "";
            }
            else
                litFeedbackMessage.Text = "<span style='color:red;'>Only Numbers between 1 and 10 are allowed for Raiting!</span>";
        }

        return litFeedbackMessage.Text.Length == 0;
    }

}