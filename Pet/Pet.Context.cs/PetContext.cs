using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Pet.Context.cs
{
    public class PetContext
    {
        SqlConnection con = new SqlConnection();
       

             public PetContext()
        {
            con.ConnectionString = @" Data Source = DESKTOP - TSI8JUU\SQLEXPRESS;Initial Catalog = PetShop; Integrated Security = True";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
