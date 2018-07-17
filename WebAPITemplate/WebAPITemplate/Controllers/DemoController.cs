using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPITemplate.Filters;
using WebAPITemplate.Models;

namespace WebAPITemplate.Controllers
{
    [EnableCors(origins: "http://www.DemoWebapp.com", headers: "*", methods: "*")]
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("WebApi-Template " + ConfigurationManager.AppSettings["ApiVersion"]);
        }

        [HttpGet]
        [AuthorizeCheck]
        [Route("v1/GetEmployeeDetails")]
        public async Task<IHttpActionResult> GetEmployeeDetails(int empId)
        {
            //Get data from business to data layer
            Employee x = new Employee()
            {
                Id = empId,
                Name = "Aniket Phadte",
                Designation = "Software Developer",
                Experience = "3 Years"
            };
            return Ok(x);
        }

        [HttpPost]
        [AuthorizeCheck]
        [Route("v1/AddEmployee")]
        public async Task<IHttpActionResult> AddEmployee(List<Employee> empList)
        {
            //Save data from business to data layer
            throw new Exception();
            return Ok(new { result = string.Format("{0} records added successfully.", empList.Count) });

        }

        [HttpGet]
        [DisableCors]
        [NotImplExceptionFilter]
        [Route("v1/GetEmployeeDesignation")]
        public async Task<IHttpActionResult> GetEmployeeDesignation(int empId)
        {
            throw new NotImplementedException("This method is not implemented");
        }
    }
}
