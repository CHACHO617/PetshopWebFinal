using Microsoft.AspNetCore.Mvc;
using PetshopProgreso2.Models;
using PetshopProgreso2.Services;

namespace PetshopProgreso2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicioApiCli _servicioApiCli;

        public ClienteController(IServicioApiCli servicioapicli)
        {
            _servicioApiCli= servicioapicli;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = await _servicioApiCli.ListarClientes();
            return View(clientes);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Cliente cliente = await _servicioApiCli.ObtenerCliente(id);
            return View(cliente);
        }

        public IActionResult Create()
        {
            Cliente cliente = new Cliente();
            return View(cliente);
        }

        public async Task<IActionResult> Create1(Cliente cliente)
        {
            await _servicioApiCli.GuardarCliente(cliente);
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> Details(int id)
        {
            Cliente cliente = new Cliente();
            cliente = await _servicioApiCli.ObtenerCliente(id);
            return View(cliente);   
        }

        public async Task<IActionResult> Edit1(int id, Cliente cliente)
        {
            await _servicioApiCli.EditarCliente(id, cliente);
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Delete(int id)
        {
            Cliente cliente = await _servicioApiCli.ObtenerCliente(id);
            await _servicioApiCli.EliminarCliente(cliente.Id);
            //return RedirectToAction("Index");
            return View (cliente);
            
        }

        public async Task<IActionResult> Delete1(Cliente cliente)
        {
            await _servicioApiCli.EliminarCliente(cliente.Id);
            return RedirectToAction ("Index");
        }
    }
}
