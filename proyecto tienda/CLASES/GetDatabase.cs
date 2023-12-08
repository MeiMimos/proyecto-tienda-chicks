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

        public static List<clcliente> ObtenerClienteFiltro(string sConexion, string sFiltro)
        {
            List<clcliente> lista = new List<clcliente>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CLIENTE WHERE CLI_NOMBRE LIKE '%" + sFiltro + "%'";
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
        public static List<clproveedor> ObtenerProveedorFiltro(string sConexion, string sFiltro)
        {
            List<clproveedor> lista = new List<clproveedor>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PROVEEDOR WHERE PRV_NOMBRE LIKE '%" + sFiltro + "%'";
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

        public static List<clproducto> ObtenerProductoFiltro(string sConexion, string sFiltro)
        {
            List<clproducto> lista = new List<clproducto>();
            SqlConnection con = new SqlConnection(sConexion);
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader l;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PRODUCTO WHERE PRO_DESCRIPCION LIKE '%" + sFiltro + "%'";
            con.Open();
            l = cmd.ExecuteReader();
            while (l.Read())
            {
                clproducto _Producto = new clproducto();
                {
                    _Producto.PRO_ID = l.GetInt32(0);
                    _Producto.PRO_PRECIO = l.GetDouble(1);
                    _Producto.PRO_UNIDAD = l.GetInt32(2);
                    _Producto.PRO_COM_ID = l.GetInt32(3);
                    _Producto.PRO_GRU_ID = l.GetInt32(4);
                    _Producto.PRO_DESCRIPCION = l.GetString(5);
                }
                lista.Add(_Producto);
            }
            con.Close();
            l.Close();
            return lista;
        }


    }
}
