using CompanyManager.Database;
using CompanyManager.Database.Entities;
using CompanyManager.Interfaces.ControllerInterfaces;
using CompanyManager.Seeder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CompanyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IBaseServiceInterface<Manager> _manager;
        private readonly Seed<Manager> seed;

        public ManagerController(IBaseServiceInterface<Manager> Service)
        {
            _manager = Service;
            seed = new Seed<Manager>(_manager);

            if (_manager.GetAll().IsNullOrEmpty())
                seed.seedData(new Manager() 
                {
                    name = "test",
                    createdOn = DateTime.UtcNow,
                    removedOn = DateTime.UtcNow,
                    username = "test",
                    password = "test",
                    yearsOfExperience = 1,
                    salary = 1,
                });
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _manager.GetAll();

            if (!result.IsNullOrEmpty())
                return Ok(result);

            return Problem("No data found");
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _manager.Get(id);

            if (result != null)
                return Ok(result);

            return Problem("No data found");
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Post([FromBody] Manager data)
        {
            if (_manager.Edit(data, data.id))
                return Ok(data);

            return Problem("Failed to create object");
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Delete([FromBody] int id)
        {
            if (_manager.Delete(id))
                return Ok(id);

            return Problem("Failed to create object");
        }
    }
}
