using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMT.ApplicationCore.Entities;
using RMT.WebAPI.Helper;

namespace RMT.WebAPI.Controllers
{
    public class FileController : MrtBaseController
    {
        [HttpPost, DisableRequestSizeLimit]
        [Authorize(Roles = Role.Admin + "," + Role.HR)]
        public async Task<IActionResult> Upload()
        {
            var cvFile = Request.Form.Files[0];
            string typeFile = "";
            if (Path.HasExtension(cvFile.FileName))
            {
                 typeFile = Path.GetExtension(cvFile.FileName);
            }
            else
            {
                typeFile = String.Empty;
            }
            
            var folderName = Path.Combine("Resources", "CVFiles");
            var pathSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathSave))
            {
                Directory.CreateDirectory(pathSave);
            }
            if (cvFile.Length > 0)
            {
                string fileName = StringExtension.RandomString(20) + typeFile;
                string fullPath = Path.Combine(pathSave, fileName);
                using (var steam = new FileStream(fullPath, FileMode.Create))
                {
                    await cvFile.CopyToAsync(steam);
                }
                return Ok("Files/CVFiles/" + fileName);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}