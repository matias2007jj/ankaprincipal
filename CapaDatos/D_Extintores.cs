using System;
using System.Collections.Generic;
using System.Net.Http; // Mantén solo una vez este using para evitar la advertencia CS0105
using System.Threading.Tasks;
using Newtonsoft.Json;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Extintores
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<E_Extintor>> ObtenerExtintores()
        {
            List<E_Extintor> lista = new List<E_Extintor>();
            string url = "https://intranet.ankafire.com.pe/obtener_extintores.php";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // CAMBIO AQUÍ: Usar ReadAsStringAsync() sobre response.Content
                    string json = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<E_Extintor>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CapaDatos: " + ex.Message);
            }

            return lista;
        }
    }
}