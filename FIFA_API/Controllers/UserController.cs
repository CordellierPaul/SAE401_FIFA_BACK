﻿using FIFA_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIFA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = Policies.Utilisateur)]
        public IActionResult GetUserData()
        {
            return Ok("This is a response from user method");
        }

        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult GetAdminData()
        {
            return Ok("This is a response from Admin method");
        }
    }
}
