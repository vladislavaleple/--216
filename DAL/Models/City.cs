using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class City
    {
        public int CityID { get; set; }

        public string NameCity { get; set; }

        public string NameCountry { get; set; }

        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
    }
}
