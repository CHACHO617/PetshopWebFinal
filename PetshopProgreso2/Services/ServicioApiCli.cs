using PetshopProgreso2.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace PetshopProgreso2.Services
{
    public class ServicioApiCli : IServicioApiCli
    {
        private static string Url = "http://localhost:5062/";
        
        public ServicioApiCli() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
        
        public async Task<string> EditarCliente(int id, Cliente cliente)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url); 
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync("api/Cliente/" + id, content);
            if(response.IsSuccessStatusCode)
            {
                var json_respoonse = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respoonse);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> EliminarCliente(int id)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress=new Uri(Url);
            var response = await clienteHttp.DeleteAsync("api/Cliente/" + id);
            if(response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> GuardarCliente(Cliente cliente)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(Url); 
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Cliente", content);
            if(response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<List<Cliente>> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente> ();
            HttpClient clienteHtttp = new HttpClient ();
            clienteHtttp.BaseAddress = new Uri (Url);
            var response = await clienteHtttp.GetAsync("api/Cliente");
            if(response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync(); 
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                clientes = resultado.listaClientes;
            }
            return clientes;
        }

        public async Task<Cliente> ObtenerCliente(int id)
        {
            Cliente cliente1 = new Cliente ();
            HttpClient clienteHttp = new HttpClient ();
            clienteHttp.BaseAddress = new Uri (Url);
            var response = await clienteHttp.GetAsync("api/Cliente/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi> (json_response);
                cliente1 = resultado.cliente;
            }
            return cliente1;
        }
    }
}
