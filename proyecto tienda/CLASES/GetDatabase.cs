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

        public static List<clgrupo> ObtenerClienteFiltro(string sFiltro, string sConexion)
        {
            List<clcliente> lista = new List<clcliente>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CLIENTE WHERE CLI_NOMBRE LIKE '%'" + sFiltro + "%'";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clcliente _Cliente = new clcliente();
                {
                    _Cliente.CLI_ID = l.GetInt32(0);
                    _Cliente.CLI_NOMBRE = l.GetString(1);
                    _Cliente.CLI_APP = l.GetString(2);
                    _Cliente.CLI_APM = l.GetString(3);
                    _Cliente.CLI_TELEFONO = l.GetString(4);
                }
                lista.Add(_Cliente);
            }
            con.Close();
            l.Close();
            return lista;
        }
        /*public static List<clcliente> ObtenerEstadoProducto(string sConexion, string sFiltro)
        {
            List<cl> lista = new List<clcliente>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CLIENTE WHERE CLI_NOMBRE LIKE '%" + sFiltro + "%'";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clcliente _Producto = new clcliente();
                {
                    _Producto.PRO_ID = l.GetInt32(0);
                    _Producto.PRO_PRECIO= l.GetInt32(1);
                    _Producto.PRO_UNIDAD = l.GetInt32(2);
                    _Producto.PRO_
                }
                lista.Add(_Producto);
            }
            con.Close();
            l.Close();
            return lista;
        }*/
    }
}
