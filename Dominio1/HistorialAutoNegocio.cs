using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio1
{
    public class HistorialAutoNegocio
    {
        public List<HistorialAuto> listarPorAuto(int idAuto)
        {
            List<HistorialAuto> lista = new List<HistorialAuto>();

            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandText = @"
        SELECT Id, IdAuto, Fecha, Accion, Descripcion
        FROM HistorialAutos
        WHERE IdAuto = @idAuto
        ORDER BY Fecha DESC";

            comando.Parameters.AddWithValue("@idAuto", idAuto);

            try
            {
                con.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    HistorialAuto h = new HistorialAuto
                    {
                        Id = (int)lector["Id"],
                        IdAuto = (int)lector["IdAuto"],
                        Fecha = (DateTime)lector["Fecha"],
                        Accion = lector["Accion"].ToString(),
                        Descripcion = lector["Descripcion"].ToString()
                    };

                    lista.Add(h);
                }
            }
            finally
            {
                con.Close();
            }

            return lista;
        }

        public void agregar(HistorialAuto h)
        {
            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandText = @"
        INSERT INTO HistorialAutos (IdAuto, Fecha, Accion, Descripcion)
        VALUES (@IdAuto, @Fecha, @Accion, @Descripcion)";

            comando.Parameters.AddWithValue("@IdAuto", h.IdAuto);
            comando.Parameters.AddWithValue("@Fecha", h.Fecha);
            comando.Parameters.AddWithValue("@Accion", h.Accion);
            comando.Parameters.AddWithValue("@Descripcion", h.Descripcion);

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public List<HistorialAuto> listarUltimos(int cantidad)
        {
            List<HistorialAuto> lista = new List<HistorialAuto>();

            string conexion = ConfigurationManager
                .ConnectionStrings["ConexionAutos"]
                .ConnectionString;

            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(@"
                SELECT TOP (@cantidad)
                h.Id,
                h.IdAuto,
                a.Modelo,
                h.Fecha,
                h.Accion,
                h.Descripcion
                FROM HistorialAutos h
                INNER JOIN Autos a ON a.Id = h.IdAuto
                ORDER BY h.Fecha DESC", con);

            cmd.Parameters.AddWithValue("@cantidad", cantidad);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new HistorialAuto
                {
                    Id = (int)dr["Id"],
                    IdAuto = (int)dr["IdAuto"],
                    ModeloAuto = dr["Modelo"].ToString(),
                    Fecha = (DateTime)dr["Fecha"],
                    Accion = dr["Accion"].ToString(),
                    Descripcion = dr["Descripcion"].ToString()
                });
            }

            con.Close();
            return lista;
        }
    }     
}
