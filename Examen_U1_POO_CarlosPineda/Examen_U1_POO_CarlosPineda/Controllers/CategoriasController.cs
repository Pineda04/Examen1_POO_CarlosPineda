using Examen_U1_POO_CarlosPineda.Dtos.Categorias;
using Examen_U1_POO_CarlosPineda.Services;
using Examen_U1_POO_CarlosPineda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_POO_CarlosPineda.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            this._categoriasService = categoriasService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _categoriasService.GetCategoriasListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var categoria = await _categoriasService.GetCategoriaByIdAsync(id);

            if (categoria == null)
            {
                return NotFound(new { Message = $"No se encontro la categoría: {id}" });
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoriaCreateDto dto)
        {
            await _categoriasService.CreateAsync(dto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(CategoriaEditDto dto, Guid id)
        {
            var result = await _categoriasService.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var categoria = await _categoriasService.GetCategoriaByIdAsync(id);

            if (categoria is null)
            {
                return NotFound();
            }

            await _categoriasService.DeleteAsync(id);

            return Ok();

        }
    }
}
