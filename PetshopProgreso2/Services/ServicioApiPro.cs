using Newtonsoft.Json;
using PetshopProgreso2.Models;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace PetshopProgreso2.Services
{
    public class ServicioApiPro : IServicioApiPro
    {
        private static string Url = "http://localhost:5062/";

        public ServicioApiPro()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        public async Task<string> EditarProducto(int id, Producto producto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url);
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync("api/Producto/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                var json_respoonse = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respoonse);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> EliminarProducto(int id)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url);
            var response = await clienteHttp.DeleteAsync("api/Producto/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> GuardarProducto(Producto producto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url);
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Producto", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<List<Producto>> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            HttpClient clienteHtttp = new HttpClient();
            clienteHtttp.BaseAddress = new Uri(Url);
            var response = await clienteHtttp.GetAsync("api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                productos = resultado.listaProductos;
            }
            return productos;
        }

        public async Task<Producto> ObtenerProducto(int id)
        {
            Producto producto1 = new Producto();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url);
            var response = await clienteHttp.GetAsync("api/Producto/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                producto1 = resultado.producto;
            }
            return producto1;
        }
    }
}
