using System.Linq;

namespace Models
{
    public class UserDetailModel
    {
        public UserDetail GetUserInformation(string guId)
        {
            GarageDBEntities db = new GarageDBEntities();
            var info = (from x in db.UserDetails
                        where x.GUID == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserDetail userDetail)
        {
            GarageDBEntities db = new GarageDBEntities();
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
        }
    }
}