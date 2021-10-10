﻿using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {

        private JobSearchContext _data;
        public UsersController(JobSearchContext data) {
            _data = data;
        }

        [HttpGet]
        public IActionResult GetUser(string email, string password) {
            User userDb = _data.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
            if(userDb == null) {
                return NotFound(); // HTTP 404
            }

            return new JsonResult(userDb);
        }

        [HttpPost]
        public IActionResult AddUser(User user) {
            //Validacao

            _data.Users.Add(user);
            _data.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { email = user.Email, password = user.Password }, user);
        }
     }
}
