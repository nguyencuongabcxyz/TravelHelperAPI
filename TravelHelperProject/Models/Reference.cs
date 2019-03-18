using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Reference
    {
        public int ReferenceId { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsDeleted { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}
