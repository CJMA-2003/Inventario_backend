using Microsoft.AspNetCore.Mvc;
using Inventario.Dtos;
using Inventario.Services;

namespace Inventario.Controllers
{
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductDto dto)
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
                    operation = "error",
                    message = "Internal error"
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
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
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    operation = "error",
                    message = "Internal error"
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ProductDto dto)
        {
            try
            {
                var response = await _service.List(dto);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e);
                return StatusCode(500, new
                {
                    operation = "error",
                    message = "Internal error"
                });
            }
        }
    }
}