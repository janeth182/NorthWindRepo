using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using NorthWind.Entity;
namespace Northwind.DAO
{
    public  class TbClienteDAO
    {
        public static List<TbClienteBE> SelectAll()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ToString();
            string sql = "Select CodCliente,Nombre,Ruc from TbCliente";
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, Connection))
                    {
                        command.CommandType = CommandType.Text;
                        List<TbClienteBE> Clientes = new List<TbClienteBE>();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            { 
                                TbClienteBE objTbClienteBE=new TbClienteBE();
                                objTbClienteBE.CodCliente=Convert.ToString(reader.GetDecimal(0));
                                objTbClienteBE.Nombre = reader.GetString(1);
                                objTbClienteBE.Ruc = reader.GetString(2);
                                Clientes.Add(objTbClienteBE);
                                
                            }
                            
                        }
                        
                        return Clientes;
                    
                    }
                    
                   
                }
         
        }
       
    }
}
