using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace CheckInPortal.Controllers
{
    public class TestClass
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        private static string GetName()
        {
            string sqlQuery = " SELECT Student_name FROM Student_table";
            string temp = "";


            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();

                SqlDataReader cmdReader = cmd.ExecuteReader();

                if (cmdReader.Read())
                {
                    temp = cmdReader[0].ToString();
                }

                con.Close();
            }



            return temp;
        }
    }
}