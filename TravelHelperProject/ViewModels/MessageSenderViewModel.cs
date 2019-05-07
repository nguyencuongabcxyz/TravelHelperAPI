using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.ViewModels
{
    public class MessageSenderViewModel
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Id { get; set; }
        public string LastedMessage { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
