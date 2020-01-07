using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace consoleWebAPI
{
    public class RespostaRepositorio
    {
        HttpClient cliente = new HttpClient();

        public RespostaRepositorio()
        {
            
        }

        public async Task<Resposta> GetDataAsync()
        {
            var client = new HttpClient();

            var url = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=<SEU TOKEN>";

            using (var response = await client.GetAsync(url).ConfigureAwait(false))
            {
                var json = await response.Content.ReadAsStringAsync();
                var jsonIdentado = JValue.Parse(json).ToString(Formatting.Indented);
                Console.WriteLine(jsonIdentado);
                return JsonConvert.DeserializeObject<Resposta>(jsonIdentado);
            }
        }
    }
}