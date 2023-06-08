using PetshopProgreso2.Models;

namespace PetshopProgreso2.Services
{
    public interface IServicioApiCli
    {
        Task<List<Cliente>> ListarClientes();
        Task<Cliente> ObtenerCliente(int id);
        Task<string> GuardarCliente(Cliente cliente);
        Task<string> EditarCliente(int id, Cliente cliente);
        Task<string> EliminarCliente(int id);
    }
}
