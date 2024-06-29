using Examen_U1_POO_CarlosPineda.Database.Entities;
using Examen_U1_POO_CarlosPineda.Dtos.Categorias;
using Examen_U1_POO_CarlosPineda.Services.Interfaces;
using Newtonsoft.Json;

namespace Examen_U1_POO_CarlosPineda.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly string _JSON_FILE;

        public CategoriasService()
        {
            _JSON_FILE = "SeedData/categorias.json"; 
        }

        public async Task<List<CategoriaDto>> GetCategoriasListAsync()
        {
            return await ReadCategoriasFromFileAsync();
        }

        public async Task<CategoriaDto> GetCategoriaByIdAsync(Guid id)
        {
            var categorias = await ReadCategoriasFromFileAsync();
            CategoriaDto categoria = categorias.FirstOrDefault(c => c.Id == id);
            return categoria;
        }

        public async Task<bool> CreateAsync(CategoriaCreateDto dto)
        {
            var categoriasDtos = await ReadCategoriasFromFileAsync();

            var categoriaDto = new CategoriaDto
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
            };

            categoriasDtos.Add(categoriaDto);

            var categorias = categoriasDtos.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            await WriteCategoriasToFileAsync(categorias);

            return true;
        }

        public async Task<bool> EditAsync(CategoriaEditDto dto, Guid id)
        {
            var categoriasDto = await ReadCategoriasFromFileAsync();

            var existingCategory = categoriasDto.FirstOrDefault(categoria => categoria.Id == id);

            if (existingCategory is null)
            {
                return false;
            }

            for (int i = 0;  i < categoriasDto.Count; i++)
            {
                if (categoriasDto[i].Id == id)
                {
                    categoriasDto[i].Name = dto.Name;
                }
            }

            var categorias = categoriasDto.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            await WriteCategoriasToFileAsync(categorias);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoriasDto = await ReadCategoriasFromFileAsync();
            var categoriaEliminar = categoriasDto.FirstOrDefault(x => x.Id == id);

            if (categoriaEliminar is null)
            {
                return false;
            }

            categoriasDto.Remove(categoriaEliminar);

            var categorias = categoriasDto.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            await WriteCategoriasToFileAsync(categorias);

            return true;
        }

        private async Task<List<CategoriaDto>> ReadCategoriasFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<CategoriaDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var categorias = JsonConvert.DeserializeObject<List<CategoriaDto>>(json);

            var dtos = categorias.Select(x => new CategoriaDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return dtos;
        }

        private async Task WriteCategoriasToFileAsync(List<Categoria> categorias)
        {
            var json = JsonConvert.SerializeObject(categorias, Formatting.Indented);

            if(File.Exists(_JSON_FILE))
            {
                await File.WriteAllTextAsync(_JSON_FILE, json);
            }
        }
    }
}
