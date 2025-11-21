using Inventario.Data;
using Inventario.Dtos.Company;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
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

        // GET: company?page=1&perPage=10
        [HttpGet]
        public IActionResult GetCompanies(int page = 1, int perPage = 10)
        {
            var total = _context.Company.Count();

            var companies = _context.Company
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();

            var response = new
            {
                data = companies,
                current_page = page,
                per_page = perPage,
                total = total,
                to = Math.Min(page * perPage, total)
            };

            return Ok(response);
        }

        // POST: company
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyCreateDto dto)
        {
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

        // PUT: company/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] CompanyUpdateDto dto)
        {
            var company = _context.Company.Find(id);

            if (company == null)
            {
                return BadRequest(new
                {
                    status = "error",
                    message = "La compañía no existe"
                });
            }

            if (!string.IsNullOrEmpty(dto.direccion))
            {
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
