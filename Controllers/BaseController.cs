using CompanyManager.Database;
using CompanyManager.Database.Entities;
using CompanyManager.Interfaces.ControllerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IBaseServiceInterface<Employee> _employeeService;
        private readonly IBaseServiceInterface<Manager> _managerService;

        public BaseController(IBaseServiceInterface<Employee> Service, IBaseServiceInterface<Manager> Service2)
        {
            _employeeService = Service;
            _managerService = Service2; 
        }

        //[Route("Authenticate")]
        //[HttpPost]
        //public IActionResult Authenticate([FromBody] string username, string password)
        //{
        //    var getEmployee = _service.CustomQuery().FirstOrDefault(x => x.username == username);
        //    var getManager = _service.CustomQuery().FirstOrDefault(x => x.username == username);

        //    if (getEmployee == null && getManager == null)
        //        return Unauthorized();

        //    if (getEmployee != null)
        //        return AuthenticatePerson(getEmployee);

        //    if (getManager != null)
        //        return AuthenticatePerson(getManager);

        //    return BadRequest();
        //}

        //private ActionResult AuthenticatePerson<T>(T data) where T : BaseEntity
        //{
        //    var claims = new[]
        //    {
        //        new Claim("LoggedUserId", data.id.ToString())
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SpecialHiddenCaractarsForManiger"));
        //    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        "https://localhost:7169",
        //        "https://localhost:7169",
        //        claims,
        //        expires: DateTime.UtcNow.AddDays(1),
        //        signingCredentials: signingCredentials
        //    );

        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    string jwt = tokenHandler.WriteToken(token);

        //    return Ok(new { success = true, token = jwt });
        //}
    }
}
