using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeTable.Models;
namespace TimeTable.Controllers
{
    public class HomeController : ApiController
    {
       MyDataBaseEntities2 db=new MyDataBaseEntities2() ;
        [HttpGet]
        public HttpResponseMessage showData() {
            return Request.CreateResponse(db.taskDetails);           
        }
        
        [HttpGet]
        public HttpResponseMessage saveData(string task) {
            taskDetail t=new taskDetail();
            t.Tasks = task;
            db.taskDetails.Add(t);
            db.SaveChanges();
             return Request.CreateResponse("Successfully inserted");
        }
        [HttpGet]
        public HttpResponseMessage deleteData(int id) {
            taskDetail t = db.taskDetails.Where((i) => i.id == id).FirstOrDefault();
            if (t != null)
            {
                db.taskDetails.Remove(t);
                db.SaveChanges();
                return Request.CreateResponse("Successfully Deleted");

            }
            else
            {
                return Request.CreateResponse("No id exist");
            }
            }


    }
}
