using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsYou { get; set; }
        public string Avatar { get; set; }
    }
}
