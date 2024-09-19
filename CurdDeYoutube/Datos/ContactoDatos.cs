using CurdDeYoutube.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
//using System.Linq;

namespace CurdDeYoutube.Datos
{
    public class ContactoDatos
    {
        public ContactoDatos()
        {
            
        }

        public List<ContactoModel> Listar()
        {
            var oLista  = new List<ContactoModel>();

            var cn = new ConexionDB();

            try
            {
                using var conexion = new SqlConnection(cn.getCadenaSql());
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand("SP_LISTAR", conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel
                        {
                            IDContacto = Convert.ToInt32(dr["IDCONTACTO"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["TELEFONO"].ToString(),
                            Correo = dr["CORREO"].ToString(),
                        });
                    }
                }
                conexion.Close();
            }
            catch(Exception Err)
            {
                Console.WriteLine(Err);

            }
           
            return oLista;
        }

        public ContactoModel ObtenerContacto(int IdContacto)
        {
            var contacto = new ContactoModel();

            var cn = new ConexionDB();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand("SP_OBTENER_CONTACTO", conexion);
                sqlCommand.Parameters.AddWithValue("IDCONTACTO",IdContacto);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contacto.IDContacto = Convert.ToInt32(dr["IDCONTACTO"]);
                        contacto.Nombre = dr["Nombre"].ToString();
                        contacto.Telefono = dr["TELEFONO"].ToString();
                        contacto.Correo = dr["CORREO"].ToString();
                       
                    }
                }
                conexion.Close();
            }
            return contacto;
        }

        public bool GuardarContacto(ContactoModel oContacto)
        {
            bool rpta;

            try {
                var cn = new ConexionDB();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SP_GUARDAR", conexion);
                    sqlCommand.Parameters.AddWithValue("NOMBRE", oContacto.Nombre);
                    sqlCommand.Parameters.AddWithValue("TELEFONO", oContacto.Telefono);
                    sqlCommand.Parameters.AddWithValue("CORREO", oContacto.Correo);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    conexion.Close();
                }

                rpta = true;
            } catch(Exception e) {
                string error = e.Message;
                rpta = false;
            }


            return rpta; 
        } 
        
        public bool EditarContacto(ContactoModel oContacto)
        {
            bool rpta;

            try {
                var cn = new ConexionDB();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new("SP_UPDATE_CONTACTO", conexion);
                    sqlCommand.Parameters.AddWithValue("IDCONTACTO", oContacto.IDContacto);
                    sqlCommand.Parameters.AddWithValue("NOMBRE", oContacto.Nombre);
                    sqlCommand.Parameters.AddWithValue("TELEFONO", oContacto.Telefono);
                    sqlCommand.Parameters.AddWithValue("CORREO", oContacto.Correo);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    conexion.Close();
                }

                rpta = true;
            } catch(Exception e) {
                string error = e.Message;
                rpta = false;
            }


            return rpta; 
        }

        public bool EliminarContacto(int idContacto)
        {
            bool rpta;

            try
            {
                var cn = new ConexionDB();

                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SP_ELIMINAR", conexion);
                    sqlCommand.Parameters.AddWithValue("IDCONTACTO", idContacto);
                    
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.ExecuteNonQuery();
                    conexion.Close();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


    }
}


