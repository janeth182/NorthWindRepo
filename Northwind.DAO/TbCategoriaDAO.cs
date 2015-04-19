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
    public class TbCategoriaDAO
    {
        public static List<TbCategoria> SelectAll()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ToString();
            string sql = "select CategoryID,CategoryName,Description from Categories";
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.CommandType = CommandType.Text;
                    List<TbCategoria> Categoria = new List<TbCategoria>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TbCategoria objTbCategoria = new TbCategoria();
                            objTbCategoria.CategoryID = reader.GetInt32(0);
                            objTbCategoria.CategoryName = reader.GetString(1);
                            objTbCategoria.Descripcion = reader.GetString(2);
                            Categoria.Add(objTbCategoria);
                        }

                    }

                    return Categoria;

                }


            }
        }
    }
}
