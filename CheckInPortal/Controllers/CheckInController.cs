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

        public ActionResult Search(string stdSearch)
        {

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());


           
            //Select Table Where student Id is the Input 

            string sqlQuery = "SELECT STD_NAME, STD_ENTRANCE, STD_RESIDENCE FROM STUDENT_TABLE WHERE STD_ID=@sid";

            var model = new List<Student>();
            using (SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn))
            {
                var student = new Student();
                sqlConn.Open();
                sqlComm.Parameters.AddWithValue("@sid", stdSearch);


                    SqlDataReader sqlRead = sqlComm.ExecuteReader();

                if (sqlRead.Read())
                {

                    student.stdName = sqlRead["STD_NAME"].ToString();
                    student.stdResidence = sqlRead["STD_RESIDENCE"].ToString();
                    student.stdEntrance = sqlRead["STD_ENTRANCE"].ToString();
                    model.Add(student);
                }
                sqlConn.Close();
            }
            return View(model);
        }
        // GET: CheckIn
        public ActionResult Index()

        {



            return View();

        }
    }
}