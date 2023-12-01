using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tienda.CLASES
{
    internal class GetDataBase
    {
        public static List<clgrupo> ObtenerGrupo(string sConexion)
        {
            List<clgrupo> lista = new List<clgrupo>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM GRUPO";
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
        public static List<clgrupo> ObtenerClienteFiltro(string sFiltro)
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
                }
                lista.Add(_Cliente);
            }
            con.Close();
            l.Close();
            return lista;
        }
        public static List<clgrupo> ObtenerProveedorFiltro(string sFiltro)
        {
            List<clproveedor> lista = new List<clproveedor>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PROVEEDOR WHERE PRV_NOMBRE LIKE '%'" + sFiltro + "%'";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clproveedor _Proveedor = new clproveedor();
                {
                    _Proveedor.PRV_ID = l.GetInt32(0);
                    _Proveedor.PRV_NOMBRE = l.GetString(1);
                }
                lista.Add(_Proveedor);
            }
            con.Close();
            l.Close();
            return lista;
        }
    }
}

