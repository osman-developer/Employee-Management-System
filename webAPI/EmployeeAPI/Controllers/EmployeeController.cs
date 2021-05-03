using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Entities.Entities;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration MyConfig;
        //dep inject to reach folder path
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration config, IWebHostEnvironment env)
        {
            this.MyConfig = config;
            _env = env;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public JsonResult Get()
        {

            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
           // return oBLC.GetAllCourts()
            return new JsonResult(oBLC.GetAllEmployees());
        }

        [HttpPost]
        [Route("EditEmployee")]
        public JsonResult Post(Employee i_employee)
        {
            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            oBLC.Edit_Employee(i_employee);
            return new JsonResult("Your query has Succeeded");
        }


        [HttpPost]
        [Route("DeleteEmployee")]
        public JsonResult Delete(Params_Delete_Employee i_Params_Delete_Employee)
        {
            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            oBLC.Delete_Employee(i_Params_Delete_Employee);
            return new JsonResult("Deleted Successfuly");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    //saved the file
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }


        [Route("GetAllDepartmentName")]
        public JsonResult GetAllDepartmentNames()
        {

            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            // return oBLC.GetAllCourts()
            return new JsonResult(oBLC.GetAllDepartmentsName());
        }
    }
}