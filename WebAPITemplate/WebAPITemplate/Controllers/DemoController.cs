﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPITemplate.Models;

namespace WebAPITemplate.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("WebApi-With-Swagger-Integration " + ConfigurationManager.AppSettings["ApiVersion"]);
        }

        [HttpGet]
        [Route("v1/GetEmployeeDetails")]
        public async Task<IHttpActionResult> GetEmployeeDetails(int empId)
        {
            //Get data from business to data layer
            Employee x = new Employee()
            {
                Id = empId,
                Name = "Ujjwal Wagle",
                BirthDate = "03-May-1988",
                Designation = "Software Developer",
                Experience = "6 Years"
            };
            return Ok(x);
        }

        [HttpPost]
        [Route("v1/AddEmployee")]
        public async Task<IHttpActionResult> AddEmployee(List<Employee> empList)
        {
            //Save data from business to data layer
            return Ok(new { result = string.Format("{0} records added successfully.", empList.Count) });

        }
    }
}
