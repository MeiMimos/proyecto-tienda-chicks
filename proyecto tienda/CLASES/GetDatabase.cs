using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tienda.CLASES
{
    public class GetDatabase
    {
        public static List<clgrupo> ObtenerGrupo(string sConexion)
        {
            List<clgrupo> lista = new List<clgrupo>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT GRU_ID, GRU_NOMBRE, GRU_COLORES, GRU_EST_ID FROM GRUPO";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clgrupo _Grupo = new clgrupo();
                {
                    _Grupo.GRU_ID = l.GetInt32(0);
                    _Grupo.GRU_NOMBRE = l.GetString(1);
                }
                lista.Add(_Grupo);
            }
            con.Close();
            l.Close();
            return lista;
        }

        public static List<clestanteria> ObtenerEstanteria(string sConexion)
        {
            List<clestanteria> lista = new List<clestanteria>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ESTANTERIA";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clestanteria _ESTANTERIA = new clestanteria();
                {
                    _ESTANTERIA.EST_ID = l.GetByte(0);
                    _ESTANTERIA.EST_DESC = l.GetString(1);
                }
                lista.Add(_ESTANTERIA);
            }
            con.Close();
            l.Close();
            return lista;
        }

        public static List<clestadoCompra> ObtenerEstadoCompra(string sConexion, string sFiltro)
        {
            List<clgrupo> lista = new List<clgrupo>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM COMPRA WHERE COM_ID LIKE '%"+ sFiltro +"%'";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clgrupo _Grupo = new clgrupo();
                {
                    _Grupo.GRU_ID = l.GetInt32(0);
                    _Grupo.GRU_NOMBRE = l.GetString(1);
                }
                lista.Add(_Grupo);
            }
            con.Close();
            l.Close();
            return lista;
        }

    }
}
