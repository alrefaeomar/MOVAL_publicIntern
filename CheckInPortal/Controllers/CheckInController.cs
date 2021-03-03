using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckInPortal.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace CheckInPortal.Controllers
{
    public class CheckInController : Controller
    {
        // GET: CheckIn
        public ActionResult Index(string stdSearch)

        {
        // Set conn
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
           

            //Select Table Where student Id is the Input 
            string sqlQuery = @"SELECT STD_NAME, STD_ENTRANCE, STD_RESIDENCE FROM STUDENT_TABLE WHERE STD_ID=@sid";
            using (SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn))
            { 
                sqlConn.Open();
                sqlComm.Parameters.AddWithValue("@sid", (object)stdSearch?? DBNull.Value);
           

                SqlDataReader sqlRead = sqlComm.ExecuteReader();

               if(sqlRead.Read())
                {
                    UserModel user = new Models.UserModel();

                    user.stdId = sqlRead["STD_ID"].ToString();
                    user.stdName = sqlRead["STD_NAME"].ToString();
                    user.stdResidence = sqlRead["STD_RESIDENCE"].ToString();
                    user.stdEntrance = sqlRead["STD_ENTRACE"].ToString();
                    

                    return View(user);
                }

            }
            sqlConn.Close();
             

            

            return View();

            /*
            // Set conn
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
            //Select Table Where student Id is the Input 
            string sqlQuery = "SELECT * FROM [dbo].[STD_Table] WHERE STD_ID=@sid";

            using (SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn))
            {
                sqlConn.Open();
                sqlComm.Parameters.AddWithValue("@sid", stdSearch);

                //Set Data

                SqlDataReader sqlRead = sqlQuery.e;

                DataSet dataSet = new DataSet();


                sqlConn.Close();


            }

            return View();

            */



        }
    }
}