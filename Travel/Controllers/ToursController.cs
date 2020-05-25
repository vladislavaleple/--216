using BLL;
using BLL.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class ToursController : ApiController
    {
        // GET: api/Tours
        public IEnumerable<MTour> Get()
        {
            TourActions TA = new TourActions();
            IEnumerable<MTour> T = TA.GetTours();
            foreach(var t in T)
            {
                t.VisitedCities = null;
            }
            return T;
        }

        // GET: api/Tours/5
        public MTour Get(int id)
        {
            TourActions TA = new TourActions();
            MTour tour = TA.GetTourById(id);
            tour.VisitedCities = null;
            return tour;
        }

        // POST: api/Tours
        [HttpPost]
        public void Post([FromBody]MTour value)
        {
            var ma = value.VisitedCities;
            foreach(var t in ma)
            {
                t.Tour = value;
            }
            value.VisitedCities = new List<MCity>(ma);
            TourActions TA = new TourActions();
            TA.AddTour(value);
        }

        // PUT: api/Tours/5
        [HttpPut]
        public void Put(int id, [FromBody]MTour value)
        {
            TourActions TA = new TourActions();
            TA.ChangeTour(value);
        }

        // DELETE: api/Tours/5
        public void Delete(int id)
        {
            TourActions TA = new TourActions();
            TA.DeleteTourByID(id);
            
            
        }
    }
}
