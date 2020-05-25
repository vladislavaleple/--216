using BLL.Models;
using BLL;
using System.Collections.Generic;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class CityController : ApiController
    {
        // GET: api/City
        public IEnumerable<MCity> Get()
        {
            CityActions CA = new CityActions();
            return CA.GetCities();
        }

        // GET: api/City/5
        public IEnumerable<MCity> Get(int id)
        {
            CityActions CA = new CityActions();
            return CA.GetCitiesById(id);
        }

        // POST: api/City
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
