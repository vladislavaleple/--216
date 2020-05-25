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
    public class CityActions
    {
        IMapper CityM;
        private readonly UnitOfWork uow;
        public CityActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public CityActions()
        {
            CityM = new MapperConfiguration(cfg => cfg.CreateMap<City, MCity>().ForMember(x => x.Tour, y => y.Ignore())).CreateMapper();
            Context context = new Context();
            uow = new UnitOfWork(context, new ContextRepository<Role>(context), new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context));
        }


        public virtual List<MCity> GetCities()
        {
            return CityM.Map<IEnumerable<City>, List<MCity>>(uow.Cities.Get()); 
        }

        public virtual List<MCity> GetCitiesById(int id)
        {
            IEnumerable<City> LC = uow.Cities.Get(o => o.TourId == id);
            List<MCity> LMC = new List<MCity>();
            foreach(var t in LC)
            {
                LMC.Add(new MCity() { NameCity = t.NameCity, NameCountry = t.NameCountry, TourId = t.TourId });
            }
            return LMC;
        }

        public virtual bool DeleteCitiesByID(int idTour)
        {

            List<City> LMC = uow.Cities.Get(o => o.TourId == idTour).ToList();
            foreach(var t in LMC)
            {
                uow.Cities.Remove(uow.Cities.FindById(t.CityID));
                uow.Save();
            }
            uow.Save();
            return true;
        }
    }
}
