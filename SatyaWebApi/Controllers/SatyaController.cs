using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;

namespace SatyaWebApi.Controllers
{
    public class SatyaController : ApiController
    {
        //Add Action for GET // for Fetch data from database and return to the Client
        public HttpResponseMessage Get()
        {
            List<Employee> allEmp = new List<Employee>();
            using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities()) //here MyDatabaseEntities is our datacontext
            {
                allEmp = dc.Employees.OrderBy(a => a.FirstName).ToList(); // I have added linq code for fetch data, you can use Sql client for fetch data
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, allEmp);
                return response;
            }
        }
        public HttpResponseMessage Post(Employee emp)
        {
            HttpResponseMessage response;
            if (ModelState.IsValid)
            {
                using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities())
                {
                    dc.Employees.Add(emp);
                    dc.SaveChanges();
                }
                response = Request.CreateResponse(HttpStatusCode.Created, emp);

                ////added for get in part3 in asp.net web api part3 , if we not commented then part4 will not work using httpclient

                //List<Employee> allEmp = new List<Employee>();
                //using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities()) //here MyDatabaseEntities is our datacontext
                //{
                //    allEmp = dc.Employees.OrderBy(a => a.FirstName).ToList(); // I have added linq code for fetch data, you can use Sql client for fetch data
                //    HttpResponseMessage response1;
                //    response1 = Request.CreateResponse(HttpStatusCode.OK, allEmp);
                //    return response1;
                //}

                ////added for get in part 5 in asp.net web api part-5 , if we not commented then part-6 will not work using httpclient
            }

            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error! Please try again with valid data.");
            }
            return response;
        }
    }
}

#region for part-3
//public HttpResponseMessage Post(Employee emp) //For part-3
//{
//    HttpResponseMessage response;
//    if (ModelState.IsValid)
//    {
//        using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities())
//        {
//            dc.Employees.Add(emp);
//            dc.SaveChanges();
//        }
//        response = Request.CreateResponse(HttpStatusCode.Created, emp);

////added for get in part 5 in asp.net web api part-5 , if we not commented then part-6 will not work using httpclient

//List<Employee> allEmp = new List<Employee>();
//using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities()) //here MyDatabaseEntities is our datacontext
//{
//    allEmp = dc.Employees.OrderBy(a => a.FirstName).ToList(); // I have added linq code for fetch data, you can use Sql client for fetch data
//    HttpResponseMessage response1;
//    response1 = Request.CreateResponse(HttpStatusCode.OK, allEmp);
//    return response1;
//}

////added for get in part 5 in asp.net web api part-5 , if we not commented then part-6 will not work using httpclient
//    }

//    else
//    {
//        response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error! Please try again with valid data.");
//    }
//    return response;
//}

#endregion

#region for part-2 , Part-1
//Old
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Entities;

//namespace SatyaWebApi.Controllers
//{
//    public class SatyaController : ApiController
//    {
//        //Add Action for GET // for Fetch data from database and return to the Client
//        public HttpResponseMessage Get()
//        {
//            List<Employee> allEmp = new List<Employee>();
//            using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities()) //here MyDatabaseEntities is our datacontext
//            {
//                allEmp = dc.Employees.OrderBy(a => a.FirstName).ToList(); // I have added linq code for fetch data, you can use Sql client for fetch data
//                HttpResponseMessage response;
//                response = Request.CreateResponse(HttpStatusCode.OK, allEmp);
//                return response;
//            }
//        }
//        public HttpResponseMessage Post(Employee emp)
//        {
//            HttpResponseMessage response;
//            if (ModelState.IsValid)
//            {
//                using (CrystalGranite2016Entities dc = new CrystalGranite2016Entities())
//                {
//                    dc.Employees.Add(emp);
//                    dc.SaveChanges();
//                }
//                response = Request.CreateResponse(HttpStatusCode.Created, emp);
//            }

//            else
//            {
//                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error! Please try again with valid data.");
//            }
//            return response;
//        }
//    }
//}
//Old
#endregion