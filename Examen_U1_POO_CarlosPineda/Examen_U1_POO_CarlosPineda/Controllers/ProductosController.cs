using Examen_U1_POO_CarlosPineda.Dtos.Categorias;
using Examen_U1_POO_CarlosPineda.Dtos.Productos;
using Examen_U1_POO_CarlosPineda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_POO_CarlosPineda.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController: ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            this._productosService = productosService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _productosService.GetProductosListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var producto = await _productosService.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound(new { Message = $"No se encontro el producto: {id}" });
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductoCreateDto dto)
        {
            await _productosService.CreateAsync(dto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(ProductoEditDto dto, Guid id)
        {
            var result = await _productosService.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var producto = await _productosService.GetProductoByIdAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            await _productosService.DeleteAsync(id);

            return Ok();

        }
    }
}
