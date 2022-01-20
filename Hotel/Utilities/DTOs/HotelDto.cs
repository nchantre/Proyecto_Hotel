using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.DTOs
{
    public class HotelDto
    {
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public string PaisHotel { get; set; }
        public string LatitudHotel { get; set; }
        public string LongitudHotel { get; set; }
        public string DescripcionHotel { get; set; }
        public string ActivoHotel { get; set; }
        public int NumeroHabitacionesHotel { get; set; }
    }
}
