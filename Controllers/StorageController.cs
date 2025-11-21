using Microsoft.AspNetCore.Mvc;
using Inventario.Services;
using Inventario.Dtos;

namespace Inventario.Controllers
{
    [ApiController]
    [Route("storage")]
    public class StorageController : ControllerBase
    {
        private readonly StorageService _service;

        public StorageController(StorageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListStore([FromQuery] StorageFilterDto dto)
        {
            try
            {
                return Ok(await _service.List(dto));
            }catch(Exception ex)
            {
                return StatusCode(505,new { 
                    operation = "Error",
                    error = ex.Message 
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorage([FromBody] StorageCreateDto data)
        {
            try
            {
                var response = await _service.Insert(data);

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
