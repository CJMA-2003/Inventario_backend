using Microsoft.AspNetCore.Mvc;
using Inventario.Services;
using Inventario.Dtos;

namespace Iventario.Controllers.Storage
{
    [Route("store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreService _service;

        public StoreController(StoreService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] StoreDto dto)
        {
            try
            {
                var response = await _service.Insert(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal Error"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStore([FromQuery] StoreDto filterDto)
        {
            var response = await _service.List(filterDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            try
            {
                var response_api = new
                {
                    status = "",
                    message = ""
                };

                var success = await _service.Delete(id);

                if (success)
                {
                    return Ok(new { status = "success", message = "Registro eliminado exitosamente" });
                }
                else
                {
                    return NotFound(new { status = "error", message = "No se encontr� el registro" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal Error"
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateStore(int id, [FromBody] StoreDto dto)
        {
            try
            {
                var response = await _service.Update(id, dto);
                return Ok(new
                {
                    status = "success",
                    message = "Registro actualizado con exito",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal Error"
                });
            }

        }

    }
}