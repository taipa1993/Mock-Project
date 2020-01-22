using RMT.ApplicationCore.BusinessObject;
using RMT.ApplicationCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.Helper
{
    public static class CheckHelper
    {
        private static List<Status> statuses = StatusList.Statuses();
        public static bool IsStatusChangeOK(string updateStatus, string currentStatus, string roundName)
        {
            var indexOfUpdate = statuses.Where(s => s.StatusOf == roundName && s.Name == updateStatus).FirstOrDefault().Index;
            var indexOfCurrent = statuses.Where(s => s.StatusOf == roundName && s.Name == currentStatus).FirstOrDefault().Index;
            if ((indexOfUpdate != 0) && (indexOfCurrent != 0))
            {
                if ((indexOfUpdate - indexOfCurrent) == 1 || (indexOfUpdate == indexOfCurrent) || (indexOfUpdate / indexOfCurrent) == -1) return true;
            }
            return false;
        }
        public static bool IsStatusExist(string status, string roundName)
        {
            var indexOfStatus = statuses.Where(s => s.StatusOf == roundName && s.Name == status).FirstOrDefault().Index;
            if (indexOfStatus != 0) return true;
            return false;
        }
    }
}
