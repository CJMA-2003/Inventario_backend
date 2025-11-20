using Inventario.Data;
using Microsoft.AspNetCore.Mvc;
using Inventario.Dtos.Company;
using Inventario.Models;
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
            var companies = _context.Company
            .Skip(0)
            .Take(1)   
            .ToList();
            return Ok(companies);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyCreateDto dto)
        {
            // Verificar si ya existe una compañía con la misma identidad
            var existingCompany = _context.Company
                .FirstOrDefault(c => c.identidad == dto.identidad);

            if (existingCompany != null)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "La compañía ya existe"
                });
            }

            // Crear la nueva compañía
            var company = new Company
            {
                identidad = dto.identidad,
                nombre = dto.nombre,
                direccion = dto.direccion
            };

            _context.Company.Add(company);
            _context.SaveChanges();

            return Ok(new
            {
                status = "success",
                message = "Compañía registrada exitosamente",
                obj = company
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id,[FromBody] CompanyUpdateDto dto)
        {
            var company = _context.Company.Find(id);
            if(company == null){
                return BadRequest(new
                {
                    status = "error",
                    message = "La compañía no existe"
                });
            }

            if(!string.IsNullOrEmpty(dto.direccion)){
                company.direccion = dto.direccion;
            }

            _context.SaveChanges();
            return Ok(new 
            {
            status = "success",
            message = "Valores actualizados correctamente"
            });
        }

    }
}
