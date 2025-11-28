using Inventario.Dtos;
using Inventario.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [ApiController]
    [Route("categorization")]
    public class CategorizationController : ControllerBase
    {
        private readonly CategorizationService _services;

        public CategorizationController(CategorizationService service)
        {
            _services = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorization([FromBody] CategorizationDto dto)
        {
            try
            {
                var response = await _services.Insert(dto);

                return Ok(new
                {
                    status = "success",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategorizationDto dto)
        {
            try
            {
                var response = await _services.Update(id, dto);

                return Ok(new
                {
                    status = "success",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

    }
}