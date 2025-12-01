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
        public async Task<IActionResult> ListStore([FromQuery] StorageDto dto)
        {
            try
            {
                return Ok(await _service.List(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(505, new
                {
                    operation = "Error",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorage([FromBody] StorageDto data)
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStorage(int id, [FromBody] StorageDto dto)
        {
            try
            {
                var response = await _service.Update(id, dto);

                return Ok(new
                {
                    status = "success",
                    data = response,
                    message = "Registro actualizado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal error",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(int id)
        {
            try
            {
                var response = await _service.Delete(id);
                return Ok(new
                {
                    status = "success",
                    message = "Registro eliminado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal error",
                    error = ex.Message
                });
            }
        }
    }
}
