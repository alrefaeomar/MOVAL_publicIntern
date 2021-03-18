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

        [HttpPost]
        public ActionResult Index(string stdSearch, Student student, string Button)
        {

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

            //Select Table Where student Id is the Input 

            string sqlQuery = "SELECT STD_NAME, STD_ENTRANCE, STD_RESIDENCE FROM STUDENT_TABLE WHERE STD_ID=@sid";

            
            using (SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn))
            {
               
                sqlConn.Open();
                sqlComm.Parameters.AddWithValue("@sid", stdSearch);


                    SqlDataReader sqlRead = sqlComm.ExecuteReader();

                if (sqlRead.Read())
                {

                    student.stdName = sqlRead["STD_NAME"].ToString();
                    student.stdResidence = sqlRead["STD_RESIDENCE"].ToString();
                    student.stdEntrance = sqlRead["STD_ENTRANCE"].ToString();


                    student.registrarOff = sqlRead["STD_ENTRANCE"].ToString();
                    student.finAid = sqlRead["STD_ENTRANCE"].ToString();
                    student.bussOff = sqlRead["STD_ENTRANCE"].ToString();
                    student.admissions = sqlRead["STD_ENTRANCE"].ToString();

                    student.consenTreat = sqlRead["STD_ENTRANCE"].ToString();
                    student.medicalAlert = sqlRead["STD_ENTRANCE"].ToString();
                    student.immunizations = sqlRead["STD_ENTRANCE"].ToString();
                    student.emergContact = sqlRead["STD_ENTRANCE"].ToString();


                }
                sqlConn.Close();
            }

            // Clear data Button
            if (Button == "Clear")
            {
                ModelState.Clear();
                return PartialView();
            }


            return PartialView(student);
        }
        // GET: CheckIn

        public ActionResult Clear(Student student)
        {
            int stdid = student.stdId;
            string stdname = student.stdName;
            string stdEntrance = student.stdEntrance;
            string stdResidence = student.stdResidence;

            ModelState.Clear();
            return View();
        }

   [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
    }
}