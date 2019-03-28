using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.Commons
{
    public static class CheckPropertyExtension
    {
        public static bool CheckIsDeleted(this EntityEntry entityEntry)
        {
            var isDeleted = entityEntry.CurrentValues["IsDeleted"];
            if (isDeleted == null) return false;
            return bool.Parse(isDeleted.ToString());
        }
        public static bool CheckIsActive(this EntityEntry entityEntry)
        {
            var isActive = entityEntry.CurrentValues["IsActive"];
            if (isActive == null) return true;
            return bool.Parse(isActive.ToString());
        }
        public static bool CheckIsAccepted(this EntityEntry entityEntry)
        {
            var isAccepted = entityEntry.CurrentValues["IsAccepted"];
            if (isAccepted == null) return false;
            return bool.Parse(isAccepted.ToString());
        }
    }
}
