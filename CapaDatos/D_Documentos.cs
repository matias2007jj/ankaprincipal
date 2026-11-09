using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RespuestaSubidaDoc
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public string nombre_guardado { get; set; }
        public string ruta_relativa { get; set; }
        public string ruta_web { get; set; }
        public string url_completa { get; set; }
    }

    public class D_Documentos
    {
        private static readonly HttpClient client = new HttpClient();
        private string urlApiSubida = "https://intranet.ankafire.com.pe/subir_documento.php";

        public async Task<string> SubirDocumentoWeb(string rutaArchivoLocal)
        {
            if (string.IsNullOrEmpty(rutaArchivoLocal) || !File.Exists(rutaArchivoLocal))
                return null;

            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    byte[] fileBytes = File.ReadAllBytes(rutaArchivoLocal);
                    var fileContent = new ByteArrayContent(fileBytes);

                    fileContent.Headers.Add("Content-Type", "application/pdf");
                    content.Add(fileContent, "archivo", Path.GetFileName(rutaArchivoLocal));

                    HttpResponseMessage response = await client.PostAsync(urlApiSubida, content);
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    RespuestaSubidaDoc res = JsonConvert.DeserializeObject<RespuestaSubidaDoc>(jsonResult);

                    if (res != null && res.exito)
                    {
                        // Prioriza url_completa o ruta_web devueltas por el PHP para evitar /storage/storage/
                        string urlFinal = !string.IsNullOrEmpty(res.url_completa) ? res.url_completa : res.ruta_web;

                        if (string.IsNullOrEmpty(urlFinal))
                        {
                            urlFinal = "https://intranet.ankafire.com.pe/" + res.ruta_relativa.TrimStart('/');
                        }

                        // Limpieza de seguridad contra duplicaciones de subcarpeta
                        urlFinal = urlFinal.Replace("/storage/storage/", "/storage/");

                        return urlFinal;
                    }
                    else
                    {
                        throw new Exception(res?.mensaje ?? "Error al procesar el documento en el servidor.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al subir archivo a Hostinger: " + ex.Message);
            }
        }
    }
}