using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class DepartmentController : ControllerBase
    {   //this dep inject to reach the appsettings 

        private readonly IConfiguration MyConfig;
        //dep inject to reach folder path
        private readonly IWebHostEnvironment _env;
        public DepartmentController(IConfiguration config, IWebHostEnvironment env)
        {
            this.MyConfig = config;
            _env = env;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public JsonResult Get()
        {
            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            return new JsonResult(oBLC.GetAllDepartments());
           
        }

        [HttpPost]
        [Route("GetDepartmentsByWhere")]
        public JsonResult GetDepartmentByWhere(Department i_Department)
        {
            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            return new JsonResult(oBLC.GetDepartmentsByWhere(i_Department));

        }

        [HttpPost]
        [Route("EditDepartment")]
        public JsonResult Post(Department i_department) {

            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            oBLC.Edit_Department(i_department);
            return new JsonResult("Your query has Succeeded");
        }


        [HttpPost]
        [Route("DeleteDepartment")]
        public JsonResult Delete(Params_Delete_Department i_Params_Delete_Department)
        {
            BLC.BLC oBLC = new BLC.BLC();
            oBLC.connStr = this.MyConfig["AppSettings:MyDBConnection"];
            oBLC.Delete_Department(i_Params_Delete_Department);
            return new JsonResult("Deleted Successfuly");
        }
    }
}