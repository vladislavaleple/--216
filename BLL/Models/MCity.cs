using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MCity
    {
        public int CityID { get; set; }

        public string NameCity { get; set; }

        public string NameCountry { get; set; }

        public int TourId { get; set; }

        public virtual MTour Tour { get; set; }
    }
}
