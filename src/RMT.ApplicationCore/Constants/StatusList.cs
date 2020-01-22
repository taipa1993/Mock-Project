using RMT.ApplicationCore.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Constants
{
    public static class StatusList
    {
        public static List<Status> Statuses()
        {
            List<Status> statuses = new List<Status>();
            statuses.Add(new Status("Not Process Yet", 1, "CV"));
            statuses.Add(new Status("In Process", 2, "CV"));
            statuses.Add(new Status("Hired", 3, "CV"));
            statuses.Add(new Status("Archived", 4, "CV"));

            statuses.Add(new Status("Not Invite Yet", 1, "Test"));
            statuses.Add(new Status("Invited", 2, "Test"));
            statuses.Add(new Status("Rejected", -2, "Test"));
            statuses.Add(new Status("Accepted", 3, "Test"));
            statuses.Add(new Status("Not Come", -3, "Test"));
            statuses.Add(new Status("Tested", 4, "Test"));
            statuses.Add(new Status("Pass", 5, "Test"));
            statuses.Add(new Status("Not Pass", -4, "Test"));

            statuses.Add(new Status("Not Invite Yet", 1, "Interview"));
            statuses.Add(new Status("Invited", 2, "Interview"));
            statuses.Add(new Status("Rejected", -2, "Interview"));
            statuses.Add(new Status("Accepted", 3, "Interview"));
            statuses.Add(new Status("Not Come", -3, "Interview"));
            statuses.Add(new Status("Interviewed", 4, "Interview"));
            statuses.Add(new Status("Feedbacked", 5, "Interview"));
            statuses.Add(new Status("Pass", 6, "Interview"));
            statuses.Add(new Status("Not Pass", -5, "Interview"));

            statuses.Add(new Status("Not Offer Yet", 1, "Offer"));
            statuses.Add(new Status("Offered", 2, "Offer"));
            statuses.Add(new Status("Rejected", -2, "Offer"));
            statuses.Add(new Status("Accepted", 3, "Offer"));
            statuses.Add(new Status("Not Come", -3, "Offer"));
            statuses.Add(new Status("Hired", 4, "Offer"));

            return statuses;
        }
    }
}
