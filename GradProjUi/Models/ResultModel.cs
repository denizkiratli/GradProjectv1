using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradProjUi.Models
{
    public class ResultModel
    {
        public int ResultId { get; set; }

        public string AssignmentName { get; set; }

        public double Score { get; set; }

        public int NumberofAttendance { get; set; }
    }
}