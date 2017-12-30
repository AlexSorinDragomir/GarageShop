using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FeedbackModel
/// </summary>
public class FeedbackModel
{
    public string InsertFeedback(Feedback feedback)
    {
        try
        {
            // TODO SINGLETON 
            GarageDBEntities db = new GarageDBEntities();
            db.Feedback.Add(feedback);
            db.SaveChanges();

            return "Your feedback was successfully submitted on " + feedback.SubmissionDate;
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateFeedback(int id, Feedback feedback)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();

            //Fetchobject from db
            Feedback FeedbackFromDb = db.Feedback.Find(id);

            FeedbackFromDb.Email = feedback.Email;
            FeedbackFromDb.Raiting = feedback.Raiting;
            FeedbackFromDb.Text = feedback.Text;
            FeedbackFromDb.SubmissionDate = feedback.SubmissionDate;
            FeedbackFromDb.UserGUID = feedback.UserGUID;

            db.SaveChanges();
            return FeedbackFromDb.SubmissionDate + " was successfully updated";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteFeedback(int id)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();
            Feedback FeedbackToBeDeleted = db.Feedback.Find(id);

            db.Feedback.Attach(FeedbackToBeDeleted);
            db.Feedback.Remove(FeedbackToBeDeleted);
            db.SaveChanges();

            return FeedbackToBeDeleted.SubmissionDate + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

}