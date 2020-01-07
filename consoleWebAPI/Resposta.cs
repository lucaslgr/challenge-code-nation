using System.Runtime.Serialization;
using System.Linq;

namespace consoleWebAPI
{
    public class Resposta
    {
        public int numero_casas { get; set; }

        public string token { get; set; }

        public string cifrado { get; set; }

        public string decifrado { get; set; }

        public string resumo_criptografico { get; set; }

    }
}