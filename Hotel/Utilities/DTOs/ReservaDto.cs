using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.DTOs
{
    public class ReservaDto
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdHotel { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntradaReserva { get; set; }
        public DateTime FechaSalidaReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public string EstadoReserva { get; set; }
    }
}
