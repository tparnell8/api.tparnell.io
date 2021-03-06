﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace api.tparnell.io.Controllers
{
    public class WebsitesController : Controller
    {
        private static readonly Dictionary<string, IEnumerable<string>> endpoints = new Dictionary<string, IEnumerable<string>>
        {
            ["AboutMe"] = new List<string>() { "about.terribledev.io", "about.tommyparnell.com" },
            ["Resume"] = new List<string>() { "resume.terribledev.io", "resume.tommyparnell.com" },
            ["LetMeLycosThatForYou"] = new List<string>() { "lmltfy.xyz" },
            ["api"] = new List<string>() { "api.terribledev.io" },
            ["dotnetmashup"] = new List<string>() { "dotnetmashup.azurewebsites.net" }
        };

        [Route("~/Websites/{id?}")]
        public IActionResult Index(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                return new JsonResult(endpoints);
            }

            if(endpoints.ContainsKey(id))
            {
                return Redirect("http://" + endpoints[id].First());
            }
            return NotFound();
        }
    }
}