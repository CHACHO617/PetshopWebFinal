
using Microsoft.AspNetCore.Mvc;
using PetshopProgreso2.Models;
using PetshopProgreso2.Services;

namespace PetshopProgreso2.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServicioApiPro _servicioApiPro;

        public ProductoController(IServicioApiPro servicioApiPro)
        {
            _servicioApiPro = servicioApiPro;
        }

        public async Task<IActionResult> Index()
        {
            List<Producto> productos = new List<Producto>();
            productos = await _servicioApiPro.ListarProductos();
            return View(productos);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Producto producto = await _servicioApiPro.ObtenerProducto(id);
            return View(producto);
        }

        public IActionResult Create()
        {
            Producto producto = new Producto();
            return View(producto);
        }

        public async Task<IActionResult> Create1(Producto producto)
        {
            await _servicioApiPro.GuardarProducto(producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Producto producto = new Producto();
            producto = await _servicioApiPro.ObtenerProducto(id);
            return View(producto);
        }

        public async Task<IActionResult> Edit1(int id, Producto producto)
        {
            await _servicioApiPro.EditarProducto(id, producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Producto producto = await _servicioApiPro.ObtenerProducto(id);
            await _servicioApiPro.EliminarProducto(producto.Id);
            //return RedirectToAction("Index");
            return View(producto);

        }

        public async Task<IActionResult> Delete1(Producto producto)
        {
            await _servicioApiPro.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}
