using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio1
{
    public class UsuarioNegocio
    {
        public Usuario Login(string email, string password)
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(
                "SELECT Id, Email, Rol FROM Usuarios WHERE Email = @email AND Password = @password",
                con);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Usuario user = new Usuario();
                user.Id = (int)dr["Id"];
                user.Email = dr["Email"].ToString();
                user.Rol = dr["Rol"].ToString();

                con.Close();
                return user;
            }

            con.Close();
            return null;
        }
    }
}
