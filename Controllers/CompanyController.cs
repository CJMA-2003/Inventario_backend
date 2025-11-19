using Inventario.Data;
using Microsoft.AspNetCore.Mvc;
using Inventario.Dtos.Company;
namespace inventario.Controllers
{
    [Route("company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _context.Company.ToList();
            return Ok(companies);
        }

        public IActionResult CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Console.WriteLine($"Nombre: {dto.Nombre}");
            Console.WriteLine($"Dirección: {dto.Direccion}");
            return Ok(true);
        }

    }
}
