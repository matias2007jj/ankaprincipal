using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static CapaEntidad.E_Catalogos;

namespace CapaDatos
{
    public class D_Catalogos
    {
        private static readonly HttpClient client = new HttpClient();
        private string urlApi = "https://intranet.ankafire.com.pe/obtener_catalogos.php";

        public async Task<E_RespuestaCatalogos> ObtenerCatalogosWeb()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(urlApi);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<E_RespuestaCatalogos>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los catálogos: " + ex.Message);
            }
        }
        public async Task<List<E_Sede>> ObtenerSedesPorCliente(string codigoCliente)
        {
            if (string.IsNullOrEmpty(codigoCliente)) return new List<E_Sede>();

            try
            {
                string url = $"https://intranet.ankafire.com.pe/obtener_sedes.php?codigo_cliente={codigoCliente}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<E_RespuestaSedes>(jsonResponse);

                return res != null && res.exito ? res.sedes : new List<E_Sede>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener sedes: " + ex.Message);
            }
        }
    }
}