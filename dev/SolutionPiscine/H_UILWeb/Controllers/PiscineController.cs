using H_UILWeb.Dto;
using H_UILWeb.ViewModels;
using Newtonsoft.Json.Linq;
using PiscineBOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace H_UILWeb.Controllers
{
    public class PiscineController : Controller
    {
        public PiscineController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}