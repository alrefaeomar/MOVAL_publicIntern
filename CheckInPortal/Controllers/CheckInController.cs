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
            string sqlQuery = @"SELECT STUDENT_TABLE.STD_ID, STD_NAME, STD_ENTRANCE, STD_RESIDENCE, REGISTRAR, 
                FIN_AID, BUSS_OFFICE, ADMISSIONS, CONSENT_TREAT, MED_ALERT, IMMUNIZATIONS, EMERG_CONTACT FROM STUDENT_TABLE
                INNER JOIN OFFICES_TABLE ON STUDENT_TABLE.STD_ID = OFFICES_TABLE.STD_ID WHERE STUDENT_TABLE.STD_ID=@sid";

            
            using (SqlCommand sqlComm = new SqlCommand(sqlQuery, sqlConn))
            {
               
                sqlConn.Open();
                sqlComm.Parameters.AddWithValue("@sid", stdSearch);


                    SqlDataReader sqlRead = sqlComm.ExecuteReader();

                while(sqlRead.Read())
                {

                    student.stdName = sqlRead["STD_NAME"].ToString();
                    student.stdResidence = sqlRead["STD_RESIDENCE"].ToString();
                    student.stdEntrance = sqlRead["STD_ENTRANCE"].ToString();

                    
                   
                    student.registrarOff = sqlRead["REGISTRAR"].ToString();

                    if (student.registrarOff == "COMPLETE")
                    {
                        ViewBag.regstrarMsg = "TEST";
                        return View();
                    }
                    student.finAid = sqlRead["FIN_AID"].ToString();
                    student.bussOff = sqlRead["BUSS_OFFICE"].ToString();
                    student.admissions = sqlRead["ADMISSIONS"].ToString();

                    student.consenTreat = sqlRead["CONSENT_TREAT"].ToString();
                    student.medicalAlert = sqlRead["MED_ALERT"].ToString();
                    student.immunizations = sqlRead["IMMUNIZATIONS"].ToString();
                    student.emergContact = sqlRead["EMERG_CONTACT"].ToString();


                }
                sqlConn.Close();
            }

          

            // Clear data Button
            if (Button == "Clear")
            {
                ViewBag.regstrarMsg = "";
                ModelState.Clear();
                return PartialView();
            }

            return PartialView(student);
        }
        // GET: CheckIn
   [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
    }
}