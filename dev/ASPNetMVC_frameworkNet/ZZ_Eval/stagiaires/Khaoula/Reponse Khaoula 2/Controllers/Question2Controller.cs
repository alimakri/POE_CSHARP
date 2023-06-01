using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace ZZ_Eval.Controllers
{
    public class Question2Controller : Controller
    {
        private ArrayList MesData;

        public Question2Controller()
        {
        }


        public Question2Controller(ArrayList data)
        {
            MesData = data;
        }
        public ActionResult Index()
        {
            return View(MesData);
        }
    }
}