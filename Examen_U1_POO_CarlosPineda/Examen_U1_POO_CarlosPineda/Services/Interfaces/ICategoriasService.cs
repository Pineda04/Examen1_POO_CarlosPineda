using Examen_U1_POO_CarlosPineda.Dtos.Categorias;

namespace Examen_U1_POO_CarlosPineda.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task<List<CategoriaDto>> GetCategoriasListAsync();

        Task<CategoriaDto> GetCategoriaByIdAsync(Guid id);

        Task<bool> CreateAsync(CategoriaCreateDto dto);

        Task<bool> EditAsync(CategoriaEditDto dto, Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
