using System;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;

namespace consoleWebAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Acessando a Web API, Aguarde um momento...");

            var resposta = new RespostaRepositorio();

            //Pegando o resultado
            var resultado = await resposta.GetDataAsync();
            
            using (var stream = new System.IO.FileStream("answer.json", System.IO.FileMode.Create))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Resposta));
                serializer.WriteObject(stream, resultado);
            }

            // WriteLine(resultado.cifrado.ToString());

            var cifrado = resultado.cifrado.ToString();

            WriteLine(Descriptografando.Descriptografar(cifrado, 10)); //ok

            var decifrado = Descriptografando.Descriptografar(cifrado, 10);

            // using (var stream = new System.IO.FileStream("answer.json", System.IO.FileMode.Open))
            // {
            //     var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Resposta));
            //     serializer.WriteObject(stream, resultado);
            // }

            resultado.decifrado = decifrado;

            var decifradoResumo = ToResume.getResume(decifrado);

            resultado.resumo_criptografico = decifradoResumo;

            using (var stream = new System.IO.FileStream("answer.json", System.IO.FileMode.Open))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Resposta));
                serializer.WriteObject(stream, resultado);
            }


            //ETAPA DO ENVIO
            var url = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=2031a6e2337e715d926e16d2beadbc82235b60dd";

            var multipart = new MultipartFormDataContent();

            //Montando o form para ser enviado
            var body = new StringContent(resultado.ToString(), Encoding.UTF8, "application/json");
            multipart.Add(body);
            multipart.Add(new ByteArrayContent(File.ReadAllBytes("answer.json")), "answer", "answer.json");

            //Enviando
            var httpClient = new HttpClient();
            var response = httpClient.PostAsync(new Uri(url), multipart).Result;


            // var stringFinal = File.ReadAllText("answer.json");
            // WriteLine(stringFinal);


            ReadLine();
        }
    }
}
