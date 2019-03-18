using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsSolved { get; set; }

        public ApplicationUser Reporter { get; set; }
        public ApplicationUser Violator { get; set; }
    }
}
