//using Examen_U1_POO_CarlosPineda.Database.Entities;
//using Examen_U1_POO_CarlosPineda.Dtos.Categorias;
//using Examen_U1_POO_CarlosPineda.Dtos.Productos;
//using Newtonsoft.Json;

//namespace Examen_U1_POO_CarlosPineda.Services
//{
//    public class ProductosService
//    {
//        private readonly string _JSON_FILE;

//        public ProductosService()
//        {
//            _JSON_FILE = "SeedData/productos.json";
//        }

//        public async Task<List<ProductoDto>> GetProductosListAsync()
//        {
//            return await ReadProductosFromFileAsync();
//        }

//        public async Task<ProductoDto> GetProductoByIdAsync(Guid id)
//        {
//            var productos = await ReadProductosFromFileAsync();
//            ProductoDto producto = productos.FirstOrDefault(c => c.Id == id);
//            return producto;
//        }

//        public async Task<bool> CreateAsync(ProductoCreateDto dto)
//        {
//            var productosDtos = await ReadProductosFromFileAsync();

//            var productoDto = new ProductoDto
//            {
//                Id = Guid.NewGuid(),
//                Name = dto.Name,
//                Cantidad = dto.Cantidad,
//                Precio = dto.Precio,
//            };

//            productosDtos.Add(productoDto);

//            var productos = productosDtos.Select(x => new Producto
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Cantidad= x.Cantidad, 
//                Precio= x.Precio,
//            }).ToList();

//            await WriteProductosToFileAsync(productos);

//            return true;
//        }

//        public async Task<bool> EditAsync(ProductoEditDto dto, Guid id)
//        {
//            var productosDto = await ReadProductosFromFileAsync();

//            var existingProducto = productosDto.FirstOrDefault(producto => producto.Id == id);

//            if (existingProducto is null)
//            {
//                return false;
//            }

//            for (int i = 0; i < productosDto.Count; i++)
//            {
//                if (productosDto[i].Id == id)
//                {
//                    productosDto[i].Name = dto.Name;
//                    productosDto[i].Cantidad = dto.Cantidad;
//                    productosDto[i].Precio = dto.Precio;
//                }
//            }

//            var productos = productosDto.Select(x => new Producto
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Cantidad = x.Cantidad,
//                Precio = x.Precio,
//            }).ToList();

//            await WriteProductosToFileAsync(productos);

//            return true;
//        }

//        public async Task<bool> DeleteAsync(Guid id)
//        {
//            var productosDto = await ReadProductosFromFileAsync();
//            var productoEliminar = productosDto.FirstOrDefault(x => x.Id == id);

//            if (productoEliminar is null)
//            {
//                return false;
//            }

//            productosDto.Remove(productoEliminar);

//            var productos = productosDto.Select(x => new Producto
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Cantidad= x.Cantidad,
//                Precio= x.Precio,
//            }).ToList();

//            await WriteProductosToFileAsync(productos);

//            return true;
//        }

//        private async Task<List<ProductoDto>> ReadProductosFromFileAsync()
//        {
//            if (!File.Exists(_JSON_FILE))
//            {
//                return new List<ProductoDto>();
//            }

//            var json = await File.ReadAllTextAsync(_JSON_FILE);

//            var productos = JsonConvert.DeserializeObject<List<ProductoDto>>(json);

//            var dtos = productos.Select(x => new ProductoDto
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Cantidad = x.Cantidad,
//                Precio = x.Precio,
//            }).ToList();

//            return dtos;
//        }

//        private async Task WriteProductosToFileAsync(List<Producto> productos)
//        {
//            var json = JsonConvert.SerializeObject(productos, Formatting.Indented);

//            if (File.Exists(_JSON_FILE))
//            {
//                await File.WriteAllTextAsync(_JSON_FILE, json);
//            }
//        }
//    }
//}
