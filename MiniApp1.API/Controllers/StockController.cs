using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [Authorize(Roles = "Admin", Policy ="AnkaraPolicy")]
        [HttpGet]
        public IActionResult GetStock()
        {
            var userName = HttpContext.User.Identity.Name;
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.

            return Ok($"Stock İşlemleri => UserName : {userName} - userId : {userIdClaim.Value}");
        }
    }
}
