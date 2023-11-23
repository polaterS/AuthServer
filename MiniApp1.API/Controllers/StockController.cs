﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            var userName = HttpContext.User.Identity.Name;
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var email = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email);

            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.

            return Ok($"Stock İşlemleri => UserName : {userName} - userId : {userIdClaim.Value} - Email : {email}");
        }
    }
}
