﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEFCrud.Web.Controllers
{
    public class CozinhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}