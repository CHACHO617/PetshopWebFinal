using PetshopProgreso2.Models;

namespace PetshopProgreso2.Services
{
    public interface IServicioApiPro
    {
        Task<List<Producto>> ListarProductos();
        Task<Producto> ObtenerProducto(int id);
        Task<string> GuardarProducto(Producto producto);
        Task<string> EditarProducto(int id, Producto producto);
        Task<string> EliminarProducto(int id);
    }
}
