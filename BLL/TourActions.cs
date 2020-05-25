using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TourActions
    {
        IMapper TourM = new MapperConfiguration(cfg => cfg.CreateMap<Tour, MTour>().ForMember(x => x.VisitedCities, y => y.Ignore())).CreateMapper();

        private readonly UnitOfWork uow;
        public TourActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public TourActions()
        {
            Context context = new Context();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));
        }


        public virtual List<MTour> GetTours()
        {
            return TourM.Map<IEnumerable<Tour>, List<MTour>>(uow.Tours.Get());
        }

        public virtual MTour GetTourById(int id)
        {
            return TourM.Map<Tour, MTour>(uow.Tours.GetOne(x => (x.TourID == id)));
        }

        public virtual bool AddTour(MTour n)
        {
            List<City> VS = new List<City>();
            foreach(var t in n.VisitedCities)
            {
                VS.Add(new City() { NameCity = t.NameCity, NameCountry = t.NameCountry });
            }
            uow.Tours.Create(new Tour { NameTour = n.NameTour, DepartureCity = n.DepartureCity, Transport = n.Transport, TypeFood = n.TypeFood, MovingTime = n.MovingTime, Cost = n.Cost, Description = n.Description, DataEnd = n.DataEnd, DataStart = n.DataStart , VisitedCities = new List<City>(VS) });
            uow.Save();
            return true;
        }

        public virtual bool DeleteTourByID(int id)
        {
            uow.Tours.Remove(uow.Tours.FindById(id));
            CityActions CA = new CityActions();
            CA.DeleteCitiesByID(id);
            uow.Save();
            return true;
        }


        public virtual bool ChangeTour(MTour n)
        {

            uow.Tours.Update(new Tour { NameTour = n.NameTour, DepartureCity = n.DepartureCity, Transport = n.Transport, TypeFood = n.TypeFood, MovingTime = n.MovingTime, Cost = n.Cost, Description = n.Description, DataEnd = n.DataEnd, DataStart = n.DataStart });
            uow.Save();
            return true;
        }
    }
}
