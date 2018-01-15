using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
namespace MVCBusinessModel.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Index()
        {
            StudentLayerDao student = new StudentLayerDao();
            List<Students> stList = student.Studentlist.ToList<Students>();

            return View(stList);
        }

    }
}
