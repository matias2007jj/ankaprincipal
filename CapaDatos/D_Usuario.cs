using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Usuario
    {
        public async Task<bool> AutenticarUsuario(string usuario, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    var payload = new { usuario = usuario, password = password };
                    string jsonPayload = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://intranet.ankafire.com.pe/login.php", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        dynamic res = JsonConvert.DeserializeObject(jsonResult);

                        return res != null && (bool)res.exito;
                    }
                }
            }
            catch
            {
                // Manejo silencioso o log de excepción de red
            }
            return false;
        }
    }
}