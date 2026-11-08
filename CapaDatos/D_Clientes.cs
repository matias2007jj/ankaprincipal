using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Clientes
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<E_Cliente>> ObtenerClientes()
        {
            List<E_Cliente> lista = new List<E_Cliente>();
            string url = "https://intranet.ankafire.com.pe/obtener_clientes.php";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<E_Cliente>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CapaDatos Clientes: " + ex.Message);
            }

            return lista;
        }
    }
}