using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.Helper
{
    public static class CVExtension
    {
        public static CV ToHideSalary(this CV cv)
        {
            cv.SalaryExpect = 0;
            cv.SalaryOffer = 0;
            return cv;
        }
        public static void DeleteCVFile(this CV cv)
        {
            var pathSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "CVFiles");
            string fileName = cv.Path.Split('/').Last();
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), pathSave, fileName);
            File.Delete(fullPath);
        }
    }
}
