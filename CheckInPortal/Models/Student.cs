using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckInPortal.Models
{
    public class Student
    {
        public int stdId { get; set; }
        public string stdName { get; set; }
        public string stdEntrance { get; set; }
        public string stdResidence { get; set; }


        public string registrarOff { get; set; }
        public string finAid { get; set; }
        public string bussOff { get; set; }
        public string admissions { get; set; }

        public string consenTreat { get; set; }
        public string medicalAlert { get; set; }
        public string immunizations { get; set; }
        public string emergContact { get; set; }

    }
}