using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App_Demo.Controllers
{
    public class ParkingLotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
