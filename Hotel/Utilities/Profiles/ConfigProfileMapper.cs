using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DTOs;

namespace Utilities.Profiles
{
    public class ConfigProfileMapper : Profile
    {
    
        public ConfigProfileMapper()
        {
            #region Mapeo Usuario
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            #endregion

            #region Mapeo Hotel 
            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();
            #endregion

            #region Mapero Reserva
            CreateMap<Reserva, ReservaDto>();
            CreateMap<ReservaDto, Reserva>();
            #endregion

        }


    }
}
