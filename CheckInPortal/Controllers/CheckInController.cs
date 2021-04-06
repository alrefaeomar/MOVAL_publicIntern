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
                    student.finAid = sqlRead["FIN_AID"].ToString();
                    student.bussOff = sqlRead["BUSS_OFFICE"].ToString();
                    student.admissions = sqlRead["ADMISSIONS"].ToString();

                    student.consenTreat = sqlRead["CONSENT_TREAT"].ToString();
                    student.medicalAlert = sqlRead["MED_ALERT"].ToString();
                    student.immunizations = sqlRead["IMMUNIZATIONS"].ToString();
                    student.emergContact = sqlRead["EMERG_CONTACT"].ToString();

                    // Conditionals for Uncomplete offices
                      //Messages will be displayed if == UNCOMPLETE
                    if (student.registrarOff.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.regstrarMsg = "Call the Registrar's office 660-831-4122 or email registrar@moval.edu";
                    }
                    if (student.finAid.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.finAidMsg = "Call the Financial aid office 660-831-4171 or email financialaid@moval.edu";
                    }
                    if (student.bussOff.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.bussOffMsg = "Call the Business Office 660-831-4105 or email businessoffice@moval.edu";
                    }
                    if (student.admissions.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.admissionsMsg = "Call the Admissions Office 660-831-4114 or email admissions@moval.edu";
                    }


                    if (student.consenTreat.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.consenTreatMsg = "You do not consent to be treated in an Emergency, Complete the form ";
                    }
                    if (student.medicalAlert.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.medicalAlertMsg = "Please Complete the Forms";
                    }
                    if (student.immunizations.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.immunizationsMsg = "Please Complete the Forms";
                    }
                    if (student.emergContact.Trim() == "UNCOMPLETE")
                    {
                        ViewBag.emergContactMsg = "You do not have an emergency contact, please complete the forms";
                    }



                }
                sqlConn.Close();
            }

          

            // Clear data Button
            if (Button == "Clear")
            {
                ViewBag.regstrarMsg = "";
                ViewBag.finAidMsg = "";
                ViewBag.bussOffMsg = "";
                ViewBag.admissionsMsg = "";

                ViewBag.consenTreatMsg = "";
                ViewBag.medicalAlertMsg = "";
                ViewBag.immunizationsMsg = "";
                ViewBag.emergContactMsg = "";


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