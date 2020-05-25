using BLL;
using BLL.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class RegController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]MUser value)
        {
            UserActions ua = new UserActions();
            value.RoleId = 3;
            ua.AddUser(value);
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // GET: api/Reg/5
        public string Get(int id)
        {
            return "";
        }
    }
}
