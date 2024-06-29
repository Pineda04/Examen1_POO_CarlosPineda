using Examen_U1_POO_CarlosPineda.Dtos.Productos;

namespace Examen_U1_POO_CarlosPineda.Services.Interfaces
{
    public interface IProductosService
    {
        Task<List<ProductoDto>> GetProductosListAsync();

        Task<ProductoDto> GetProductoByIdAsync(Guid id);

        Task<bool> CreateAsync(ProductoCreateDto dto);

        Task<bool> EditAsync(ProductoEditDto dto, Guid id);
        
        Task<bool> DeleteAsync(Guid id);
    }
}
