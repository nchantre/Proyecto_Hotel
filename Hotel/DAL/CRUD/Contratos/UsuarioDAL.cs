using DAL.Conexion.Contratos;
using DAL.CRUD.Implementacion;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace DAL.CRUD.Contratos
{
    public class UsuarioDAL : IUsuarioDAL
    {
        #region Propiedades
        private readonly IConexionBD _conexionBD;
        #endregion

        #region Constructor
        public UsuarioDAL( 
            IConexionBD conexionBD
            )
        {
            _conexionBD = conexionBD;
        }
        #endregion

        #region GetAllusuarioId
        public Usuario GetAllUsuarioId(int IdUsuario)
        {
            Usuario objUsuario = new();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = _conexionBD.OpenConexion();
                comando.CommandText = "spUsuarioAllId";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@PrmUsuarioId", SqlDbType.Int).Value = IdUsuario;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            objUsuario.IdUsuario = Convert.ToInt32(read["IdUsuario"]);
                            objUsuario.NombreUsuario = read["NombreUsuario"].ToString();
                            objUsuario.ApellidoUsuario = read["ApellidosUsuario"].ToString();
                            objUsuario.EmailUsuario = read["EmailUsuario"].ToString();
                            objUsuario.DireccionUsuario = read["DireccionUsuario"].ToString();
                        }
                    }
                }
                _conexionBD.CloseConexion();
                return objUsuario;
            }
        }
        #endregion

        #region InsertUsuario
        public string AddUsuario()
        {
            Usuario objUsuario = new();
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = _conexionBD.OpenConexion();
                    comando.CommandText = "spUsuarioInsert";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = Convert.ToString(objUsuario.NombreUsuario);
                    comando.Parameters.Add("@ApellidosUsuario", SqlDbType.VarChar, 50).Value = Convert.ToString(objUsuario.ApellidoUsuario);
                    comando.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 70).Value = Convert.ToString(objUsuario.EmailUsuario); 
                    comando.Parameters.Add("@DireccionUsuario", SqlDbType.VarChar, 70).Value = Convert.ToString(objUsuario.DireccionUsuario);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    _conexionBD.CloseConexion();

                }

            }
            catch (FaultException fex)
            {
                mensaje = "Error" + fex;
            }

            return mensaje;
        }
        #endregion

        #region EditUsuario
        public void UpUsuario()
        {
            Usuario objUsuario = new();

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = _conexionBD.OpenConexion();
                comando.CommandText = "spUsuarioUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (objUsuario.IdUsuario);
                comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = Convert.ToString(objUsuario.NombreUsuario);
                comando.Parameters.Add("@ApellidoUsuario", SqlDbType.Date).Value = Convert.ToString(objUsuario.ApellidoUsuario);
                comando.Parameters.Add("@DireccionUsuario", SqlDbType.VarChar, 70).Value = Convert.ToString(objUsuario.DireccionUsuario); ;
                comando.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 70).Value = Convert.ToString(objUsuario.EmailUsuario);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                _conexionBD.CloseConexion();


            }

        }

        #endregion

        #region DeleteUsuario
        public void DeleteUsuario(int IdUsuario)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = _conexionBD.OpenConexion();
                comando.CommandText = "spUsuarioDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (IdUsuario);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                _conexionBD.CloseConexion();

            }


        }

        #endregion

        #region GetAllUsuario
        public List<Usuario> GetAllUsuario()
        {

            
            using (SqlCommand comando = new SqlCommand())
            {
                List<Usuario> items = new ();

                comando.Connection = _conexionBD.OpenConexion();
                comando.CommandText = "spUsuarioAll";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            Usuario objUsuario = new();
                            objUsuario.IdUsuario = Convert.ToInt32(read["IdUsuario"]);
                            objUsuario.NombreUsuario = read["NombreUsuario"].ToString();
                            objUsuario.ApellidoUsuario = read["ApellidosUsuario"].ToString();
                            objUsuario.DireccionUsuario = read["DireccionUsuario"].ToString();
                            objUsuario.EmailUsuario = read["EmailUsuario"].ToString();
                            items.Add(objUsuario);
                        }

                    }
                }
                // tb.Load(read);
                _conexionBD.CloseConexion();
                return items;
            }

        }
        #endregion
    }
}
