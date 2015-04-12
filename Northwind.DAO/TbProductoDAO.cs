using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAO
{
    public class TbProductoDAO
    {
        public static List<TbProductoBE> SelectAll()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ToString();
            string sql = "Select CodProducto,Descripcion,Precio from TbProducto";
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.CommandType = CommandType.Text;
                    List<TbProductoBE> Productos = new List<TbProductoBE>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TbProductoBE objTbProductoBE = new TbProductoBE();
                            objTbProductoBE.CodProducto = Convert.ToString(reader.GetDecimal(0));
                            objTbProductoBE.Descripcion = reader.GetString(1);
                            objTbProductoBE.Precio = Convert.ToString(reader.GetDecimal(2));
                            Productos.Add(objTbProductoBE);
                        }

                    }

                    return Productos;

                }


            }

        }
       
    }
}
