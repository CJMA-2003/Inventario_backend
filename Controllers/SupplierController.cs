using Inventario.Dtos;
using Inventario.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iventario.Controllers
{
    [Route("supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _service;
        public SupplierController(SupplierService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SupplierDto dto)
        {
            try
            {
                var response = await _service.Insert(dto);
                return Ok(new
                {
                    operation = "success",
                    message = "Registro guardado con éxito.",
                    obj = response,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal error"
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierDto dto)
        {
            try
            {
                var response = await _service.Update(id, dto);
                return Ok(new
                {
                    operation = "success",
                    message = "Los cambios se han guardado correctamente.",
                    obj = response,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    operation = "error",
                    message = "Internal error"
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.Delete(id);
                return Ok(new
                {
                    operation = "success",
                    message = "El registro se ha eliminado correctamente.",
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    operation = "error",
                    message = "Internal error"
                });
            }
        }
        public async Task<IActionResult> List([FromQuery] SupplierDto dto)
        {
            try
            {
                var response = await _service.List(dto);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    status = "error",
                    message = "Internal error"
                });
            }
        }
    }
}