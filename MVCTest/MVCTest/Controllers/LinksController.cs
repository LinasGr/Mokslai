﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCTest.Controllers
{
    public class LinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}