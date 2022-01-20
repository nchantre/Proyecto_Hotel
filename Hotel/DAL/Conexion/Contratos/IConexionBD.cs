using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion.Contratos
{
    public interface IConexionBD
    {
        SqlConnection OpenConexion();
        SqlConnection CloseConexion();
    }
}
