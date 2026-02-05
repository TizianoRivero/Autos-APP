using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio1
{
    public class AutoNegocio
    {
        public List<Auto> listar()
        {
            List<Auto> lista = new List<Auto>();

            string conexion = ConfigurationManager
                                .ConnectionStrings["ConexionAutos"]
                                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Autos", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Auto a = new Auto();
                    a.Id = (int)dr["Id"];
                    a.Modelo = dr["Modelo"].ToString();
                    a.Descripcion = dr["Descripcion"].ToString();
                    a.Color = dr["Color"].ToString();
                    a.Fecha = (DateTime)dr["Fecha"];
                    a.Usado = (bool)dr["Usado"];
                    a.Importado = (bool)dr["Importado"];

                    lista.Add(a);
                }

                dr.Close();
                return lista;
            }
            finally
            {
                con.Close();
            }
        }

<<<<<<< HEAD
        public int agregar(Auto auto)
=======
        public void agregar(Auto auto)
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(
<<<<<<< HEAD
                @"INSERT INTO Autos (Modelo, Descripcion, Color, Fecha, Usado, Importado)
          VALUES (@Modelo, @Descripcion, @Color, @Fecha, @Usado, @Importado);
          SELECT SCOPE_IDENTITY();", con);
=======
             "INSERT INTO Autos (Modelo, Descripcion, Color, Fecha, Usado, Importado) " +
             "VALUES (@Modelo, @Descripcion, @Color, @Fecha, @Usado, @Importado)", con);
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add

            cmd.Parameters.AddWithValue("@Modelo", auto.Modelo);
            cmd.Parameters.AddWithValue("@Descripcion", auto.Descripcion);
            cmd.Parameters.AddWithValue("@Color", auto.Color);
            cmd.Parameters.AddWithValue("@Fecha", auto.Fecha);
            cmd.Parameters.AddWithValue("@Usado", auto.Usado);
            cmd.Parameters.AddWithValue("@Importado", auto.Importado);

            con.Open();
<<<<<<< HEAD
            int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            auto.Id = idGenerado;
            return idGenerado;
=======
            cmd.ExecuteNonQuery();
            con.Close();
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
        }

        public void modificar(Auto auto)
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(
                "UPDATE Autos SET Modelo=@Modelo, Descripcion=@Descripcion, Color=@Color, Fecha=@Fecha, Usado=@Usado, Importado=@Importado WHERE Id=@Id",
                con);

            cmd.Parameters.AddWithValue("@Id", auto.Id);
            cmd.Parameters.AddWithValue("@Modelo", auto.Modelo);
            cmd.Parameters.AddWithValue("@Descripcion", auto.Descripcion);
            cmd.Parameters.AddWithValue("@Color", auto.Color);
            cmd.Parameters.AddWithValue("@Fecha", auto.Fecha);
            cmd.Parameters.AddWithValue("@Usado", auto.Usado);
            cmd.Parameters.AddWithValue("@Importado", auto.Importado);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Auto buscarPorId(int id)
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            Auto a = null;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Autos WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a = new Auto();
                a.Id = (int)dr["Id"];
                a.Modelo = dr["Modelo"].ToString();
                a.Descripcion = dr["Descripcion"].ToString();
                a.Color = dr["Color"].ToString();
                a.Fecha = (DateTime)dr["Fecha"];
                a.Usado = (bool)dr["Usado"];
                a.Importado = (bool)dr["Importado"];
            }

            con.Close();
            return a;
        }

        public void eliminar(int id)
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("DELETE FROM Autos WHERE Id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
<<<<<<< HEAD

        public EstadisticasDashboard ObtenerEstadisticas()
        {
            EstadisticasDashboard stats = new EstadisticasDashboard();

            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Autos", con);

            con.Open();
            stats.TotalAutos = (int)cmd.ExecuteScalar();
            con.Close();

            return stats;
        }
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
    }
}
