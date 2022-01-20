using DAL.Conexion.Contratos;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    public class ConexionBD : IConexionBD
    {
        #region Propiedades
        private readonly IConfiguration _configuration;
        private string connectionString;
        #endregion

        #region Constructor
        public ConexionBD(
                        IConfiguration configuration = null
                        )
        {
            _configuration = configuration;

        }
        #endregion
         

        //private  void CreateCommand()
        //{
        //    connectionString = _configuration.GetConnectionString("DefaultConnection");
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //    }
        //}

        //public List<Usuario>  GetUsuario()
        //{
        //    List<Usuario> list = new List<Usuario>();
        //    using (SqlConnection Con = new SqlConnection())
        //    {
        //        Con.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        //        Con.Open();
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = Con;
        //            cmd.CommandText = "select * from Usuario";
        //            SqlDataReader rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                list.Add(new Usuario
        //                {
        //                    IdUsuario = Convert.ToInt32(rd["IdUsuario"])

        //                });

        //            }
        //            Con.Close();

        //        }
        //        return list;

        //    }


        //}

        // private SqlConnection Con = new SqlConnection("Server=DESKTOP-FT1VQS5\\chan;DataBase=supcriptionDB;Integrated Security=true");


         private SqlConnection Con = new SqlConnection("Server=localhost;Database=Hotel;Trusted_Connection=false;User ID=sa;Password=root");

        #region MethodOpen 
        public SqlConnection OpenConexion()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            return Con;
        }
        #endregion

        #region MethodClose
        public SqlConnection CloseConexion()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            return Con;
        }
        #endregion
    }
}
