using BLL;
using BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<MUser> Get()
        {
            UserActions u1 = new UserActions();
            return u1.GetUsers();
        }

        // GET: api/Users/5
        public MUser Get(int id)
        {
            UserActions u1 = new UserActions();
            return u1.GetUserById(id);
        }

        [HttpPost]
        public string Post([FromBody]string value)
        {
            UserActions u1 = new UserActions();
            string i = u1.GetUsers().Where(o => o.Login == value).FirstOrDefault().UserID.ToString();
            return i;
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            UserActions u1 = new UserActions();
            u1.DeleteUserByID(id);
        }
    }
}
